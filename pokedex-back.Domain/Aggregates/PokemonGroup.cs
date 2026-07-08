
namespace pokedex_back.Domain.Aggregates
{
    public partial class PokemonGroup
    {
        public PokemonGroup()
        {
            Pokemons = new HashSet<Pokemon>();
        }

        public int GroupId { get; set; }
        public string GroupName { get; set; } = null!;

        public virtual ICollection<Pokemon> Pokemons { get; set; }
    }
}
