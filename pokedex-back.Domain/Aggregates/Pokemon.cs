using System;
using System.Collections.Generic;

namespace pokedex_back.Domain.Aggregates
{
    public partial class Pokemon
    {
        public Guid PokemonGuid { get; set; }
        public int PokemonNumber { get; set; }
        public string PokemonName { get; set; } = null!;
        public int Type1 { get; set; }
        public int? Type2 { get; set; }
        public int Generation { get; set; }
        public bool HasPokemonGroup { get; set; }
        public int? PokemonGroupId { get; set; }
        public int? FormGroupId { get; set; }
        public int? BaseFormNumber { get; set; }

        public virtual FormGroup? FormGroup { get; set; }
        public virtual PokemonGroup? PokemonGroup { get; set; }
        public virtual PokemonType Type1Navigation { get; set; } = null!;
        public virtual PokemonType? Type2Navigation { get; set; }
    }
}
