using tech_shop.Models;

namespace tech_shop.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        IEnumerable<Order> GetOrdersByUser(string userId);
    }
}
