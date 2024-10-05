using Microsoft.EntityFrameworkCore;
using tech_shop.Interfaces;
using tech_shop.Models;


namespace tech_shop.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly ApplicationDbContext _context;

        public ShoppingCartRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ShoppingCart GetCartByUserId(string userId)
        {
            return _context.ShoppingCarts
                .Include(c => c.Items)
                .ThenInclude(i => i.Product)
                .FirstOrDefault(c => c.UserId == userId) ?? CreateCart(userId);
        }

        public void AddItem(string userId, int productId)
        {
            var cart = GetCartByUserId(userId);
            var item = cart.Items.FirstOrDefault(i => i.ProductId == productId);

            if (item == null)
            {
                item = new ShoppingCartItem { ProductId = productId, Quantity = 1 };
                cart.Items.Add(item);
            }
            else
            {
                item.Quantity++;
            }

            _context.SaveChanges();
        }

        public void UpdateQuantity(string userId, int productId, int quantity)
        {
            var cart = GetCartByUserId(userId);
            var item = cart.Items.FirstOrDefault(i => i.ProductId == productId);

            if (item != null)
            {
                item.Quantity = quantity;
                _context.SaveChanges();
            }
        }

        public void RemoveItem(string userId, int productId)
        {
            var cart = GetCartByUserId(userId);
            var item = cart.Items.FirstOrDefault(i => i.ProductId == productId);

            if (item != null)
            {
                cart.Items.Remove(item);
                _context.SaveChanges();
            }
        }

        private ShoppingCart CreateCart(string userId)
        {
            var cart = new ShoppingCart { UserId = userId };
            _context.ShoppingCarts.Add(cart);
            _context.SaveChanges();
            return cart;
        }
    }
}
