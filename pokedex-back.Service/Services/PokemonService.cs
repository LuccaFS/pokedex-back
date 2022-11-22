using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using pokedex_back.Domain.Interfaces;
using pokedex_back.Domain.Models;

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

        public void SavePokemon(PokemonDTO pokemon)
        {
            _pokemonRepository.SavePokemon(pokemon);
        }


        public List<Pokemon> GetAll()
        {
            return _pokemonRepository.GetAll();
        }

        public Pokemon GetByName(string PokeName)
        {
            return _pokemonRepository.GetByName(PokeName);
        }

    }
}
