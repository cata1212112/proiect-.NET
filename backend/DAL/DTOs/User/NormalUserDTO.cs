using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOs.User
{
    public class NormalUserDTO
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }

        public string ProfilePicture { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public NormalUserDTO(Guid id, string username, string _ProfilePicture, string firstname, string lastname)
        {
            Id = id;
            UserName = username;
            ProfilePicture = _ProfilePicture;
            FirstName = firstname;
            LastName = lastname;
        }
    }
}
