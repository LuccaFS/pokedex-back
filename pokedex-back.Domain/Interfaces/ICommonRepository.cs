using pokedex_back.Domain.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokedex_back.Domain.Interfaces
{
    public interface ICommonRepository
    {
        List<DropdownDto> GetRanksDropdown(string? name = null);
        List<DropdownDto> GetTypesDropdown(string? name = null);
        List<DropdownDto> GetPokemonGroupsDropdown(string? name = null);
        List<DropdownDto> GetFormGroupsDropdown(string? name = null);
        List<DropdownDto> GetGamesDropdown(string? name = null);
        List<DropdownDto> GetShinyMethodsDropdown(string? name = null);
    }
}
