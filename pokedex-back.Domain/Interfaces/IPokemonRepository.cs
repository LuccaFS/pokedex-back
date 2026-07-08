using pokedex_back.Domain.Models.Dtos;
using pokedex_back.Domain.Models.InputDtos;

namespace pokedex_back.Domain.Interfaces
{
    public interface IPokemonRepository
    {
        void SavePokemon(PokemonDTO_old pokemon);
        List<PokemonDto> GetAll();
        Pokemon GetByName(string PokeName);
        Pokemon GetById(string PokeId);

        void SaveShinyHunt(ShinyHunt Hunt);
        void UpdateShinyHunt(ShinyHunt Hunt);
        ShinyHunt GetShinyHunt(int UserId, string Name);
        List<ShinyHunt> GetUserHunts(int UserId);

        List<PokemonDto> GetAndSaveFromAPI(List<PokemonInputDto> pokemons);
    }
}
