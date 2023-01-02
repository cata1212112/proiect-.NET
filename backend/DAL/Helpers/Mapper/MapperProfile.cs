using AutoMapper;
using DAL.DTOs.User;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Helpers.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserResponseDTO>();

            CreateMap<List<User>, List<UserResponseDTO>>();
        }
    }
}
