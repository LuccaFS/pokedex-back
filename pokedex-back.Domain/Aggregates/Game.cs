
namespace pokedex_back.Domain.Aggregates
{
    public partial class Game
    {
        public Game()
        {
            ShinyHunts = new HashSet<ShinyHunt>();
        }

        public int GameId { get; set; }
        public string GameNames { get; set; } = null!;
        public int ReleaseGeneration { get; set; }
        public bool IsRemake { get; set; }
        public int? OriginalGeneration { get; set; }

        public virtual ICollection<ShinyHunt> ShinyHunts { get; set; }
    }
}
