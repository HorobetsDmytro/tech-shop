using tech_shop.Interfaces;
using tech_shop.Models;

namespace tech_shop.Repositories
{
    public class OrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(ApplicationDbContext context) : base(context) { }

        public IEnumerable<OrderItem> GetOrderItemsByOrder(int orderId)
        {
            return _dbSet.Where(oi => oi.OrderId == orderId).ToList();
        }
    }
}
