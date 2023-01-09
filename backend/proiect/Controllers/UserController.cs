using Azure;
using DAL.DTOs.User;
using DAL.Helpers.Attributes;
using DAL.Models;
using DAL.Models.Enums;
using DAL.Services.PictureService;
using DAL.Services.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Encodings.Web;
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
            if (user.PictureID.Equals(String.Empty))
            {
                userToCreate.PictueID = _pictureService.InsertDefaultPicture().Result;
            } else
            {
                userToCreate.PictueID = new Guid(user.PictureID);
            }
            Debug.WriteLine(userToCreate.PictueID);
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
            response.ProfilePicture = _pictureService.GetPath(_userService.GetPictureID(response.Id).Result);
            return Ok(response);
        }

        [Authorization(Role.Admin)]
        [HttpGet("allusersadmin")]
        public IActionResult GetAllUsers()
        {
            return Ok(_userService.GetAllUsers());
        }

        /* [HttpGet("user/{id}")]
         public IActionResult GetUser(string path)
         {
             return Ok(_userService.GetById(id));
         }*/

        [HttpGet("users")] 
        public IActionResult GetUsers()
        {
            return Ok(_userService.GetAllUsersBasic());
        }

        [HttpGet("user")]
        public IActionResult GetUserByName([FromQuery] string username)
        {
            var rez = _userService.GetByUsername(username);
            Debug.WriteLine(rez == null);

            return Ok(rez);
        }

        [HttpGet("userid")]
        public IActionResult GetUserIdByName([FromQuery] string username)
        {
            var rez = _userService.GetByUsername(username);
            Debug.WriteLine(rez == null);

            return Ok(rez.Id);
        }

        [HttpGet("isamdin")]
        public IActionResult CheckIfAdmin([FromQuery] string token)
        {
            var rez = _userService.IsAdmin(token);
            return Ok(rez);
        }

        [HttpPatch("changepicture/{id}/{newId}")]
        public async Task<IActionResult> ChangeProfilePicture([FromRoute] string id, [FromRoute] string newId)
        {
             Guid oldPhoto = _userService.GetPictureID(new Guid(id)).Result;
             await _userService.UpdateUser(id, newId);
             var rasp = _pictureService.GetPath(_userService.GetPictureID(new Guid(id)).Result);
             await _pictureService.DeleteID(oldPhoto);
             return Ok(System.Text.Encoding.UTF8.GetBytes(rasp));
        }

        [Authorization(Role.Admin)]
        [HttpPatch("makeAdmin")]
        public async Task<IActionResult> MakeAdmin([FromHeader] string id)
        {
            _userService.MakeAdmin(id);
            return Ok();
        }

        [Authorization(Role.Admin)]
        [HttpDelete("deleteid")]
        public async Task<IActionResult> DeleteUserById([FromHeader] string ID)
        {
            Guid pictureId = _userService.GetPictureID(new Guid(ID)).Result;
            await _userService.DeleteUser(ID);
            Debug.WriteLine("idul pozei este");
            Debug.WriteLine(pictureId);
            await _pictureService.DeleteID(pictureId);

            return Ok();
        }
    }
}
