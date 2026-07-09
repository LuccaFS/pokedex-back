using pokedex_back.Domain.Models.Dtos;
using pokedex_back.Domain.Models.InputDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokedex_back.Domain.Interfaces
{
    public interface IPokemonService
    {
        public void SavePokemon(PokemonInputDto pokemon);
        public List<PokemonDto> GetAll();
        public PokemonDto GetByName(string PokeName);
        public PokemonDto GetById(string PokeId);
        void SaveShinyHunt(ShinyHuntInputDto Hunt);
        List<ShinyHuntDto> GetUserHunts(int UserId);

        List<PokemonDto> GetAndSaveFromAPI(List<PokemonInputDto> pokemons);
    }
}
