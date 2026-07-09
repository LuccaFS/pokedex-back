
namespace pokedex_back.Domain.Aggregates
{
    public partial class FormGroup
    {
        public FormGroup()
        {
            Pokemons = new HashSet<Pokemon>();
        }

        public int FormGroupId { get; set; }
        public string FormGroupName { get; set; } = null!;

        public virtual ICollection<Pokemon> Pokemons { get; set; }
    }
}
