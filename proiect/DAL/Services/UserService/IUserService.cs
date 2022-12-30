using DAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services.UserService
{
    public interface IUserService
    {
        Task<List<UserDTO>> GetAllUsers();
    }
}
