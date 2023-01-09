using DAL.DTOs;
using DAL.DTOs.User;
using DAL.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services.UserService
{
    public interface IUserService
    {
        Tuple<List<UserAdminResponseDTO>, List<UserAdminResponseDTO>> GetAllUsers();

        UserResponseDTO Atuhentificate(UserAuthDTO model);
        Task Create(User newUser);
        User GetById(Guid id);

        User GetByUsername(string username);
        User GetByEmail(string email);

        Task<Guid> GetPictureID(Guid ID);

        bool IsAdmin(string token);
        Task UpdateUser(string id, string newID);

        Task DeleteUser(string id);

        public Task MakeAdmin(string id);
    }
}
