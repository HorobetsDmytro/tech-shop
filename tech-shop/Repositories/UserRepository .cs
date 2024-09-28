using tech_shop.Interfaces;
using tech_shop.Models;

namespace tech_shop.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context) { }

        public User GetByUsername(string username)
        {
            return _dbSet.FirstOrDefault(u => u.UserName == username);
        }
    }
}
