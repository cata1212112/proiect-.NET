using DAL.DTOs.User;
using DAL.Helpers.Attributes;
using DAL.Models;
using DAL.Models.Enums;
using DAL.Services.PictureService;
using DAL.Services.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BCryptNet = BCrypt.Net.BCrypt;

namespace proiect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserService _userService;
        public readonly IPictureService _pictureService;

        public UserController(IUserService userService, IPictureService pictureService)
        {
            _userService = userService;
            _pictureService = pictureService;
        }

        [HttpPost("create-user")]
        public async Task<IActionResult> CreateUser([FromBody] UserRequestDTO user)
        {
            var userToCreate = new User
            {
                Username = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Role = Role.User,
                Email = user.Email,
                PasswordHash = BCryptNet.HashPassword(user.Password),
            };
            if (user.PicturePath.Equals(String.Empty))
            {
                userToCreate.PictueID = _pictureService.InsertDefaultPicture().Result;
            }
            if (_userService.GetByUsername(userToCreate.Username) != null || _userService.GetByEmail(userToCreate.Email) != null) {
                return BadRequest("Exista cineva cu usernameul sau emailul tau!");
            }
            await _userService.Create(userToCreate);
            return Ok();
        }

        [HttpPost("create-admin")]
        public async Task<IActionResult> CreateAdmin(UserRequestDTO user)
        {
            var userToCreate = new User
            {
                Username = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Role = Role.Admin,
                Email = user.Email,
                PasswordHash = BCryptNet.HashPassword(user.Password)
            };

            await _userService.Create(userToCreate);
            return Ok();
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(UserAuthDTO user)
        {
            Debug.WriteLine("ma autentific");
            var response =  _userService.Atuhentificate(user);
            if (response == null)
            {
                return BadRequest("Username or password is invalid!");
            }
            return Ok(response);
        }

        [Authorization(Role.Admin)]
        [HttpGet("allusers")]
        public IActionResult GetAllUsers()
        {
            return Ok(_userService.GetAllUsers());
        }

        [HttpGet("user/{id}")]
        public IActionResult GetUser(Guid id)
        {
            return Ok(_userService.GetById(id));
        }

        [HttpGet("user")]
        public IActionResult GetUserByName([FromQuery] string username)
        {
            var rez = _userService.GetByUsername(username);
            Debug.WriteLine(rez == null);

            return Ok(rez);
        }

        [HttpGet("isamdin")]
        public IActionResult CheckIfAdmin([FromQuery] string token)
        {
            var rez = _userService.IsAdmin(token);
            return Ok(rez);
        }
    }
}
