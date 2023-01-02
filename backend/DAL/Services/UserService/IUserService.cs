using DAL.DTOs;
using DAL.DTOs.User;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services.UserService
{
    public interface IUserService
    {
        List<UserResponseDTO> GetAllUsers();

        UserResponseDTO Atuhentificate(UserAuthDTO model);
        Task Create(User newUser);
        User GetById(Guid id);
    }
}
