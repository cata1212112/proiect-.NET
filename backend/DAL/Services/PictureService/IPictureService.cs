using DAL.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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

        String GetPath(Guid ID);

        Task DeleteID(Guid id);
    }
}
