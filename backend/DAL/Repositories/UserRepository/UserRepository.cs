using DAL.Data;
using DAL.Models;
using DAL.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.UserRepository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(Context context) : base(context)
        {
        }

        public User GetByUserName(string username)
        {
            return _table.FirstOrDefault(x => x.Username.Equals(username));
        }
    }
}
