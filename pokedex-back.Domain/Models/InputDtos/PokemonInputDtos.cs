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
