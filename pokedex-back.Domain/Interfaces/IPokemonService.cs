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
        public void SavePokemon(PokemonDTO_old pokemon);
        public List<PokemonDto> GetAll();
        public Pokemon GetByName(string PokeName);
        public Pokemon GetById(string PokeId);
        void SaveShinyHunt(ShinyHunt Hunt);
        List<ShinyHunt> GetUserHunts(int UserId);

        List<PokemonDto> GetAndSaveFromAPI(List<PokemonInputDto> pokemons);
    }
}
