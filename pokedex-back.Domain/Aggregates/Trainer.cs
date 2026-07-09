
namespace pokedex_back.Domain.Aggregates
{
    public partial class Trainer
    {
        public Trainer()
        {
            ShinyHunts = new HashSet<ShinyHunt>();
        }

        public int TrainerId { get; set; }
        public string TrainerName { get; set; } = null!;
        public string TrainerEmail { get; set; } = null!;
        public string TrainerPassword { get; set; } = null!;
        public string TrainerSalt { get; set; } = null!;
        public bool? IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<ShinyHunt> ShinyHunts { get; set; }
    }
}
