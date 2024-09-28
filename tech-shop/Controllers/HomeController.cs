using Microsoft.AspNetCore.Mvc;
using tech_shop.Interfaces;
using tech_shop.Models;
using System.Linq;

namespace tech_shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository _productRepository;

        public HomeController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult Index(int page = 1)
        {
            int pageSize = 8;
            var allProducts = _productRepository.GetProducts();
            int totalItems = allProducts.Count();
            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            var paginatedProducts = allProducts.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;

            return View(paginatedProducts);
        }

        public IActionResult Details(int id)
        {
            var product = _productRepository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
    }
}