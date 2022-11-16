using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using pokedex_back.Domain.Models;
using pokedex_back.Domain.Interfaces;

namespace pokedex_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessController : ControllerBase
    {
        private readonly IUserService _userService;

        public AccessController(IUserService userService)
        {
            _userService = userService;
        }   

        [HttpPost("Register")]
        public IActionResult Register([FromBody] UserDto user)
        {
            try
            {
                _userService.Create(user);
                return Ok(new ResponseModel()
                {
                    ResponseCode = "OK"
                });
            }
            catch(Exception e)
            {
                return BadRequest(new ResponseModel()
                {
                    ResponseCode = "Error",
                    ResponseMessage = e.Message
                });
            }
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginModel login)
        {
            try
            {
                var result = _userService.Login(login, out string msgErr, out string token);
                if (result)
                {
                    var response = new ResponseModel();
                    response.ResponseCode = "OK";
                    response.ResponseMessage = token;
                    return Ok(response);
                }
                else
                {
                    return Unauthorized(new ResponseModel()
                    {
                        ResponseCode = "ERR",
                        ResponseMessage = msgErr
                    });
                }
            }
            catch(Exception e)
            {
                return BadRequest("Error: " + e.Message);
            }
        }

        /// <summary>
        /// Gets user name when authorized
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetName"), Authorize]
        public IActionResult GetName()
        {   
            var user = _userService.GetName();
            return Ok(new ResponseModel()
            {
                ResponseCode = "OK",
                ResponseMessage = user
            });
        }

        [HttpGet("GetRank"), Authorize]
        public IActionResult GetRank()
        {
            var user = _userService.GetRank();
            return Ok(new ResponseModel()
            {
                ResponseCode = "OK",
                ResponseMessage = user
            });
        }
    }
}
