using AutoMapper;
using DAL.Helpers.JwtUtils;
using DAL.Models;
using DAL.Repositories.PictureRepository;
using DAL.Repositories.UserRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services.PictureService
{
    public class PictureService : IPictureService
    {
        public IPictureRepository PictureRepository { get; set; }

        private readonly string DefaultProfilePicture;

        public PictureService(IPictureRepository _PictureRepository)
        {
            PictureRepository = _PictureRepository;
            DefaultProfilePicture = "D:\\proiect.NET\\proiect-.NET\\backend\\DAL\\Pictures\\DefaultPicture.jfif";
        }

        public async Task<Guid> Create(ProfilePicture newProfilePicture)
        {
            await PictureRepository.CreateAsync(newProfilePicture);
            await PictureRepository.SaveAsync();
            return newProfilePicture.Id;
        }

        public async Task<Guid> InsertDefaultPicture()
        {
            return await Create(new ProfilePicture
            {
                Picture = DefaultProfilePicture,
            });
        }

        public String GetPath(Guid ID)
        {
            return PictureRepository.FindByIdAsync(ID).Result.Picture;
        }

        public async Task DeleteID(Guid id)
        {
            PictureRepository.Delete(PictureRepository.FindByIdAsync(id).Result);
            PictureRepository.SaveAsync();
        }
    }
}
