using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokedex_back.Domain.Models.InputDtos;

public class PokemonInputDto
{
    public int PokemonNumber { get; set; }
    public string PokemonName { get; set; }
    public int Type1 { get; set; }
    public int? Type2 { get; set; } = null;
    public int Generation { get; set; }
    public bool HasPokemonGroup { get; set; }
    public int? PokemonGroupId { get; set; } = null;
    public int? FormGroupId { get; set; } = null;
    public int? BaseFormNumber { get; set; } = null;
}

public class ShinyHuntInputDto
{
    public int TrainerId { get; set; }
    public int PokemonNumber { get; set; }
    public string PokemonName { get; set; } = null!;
    public int EncounterCount { get; set; }
    public int? PhaseCount { get; set; } = null;
    public int? GameId { get; set; } = null;
    public bool HasShinyCharm { get; set; }
    public int MethodId { get; set; }
}

public class GetShinyHuntInputDto
{
    public int TrainerId { get; set; }
    public int? PokemonNumber { get; set; } = null;
    public int? GameId { get; set; } = null;
    public int? MethodId { get; set; } = null;
}
