using DAL.Data;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCryptNet = BCrypt.Net.BCrypt;

namespace DAL.Helpers.Seeders
{
    public class UserSeeder
    {
        public readonly Context context;

        public UserSeeder(Context Context)
        {
            context = Context;
        }

        public void SeedIntialUser()
        {
            if (!context.Users.Any())
            {
                var userDefault = new User
                {
                    Username = "cata",
                    FirstName = "cata",
                    LastName = "cata",
                    Email = "cata.stan11@gmail.com",
                    PasswordHash = BCryptNet.HashPassword("cata"),
                    Role = Models.Enums.Role.Admin,
                    PictueID = new Guid("E465DB68-B244-439C-EB18-08DAEF152B8E")
                };
                Debug.WriteLine("ce cacat");
                context.Users.Add(userDefault);

                context.SaveChanges();
            }
        }
    }
}