using Azure;
using DAL.Data;
using DAL.Models;
using DAL.Repositories.GenericRepository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;

namespace DAL.Repositories.UserRepository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(Context context) : base(context)
        {
        }

        public User GetByEmail(string email)
        {
            return _table.FirstOrDefault(x => x.Email.Equals(email));
        }

        public User GetByUserName(string username)
        {
            return _table.FirstOrDefault(x => x.Username.Equals(username));
        }

        public async Task<User> UpdateUser(string id, string newID)
        {
            var userToUpdate = await _table.FirstOrDefaultAsync(usr => usr.Id.Equals(new Guid(id)));
            userToUpdate.PictueID = new Guid(newID);
            return userToUpdate;
        }
    }
}
