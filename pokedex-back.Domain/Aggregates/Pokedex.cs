
namespace pokedex_back.Domain.Aggregates
{
    public partial class Pokedex
    {
        public int Trainer { get; set; }
        public int Pokemon { get; set; }

        public virtual Trainer TrainerNavigation { get; set; } = null!;
    }
}
