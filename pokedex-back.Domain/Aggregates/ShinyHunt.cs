
namespace pokedex_back.Domain.Aggregates
{
    public partial class ShinyHunt
    {
        public Guid ShinyHuntGuid { get; set; }
        public int TrainerId { get; set; }
        public int PokemonNumber { get; set; }
        public string PokemonName { get; set; } = null!;
        public int EncounterCount { get; set; }
        public int? PhaseCount { get; set; }
        public int? GameId { get; set; }
        public bool HasShinyCharm { get; set; }
        public int MethodId { get; set; }
        public bool HuntComplete { get; set; }

        public virtual Game? Game { get; set; }
        public virtual ShinyMethod Method { get; set; } = null!;
        public virtual Trainer Trainer { get; set; } = null!;
    }
}
