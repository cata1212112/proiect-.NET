using DAL.DTOs;
using DAL.Repositories.UserRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services.UserService
{
    public class UserService : IUserService
    {
        public IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<List<UserDTO>> GetAllUsers()
        {
            return _userRepository.GetAllAsync();
        }
    }
}
