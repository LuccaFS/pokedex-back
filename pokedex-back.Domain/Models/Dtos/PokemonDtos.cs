using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokedex_back.Domain.Models.Dtos
{
    public class PokemonDTO_old
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
        public int Type1 { get; set; }
        public int? Type2 { get; set; }
        public string Image { get; set; }
        public int Generation { get; set; }
        public bool IsStarter { get; set; }
        public bool IsPseudo { get; set; }
        public bool IsLegendary { get; set; }

    }

    public class ShinyHunt
    {
        public int IdTrainer { get; set; }
        public string PokeName { get; set; }
        public int Counter { get; set; }
    }


    public class PokemonDto
    {
        public Guid PokemonGuid { get; init; }
        public int PokemonNumber { get; set; }
        public string PokemonName { get; set; }
        public int Type1 { get; set; }
        public int? Type2 { get; set; }
        public int Generation { get; set; }
        public bool HasPokemonGroup { get; set; }
        public int? PokemonGroupId { get; set; }
        public int? FormGroupId { get; set; }
        public int? BaseFormNumber { get; set; }
    }
}
