using tech_shop.Models;

namespace tech_shop.Interfaces
{
    public interface IOrderItemRepository : IRepository<OrderItem>
    {
        IEnumerable<OrderItem> GetOrderItemsByOrder(int orderId);
    }
}
