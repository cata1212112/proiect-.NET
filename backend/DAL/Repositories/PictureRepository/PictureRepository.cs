using DAL.Data;
using DAL.Models;
using DAL.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.PictureRepository
{
    public class PictureRepository : GenericRepository<ProfilePicture>, IPictureRepository
    {
        public PictureRepository(Context context) : base(context)
        {
        }
    }
}
