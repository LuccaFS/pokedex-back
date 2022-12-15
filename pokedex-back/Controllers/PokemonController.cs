using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pokedex_back.Domain.Models;
using pokedex_back.Domain.Interfaces;

namespace pokedex_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService _pokedexService;

        public PokemonController(IPokemonService pokedexService)
        {
            _pokedexService = pokedexService;
        }

        [HttpPost("Save")]
        public IActionResult Save([FromBody] PokemonDTO pokemon)
        {
            try
            {
                _pokedexService.SavePokemon(pokemon);
                return Ok(new ResponseModel()
                {
                    ResponseCode = "OK"
                });
            }
            catch (Exception e)
            {
                return BadRequest(new ResponseModel()
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
                List<Pokemon> pokemons = _pokedexService.GetAll();
                return Ok(pokemons);
            }
            catch (Exception e)
            {
                return BadRequest(new ResponseModel()
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
                Pokemon pokemon = _pokedexService.GetByName(PokeName);
                return Ok(pokemon);
            }
            catch (Exception e)
            {
                return BadRequest(new ResponseModel()
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
                Pokemon pokemon = _pokedexService.GetById(PokeId);
                return Ok(pokemon);
            }
            catch (Exception e)
            {
                return BadRequest(new ResponseModel()
                {
                    ResponseCode = "Error",
                    ResponseMessage = e.Message
                });
            }
        }

        [HttpPost("Shiny/Save")]
        public IActionResult SaveShiny([FromBody] ShinyHunt pokemon)
        {
            try
            {
                _pokedexService.SaveShinyHunt(pokemon);
                return Ok(new ResponseModel()
                {
                    ResponseCode = "OK"
                });
            }
            catch (Exception e)
            {
                return BadRequest(new ResponseModel()
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
                List<ShinyHunt> pokemons = _pokedexService.GetUserHunts(idTrainer);
                return Ok(pokemons);
            }
            catch (Exception e)
            {
                return BadRequest(new ResponseModel()
                {
                    ResponseCode = "Error",
                    ResponseMessage = e.Message
                });
            }
        }

    }
}
