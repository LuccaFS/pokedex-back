using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokedex_back.Domain.Models
{
    public class PokemonDTO
    {
        public int IdPokemon { get; set; }
        public string DsName { get; set; }
        public int Type1 { get; set; }
        public int? Type2 { get; set; }
        public string Image { get; set; }
        public int Generation { get; set; }
        public bool IsStarter { get; set; }
        public bool IsPseudo { get; set; }
        public bool IsLegendary { get; set; }

    }

    public class Pokemon
    {
        public int IdPokemon { get; set; }
        public string DsName { get; set; }
        public string Type1 { get; set; }
        public string? Type2 { get; set; }
        public string Image { get; set; }
        public int Generation { get; set; }
        public bool IsStarter { get; set; }
        public bool IsPseudo { get; set; }
        public bool IsLegendary { get; set; }

    }
}
