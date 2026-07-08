using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using pokedex_back.Domain.Interfaces;
using pokedex_back.Domain.Models.Dtos;
using pokedex_back.Domain.Models.InputDtos;

namespace pokedex_back.Service.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IConfiguration _config;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PokemonService(IPokemonRepository pokemonRepository, IConfiguration config, IHttpContextAccessor httpContextAccessor)
        {
            _pokemonRepository = pokemonRepository;
            _config = config;
            _httpContextAccessor = httpContextAccessor;
        }

        #region ' Pokedex '
        public void SavePokemon(PokemonInputDto pokemon)
        {
            _pokemonRepository.SavePokemon(pokemon);
        }

        public List<PokemonDto> GetAll()
        {
            return _pokemonRepository.GetAll();
        }

        public PokemonDto GetByName(string PokeName)
        {
            return _pokemonRepository.GetByName(PokeName);
        }

        public PokemonDto GetById(string PokeName)
        {
            return _pokemonRepository.GetById(PokeName);
        }
        #endregion


        #region ' Shiny Hunt '
        public void SaveShinyHunt(ShinyHuntInputDto Hunt)
        {
            _pokemonRepository.SaveShinyHunt(Hunt);
        }

        public List<ShinyHuntDto> GetUserHunts(int UserId)
        {
            return _pokemonRepository.GetUserHunts(UserId);
        }
        #endregion

        #region 'PokeAPI'
        public List<PokemonDto> GetAndSaveFromAPI(List<PokemonInputDto> pokemons)
        {
            return _pokemonRepository.GetAndSaveFromAPI(pokemons);
        }
        #endregion

    }
}
