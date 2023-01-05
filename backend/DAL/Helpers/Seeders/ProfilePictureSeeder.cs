using AutoMapper;
using DAL.Data;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Helpers.Seeders
{
    public class ProfilePictureSeeder
    {
        public readonly Context context;

        public ProfilePictureSeeder(Context Context)
        {
            context = Context;
        }

        public void SeedIntialPicture()
        {
            Debug.WriteLine("aicici");
            if (!context.ProfilePictures.Any())
            {
                var profileDefaultPicture = new ProfilePicture
                {
                    Picture = "D:\\proiect.NET\\proiect-.NET\\backend\\DAL\\Pictures\\DefaultPicture.jfif",
                };
                Debug.WriteLine("ce cacat"); 
                context.ProfilePictures.Add(profileDefaultPicture);

                context.SaveChanges();
            }
        }
    }
}
