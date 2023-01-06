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
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Formatters.Json;
using Microsoft.AspNetCore.JsonPatch;

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
            List<UserResponseDTO> rez = new List<UserResponseDTO>();

            var lista = _userRepository.GetAllAsync();

            foreach (var elem in lista.Result)
            {
                rez.Add(_mapper.Map<UserResponseDTO>(elem));
            }
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

            Debug.WriteLine("haideee");
            // jwt generation
            var jwtToken = _jwtUtils.GenerateJwtToken(user);
            Debug.WriteLine(jwtToken);
            return new UserResponseDTO(user, jwtToken);
        }

        public async Task Create(User newUser)
        {
            await _userRepository.CreateAsync(newUser);
            Debug.WriteLine("hai fa mergi odata");
            await _userRepository.SaveAsync();
        }

        public User GetById(Guid id)
        {
            return _userRepository.FindByIdAsync(id).Result;
        }

        public User GetByUsername(string username)
        {
            return _userRepository.GetByUserName(username);
        }

        public User GetByEmail(string email)
        {
            return _userRepository.GetByEmail(email);
        }

        public bool IsAdmin(string token)
        {
            var userID =  _jwtUtils.ValidateJwtToken(token);
            if (userID == Guid.Empty)
            {
                return false;
            }
            User user = GetById(userID);
            if (user.Role == Models.Enums.Role.Admin)
            {
                return true;
            }
            return false;
        }

        public async Task<Guid> GetPictureID(Guid ID)
        {
            var rez = await _userRepository.FindByIdAsync(ID);
            return rez.PictueID;
        }

        public async Task UpdateUser(string id, string newID)
        {
            var rez =  await _userRepository.UpdateUser(id, newID);
            await _userRepository.SaveAsync();
        }
    }
}
