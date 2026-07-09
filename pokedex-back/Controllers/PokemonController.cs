using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pokedex_back.Domain.Interfaces;
using pokedex_back.Domain.Models.Dtos;
using pokedex_back.Domain.Models.InputDtos;

namespace pokedex_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService _pokemonService;

        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        [HttpPost("Save"), Authorize]
        public IActionResult Save([FromBody] PokemonInputDto pokemon)
        {
            try
            {
                _pokemonService.SavePokemon(pokemon);
                return Ok(new ResponseDto()
                {
                    ResponseCode = "OK"
                });
            }
            catch (Exception e)
            {
                return BadRequest(new ResponseDto()
                {
                    ResponseCode = "Error",
                    ResponseMessage = e.Message
                });
            }
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                List<PokemonDto> pokemons = _pokemonService.GetAll();
                return Ok(pokemons);
            }
            catch (Exception e)
            {
                return BadRequest(new ResponseDto()
                {
                    ResponseCode = "Error",
                    ResponseMessage = e.Message
                });
            }
        }

        [HttpGet("GetByName")]
        public IActionResult GetByName([FromQuery] string PokeName)
        {
            try
            {
                PokemonDto pokemon = _pokemonService.GetByName(PokeName);
                return Ok(pokemon);
            }
            catch (Exception e)
            {
                return BadRequest(new ResponseDto()
                {
                    ResponseCode = "Error",
                    ResponseMessage = e.Message
                });
            }
        }


        [HttpGet("GetById")]
        public IActionResult GetById([FromQuery] string PokeId)
        {
            try
            {
                PokemonDto pokemon = _pokemonService.GetById(PokeId);
                return Ok(pokemon);
            }
            catch (Exception e)
            {
                return BadRequest(new ResponseDto()
                {
                    ResponseCode = "Error",
                    ResponseMessage = e.Message
                });
            }
        }

        #region 'Shiny Hunt'
        [HttpPost("Shiny/Save"), Authorize]
        public IActionResult SaveShiny([FromBody] ShinyHuntInputDto pokemon)
        {
            try
            {
                _pokemonService.SaveShinyHunt(pokemon);
                return Ok(new ResponseDto()
                {
                    ResponseCode = "OK"
                });
            }
            catch (Exception e)
            {
                return BadRequest(new ResponseDto()
                {
                    ResponseCode = "Error",
                    ResponseMessage = e.Message
                });
            }
        }

        [HttpGet("Shiny/GetTrainerHunts")]
        public IActionResult GetShinyHunts([FromQuery] int idTrainer)
        {
            try
            {
                List<ShinyHuntDto> pokemons = _pokemonService.GetUserHunts(idTrainer);
                return Ok(pokemons);
            }
            catch (Exception e)
            {
                return BadRequest(new ResponseDto()
                {
                    ResponseCode = "Error",
                    ResponseMessage = e.Message
                });
            }
        }
        #endregion

        [HttpPost("SaveFromApi")]
        public async Task<ActionResult<List<PokemonDto>>> GetAndSaveFromAPI(List<PokemonInputDto> pokemons)
        {
            return Ok(_pokemonService.GetAndSaveFromAPI(pokemons));
        }
    }
}
