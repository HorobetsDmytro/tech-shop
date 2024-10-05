using tech_shop.Models;

namespace tech_shop.Interfaces
{
    public interface IShoppingCartRepository
    {
        public ShoppingCart GetCartByUserId(string userId);
        public void AddItem(string userId, int productId);
        public void UpdateQuantity(string userId, int productId, int quantity);
        public void RemoveItem(string userId, int productId);
    }
}
