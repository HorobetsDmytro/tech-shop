using tech_shop.Models;

namespace tech_shop.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByUsername(string username);
    }
}
