using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOs.User
{
    public class UserAdminResponseDTO
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string ProfilePicture { get; set; }

        public UserAdminResponseDTO(Guid id, string username, string email, string firstname, string lastname, string _ProfilePicture)
        {
            Id = id;
            UserName = username;
            Email = email;
            LastName = lastname;
            FirstName = firstname;
            ProfilePicture = _ProfilePicture;
        }
    }
}
