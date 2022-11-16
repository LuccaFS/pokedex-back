using pokedex_back.Domain.Models;

namespace pokedex_back.Domain.Interfaces
{
    public interface IPokemonRepository
    {
        void SavePokemon(PokemonDTO pokemon);
        public List<Pokemon> GetAll();
    }
}
