using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services.PictureService
{
    public interface IPictureService
    {
        Task<Guid> Create(ProfilePicture newProfilePicture);

        Task<Guid> InsertDefaultPicture();
    }
}
