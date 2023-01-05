using DAL.Models;
using DAL.Repositories.GenericRepository;
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
    }
}
