
namespace pokedex_back.Domain.Aggregates
{
    public partial class RankMapper
    {
        public int TrainerId { get; set; }
        public int RankId { get; set; }

        public virtual Rank Rank { get; set; } = null!;
        public virtual Trainer Trainer { get; set; } = null!;
    }
}
