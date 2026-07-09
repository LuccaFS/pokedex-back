
namespace pokedex_back.Domain.Aggregates
{
    public partial class ShinyMethod
    {
        public ShinyMethod()
        {
            ShinyHunts = new HashSet<ShinyHunt>();
        }

        public int ShinyMethodId { get; set; }
        public string ShinyMethodName { get; set; } = null!;
        public string? ShinyMethodDescription { get; set; }
        public int ShinyMethodFirstGame { get; set; }
        public bool IsGameExclusive { get; set; }
        public int? GameId { get; set; }

        public virtual ICollection<ShinyHunt> ShinyHunts { get; set; }
    }
}
