using DAL.Models;
using DAL.Repositories.GenericRepository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.UserRepository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public User GetByUserName(string username);

        public User GetByEmail(string email);
        public Task<User> UpdateUser(string id, string newID);
    }
}
