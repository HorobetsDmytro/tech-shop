using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using tech_shop.Interfaces;
using tech_shop.Models;
using System.Security.Claims;

namespace tech_shop.Controllers
{
    [Authorize]
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartRepository _cartRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public ShoppingCartController(IShoppingCartRepository cartRepository, IProductRepository productRepository, IOrderRepository orderRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cart = _cartRepository.GetCartByUserId(userId);
            return View(cart);
        }

        [HttpPost]
        public IActionResult AddToCart(int productId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var product = _productRepository.GetById(productId);

            if (product == null)
            {
                return Json(new { success = false, message = "Product not found." });
            }

            try
            {
                _cartRepository.AddItem(userId, productId);
                return Json(new { success = true, message = "Product added to cart successfully!" });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding product to cart: {ex.Message}");
                return Json(new { success = false, message = "Error adding product to cart. Please try again." });
            }
        }

        [HttpPost]
        public IActionResult UpdateQuantity(int productId, int quantity)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var product = _productRepository.GetById(productId);

            if (product == null)
            {
                return NotFound();
            }

            if (quantity > product.StockQuantity)
            {
                ModelState.AddModelError("", "Requested quantity exceeds available stock.");
                return BadRequest(ModelState);
            }

            _cartRepository.UpdateQuantity(userId, productId, quantity);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int productId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _cartRepository.RemoveItem(userId, productId);

            return RedirectToAction("Index");
        }
    }
}
