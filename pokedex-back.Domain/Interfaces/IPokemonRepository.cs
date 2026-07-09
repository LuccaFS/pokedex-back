using pokedex_back.Domain.Models.Dtos;
using pokedex_back.Domain.Models.InputDtos;

namespace pokedex_back.Domain.Interfaces
{
    public interface IPokemonRepository
    {
        void SavePokemon(PokemonInputDto pokemon);
        List<PokemonDto> GetAll();
        PokemonDto GetByName(string PokeName);
        PokemonDto GetById(string PokeId);

        void SaveShinyHunt(ShinyHuntInputDto Hunt);
        void UpdateShinyHunt(ShinyHuntInputDto Hunt);
        ShinyHuntDto GetShinyHunt(GetShinyHuntInputDto Hunt);
        List<ShinyHuntDto> GetUserHunts(int UserId);

        List<PokemonDto> GetAndSaveFromAPI(List<PokemonInputDto> pokemons);
    }
}
