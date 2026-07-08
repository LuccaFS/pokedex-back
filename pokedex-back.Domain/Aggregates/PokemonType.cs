
namespace pokedex_back.Domain.Aggregates
{
    public partial class PokemonType
    {
        public PokemonType()
        {
            PokemonType1Navigations = new HashSet<Pokemon>();
            PokemonType2Navigations = new HashSet<Pokemon>();
        }

        public int TypeId { get; set; }
        public string? TypeName { get; set; }

        public virtual ICollection<Pokemon> PokemonType1Navigations { get; set; }
        public virtual ICollection<Pokemon> PokemonType2Navigations { get; set; }
    }
}
