using Microsoft.AspNetCore.Mvc;
using pokedex_back.Domain.Interfaces;
using pokedex_back.Domain.Models.Dtos;

namespace pokedex_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        #region Properties
        private readonly ICommonService _commonService;

        public CommonController(ICommonService commonService)
        {
            _commonService = commonService;
        }
        #endregion

        #region Methods

        #region Dropdowns
        [HttpGet("Dropdown/Ranks")]
        public async Task<ActionResult<List<DropdownDto>>> GetRanksDropdown([FromQuery] string? name)
        {
            return Ok(_commonService.GetRanksDropdown(name));
        }

        [HttpGet("Dropdown/Types")]
        public async Task<ActionResult<List<DropdownDto>>> GetTypesDropdown([FromQuery] string? name)
        {
            return Ok(_commonService.GetTypesDropdown(name));
        }

        [HttpGet("Dropdown/PokemonGroups")]
        public async Task<ActionResult<List<DropdownDto>>> GetPokemonGroupsDropdown([FromQuery] string? name)
        {
            return Ok(_commonService.GetPokemonGroupsDropdown(name));
        }

        [HttpGet("Dropdown/FormGroups")]
        public async Task<ActionResult<List<DropdownDto>>> GetFormGroupsDropdown([FromQuery] string? name)
        {
            return Ok(_commonService.GetFormGroupsDropdown(name));
        }

        [HttpGet("Dropdown/Games")]
        public async Task<ActionResult<List<DropdownDto>>> GetGamesDropdown([FromQuery] string? name)
        {
            return Ok(_commonService.GetGamesDropdown(name));
        }

        [HttpGet("Dropdown/ShinyMethods")]
        public async Task<ActionResult<List<DropdownDto>>> GetShinyMethodsDropdown([FromQuery] string? name)
        {
            return Ok(_commonService.GetShinyMethodsDropdown(name));
        }
        #endregion

        #region Details
        [HttpGet("Detail/Games")]
        public async Task<ActionResult<List<GamesDto>>> GetGamesDetails([FromQuery] int? gameId)
        {
            return Ok(_commonService.GetGamesDetails(gameId));
        }


        [HttpGet("Detail/ShinyMethods")]
        public async Task<ActionResult<List<ShinyMethodsDto>>> GetShinyMethodsDetails([FromQuery] int? shinyMethodId)
        {
            return Ok(_commonService.GetShinyMethodsDetails(shinyMethodId));
        }
        #endregion
        #endregion
    }
}
