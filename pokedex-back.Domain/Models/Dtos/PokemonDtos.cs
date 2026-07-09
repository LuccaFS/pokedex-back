using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokedex_back.Domain.Models.Dtos
{
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

    public class ShinyHuntDto {
        public Guid ShinyHuntGuid { get; set; }
        public int TrainerId { get; set; }
        public int PokemonNumber { get; set; }
        public string PokemonName { get; set; } = null!;
        public int EncounterCount { get; set; }
        public int? PhaseCount { get; set; }
        public int? GameId { get; set; }
        public bool HasShinyCharm { get; set; }
        public int MethodId { get; set; }
    }
}
