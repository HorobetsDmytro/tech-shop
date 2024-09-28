using tech_shop.Interfaces;
using tech_shop.Models;

namespace tech_shop.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context) { }

        public IEnumerable<Order> GetOrdersByUser(string userId)
        {
            return _dbSet.Where(o => o.UserId == userId).ToList();
        }
    }
}
