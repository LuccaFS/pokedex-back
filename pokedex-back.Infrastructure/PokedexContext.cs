using Microsoft.EntityFrameworkCore;
using pokedex_back.Domain.Aggregates;

namespace pokedex_back.Infrastructure
{
    public partial class PokedexContext : DbContext
    {
        public PokedexContext()
        {
        }

        public PokedexContext(DbContextOptions<PokedexContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FormGroup> FormGroups { get; set; } = null!;
        public virtual DbSet<Game> Games { get; set; } = null!;
        public virtual DbSet<Pokedex> Pokedices { get; set; } = null!;
        public virtual DbSet<Pokemon> Pokemons { get; set; } = null!;
        public virtual DbSet<PokemonGroup> PokemonGroups { get; set; } = null!;
        public virtual DbSet<Rank> Ranks { get; set; } = null!;
        public virtual DbSet<RankMapper> RankMappers { get; set; } = null!;
        public virtual DbSet<ShinyHunt> ShinyHunts { get; set; } = null!;
        public virtual DbSet<ShinyMethod> ShinyMethods { get; set; } = null!;
        public virtual DbSet<Trainer> Trainers { get; set; } = null!;
        public virtual DbSet<PokemonType> PokemonTypes { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FormGroup>(entity =>
            {
                entity.Property(e => e.FormGroupName).HasMaxLength(20);
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.Property(e => e.GameNames).HasMaxLength(50);
            });

            modelBuilder.Entity<Pokedex>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Pokedex");

                entity.HasOne(d => d.TrainerNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Trainer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pokedex_Trainer");
            });

            modelBuilder.Entity<Pokemon>(entity =>
            {
                entity.HasKey(e => e.PokemonGuid)
                    .HasName("PK_Pokemons_1");

                entity.Property(e => e.PokemonGuid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.PokemonName).HasMaxLength(30);

                entity.HasOne(d => d.FormGroup)
                    .WithMany(p => p.Pokemons)
                    .HasForeignKey(d => d.FormGroupId)
                    .HasConstraintName("FK_Pokemon_FormGroup");

                entity.HasOne(d => d.PokemonGroup)
                    .WithMany(p => p.Pokemons)
                    .HasForeignKey(d => d.PokemonGroupId)
                    .HasConstraintName("FK_Pokemon_PokemonGroup");

                entity.HasOne(d => d.Type1Navigation)
                    .WithMany(p => p.PokemonType1Navigations)
                    .HasForeignKey(d => d.Type1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pokemon_Type1");

                entity.HasOne(d => d.Type2Navigation)
                    .WithMany(p => p.PokemonType2Navigations)
                    .HasForeignKey(d => d.Type2)
                    .HasConstraintName("FK_Pokemon_Type2");
            });

            modelBuilder.Entity<PokemonGroup>(entity =>
            {
                entity.HasKey(e => e.GroupId);

                entity.Property(e => e.GroupName).HasMaxLength(15);
            });

            modelBuilder.Entity<Rank>(entity =>
            {
                entity.Property(e => e.RankName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RankMapper>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("RankMapper");

                entity.HasOne(d => d.Rank)
                    .WithMany()
                    .HasForeignKey(d => d.RankId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RankMapper_Rank");

                entity.HasOne(d => d.Trainer)
                    .WithMany()
                    .HasForeignKey(d => d.TrainerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RankMapper_Trainer");
            });

            modelBuilder.Entity<ShinyHunt>(entity =>
            {
                entity.HasKey(e => e.ShinyHuntGuid);

                entity.Property(e => e.ShinyHuntGuid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.MethodId).HasDefaultValueSql("((1))");

                entity.Property(e => e.PokemonName).HasMaxLength(20);

                entity.Property(e => e.HuntComplete).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.ShinyHunts)
                    .HasForeignKey(d => d.GameId)
                    .HasConstraintName("FK_ShinyHunt_Game");

                entity.HasOne(d => d.Method)
                    .WithMany(p => p.ShinyHunts)
                    .HasForeignKey(d => d.MethodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShinyHunt_Method");

                entity.HasOne(d => d.Trainer)
                    .WithMany(p => p.ShinyHunts)
                    .HasForeignKey(d => d.TrainerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShinyHunt_Trainer");
            });

            modelBuilder.Entity<ShinyMethod>(entity =>
            {
                entity.Property(e => e.ShinyMethodDescription).HasMaxLength(255);

                entity.Property(e => e.ShinyMethodFirstGen).HasDefaultValueSql("((2))");

                entity.Property(e => e.ShinyMethodName).HasMaxLength(50);
            });

            modelBuilder.Entity<Trainer>(entity =>
            {
                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TrainerName).HasMaxLength(50);
            });

            modelBuilder.Entity<PokemonType>(entity =>
            {
                entity.Property(e => e.TypeId).ValueGeneratedNever();

                entity.Property(e => e.TypeName).HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
