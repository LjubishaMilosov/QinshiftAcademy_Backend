using System.Data;
using Microsoft.AspNetCore.Mvc;
using NotesApp.DTOs;
using NotesApp.Services.Implementation;
using NotesApp.Services.Interfaces;

namespace NotesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService; 
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterUserDto registerUserDto)
        {
            try
            {
                _userService.RegisterUser(registerUserDto);
                return Ok("User registered successfully.");
            }
            catch (DataException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpPost("login")]
        public ActionResult<string> Login([FromBody] LoginUserDto loginUserDto)
        {
            try
            {
                var result = _userService.Login(loginUserDto);
                return Ok("user loggedin.");
            }
            catch (DataException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
