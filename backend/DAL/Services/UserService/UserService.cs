using DAL.DTOs;
using DAL.DTOs.User;
using DAL.Models;
using DAL.Repositories.UserRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BCryptNet = BCrypt.Net.BCrypt;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Helpers.JwtUtils;

namespace DAL.Services.UserService
{
    public class UserService : IUserService
    {
        public IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private IJwtUtils _jwtUtils;

        public UserService(IUserRepository userRepository, IJwtUtils jwtUtils, IMapper mapper)
        {
            _userRepository = userRepository;
            _jwtUtils = jwtUtils;
            _mapper = mapper;
        }

        public List<UserResponseDTO> GetAllUsers()
        {
            List<UserResponseDTO> rez = _mapper.Map<List<UserResponseDTO>>(_userRepository.GetAllAsync());
            return rez;
        }

        public UserResponseDTO GetByUserName(string username)
        {
            UserResponseDTO rez = _mapper.Map<UserResponseDTO>(_userRepository.GetByUserName(username));
            return rez;
        }

        public UserResponseDTO Atuhentificate(UserAuthDTO model)
        {
            var user = _userRepository.GetByUserName(model.UserName);
            if (user == null || !BCryptNet.Verify(model.Password, user.PasswordHash))
            {
                return null; //or throw exception
            }


            // jwt generation
            var jwtToken = _jwtUtils.GenerateJwtToken(user);
            return new UserResponseDTO(user, jwtToken);
        }

        public async Task Create(User newUser)
        {
            await _userRepository.CreateAsync(newUser);
            await _userRepository.SaveAsync();
        }

        public User GetById(Guid id)
        {
            return _userRepository.FindByIdAsync(id).Result;
        }
    }
}
