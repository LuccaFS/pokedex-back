using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using pokedex_back.Domain.Interfaces;
using pokedex_back.Domain.Models.InputDtos;
using pokedex_back.Domain.Models.Dtos;

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
        public IActionResult Register([FromBody] UserRegister user)
        {
            try
            {
                _userService.Create(user);
                return Ok(new ResponseDto()
                {
                    ResponseCode = "OK"
                });
            }
            catch(Exception e)
            {
                return BadRequest(new ResponseDto()
                {
                    ResponseCode = "Error",
                    ResponseMessage = e.Message
                });
            }
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginInputDto login)
        {
            try
            {
                var result = _userService.Login(login, out string msgErr, out string token);
                if (result)
                {
                    var response = new ResponseDto();
                    response.ResponseCode = "OK";
                    response.ResponseMessage = token;
                    return Ok(response);
                }
                else
                {
                    return Unauthorized(new ResponseDto()
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

        ///<summary>
        ///Get user data when authorized
        /// </summary>
        /// <returns></returns>
        
        [HttpGet("GetUser"), Authorize]
        public IActionResult GetUser()
        {
            var user = _userService.getUser();
            return Ok(user);
        }
    }
}
