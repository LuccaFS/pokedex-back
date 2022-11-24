using pokedex_back.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokedex_back.Domain.Interfaces
{
    public interface IPokemonService
    {
        public void SavePokemon(PokemonDTO pokemon);
        public List<Pokemon> GetAll();
        public Pokemon GetByName(string PokeName);
        public Pokemon GetById(string PokeId);
    }
}
