using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOs.User
{
    public class UserResponseDTO
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string ProfilePicture { get; set; }

        public string Token { get; set; }
        public bool Admin { get; set; }

        public UserResponseDTO()
        {

        }

        public UserResponseDTO(Models.User user, string token)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
            UserName = user.Username;
            Token = token;
            if (user.Role == Models.Enums.Role.Admin)
            {
                Admin = true;
            } else
            {
                Admin = false;
            }
        }
    }
}
