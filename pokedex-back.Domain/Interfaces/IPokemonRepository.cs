using pokedex_back.Domain.Models;

namespace pokedex_back.Domain.Interfaces
{
    public interface IPokemonRepository
    {
        void SavePokemon(PokemonDTO pokemon);
        List<Pokemon> GetAll();
        Pokemon GetByName(string PokeName);
        Pokemon GetById(string PokeId);

        void SaveShinyHunt(ShinyHunt Hunt);
        void UpdateShinyHunt(ShinyHunt Hunt);
        ShinyHunt GetShinyHunt(int UserId, string Name);
        List<ShinyHunt> GetUserHunts(int UserId);
    }
}
