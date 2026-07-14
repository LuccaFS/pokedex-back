using pokedex_back.Domain.Interfaces;
using pokedex_back.Domain.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokedex_back.Service.Services
{
    public class CommonService : ICommonService
    {
        private readonly ICommonRepository _commonRepository;

        public CommonService(ICommonRepository commonRepository)
        {
            _commonRepository = commonRepository;
        }

        public List<DropdownDto> GetRanksDropdown(string? name = null)
        {
            return _commonRepository.GetRanksDropdown(name);
        }

        public List<DropdownDto> GetTypesDropdown(string? name = null)
        {
            return _commonRepository.GetTypesDropdown(name);
        }

        public List<DropdownDto> GetPokemonGroupsDropdown(string? name = null)
        {
            return _commonRepository.GetPokemonGroupsDropdown(name);
        }

        public List<DropdownDto> GetFormGroupsDropdown(string? name = null)
        {
            return _commonRepository.GetFormGroupsDropdown(name);
        }

        public List<DropdownDto> GetGamesDropdown(string? name = null)
        {
            return _commonRepository.GetGamesDropdown(name);
        }

        public List<DropdownDto> GetShinyMethodsDropdown(string? name = null)
        {
            return _commonRepository.GetShinyMethodsDropdown(name);
        }

        public List<GamesDto> GetGamesDetails(int? gameId)
        {
            return _commonRepository.GetGamesDetails(gameId);
        }

        public List<ShinyMethodsDto> GetShinyMethodsDetails(int? shinyMethodId)
        {
            return _commonRepository.GetShinyMethodsDetails(shinyMethodId);
        }
    }
}
