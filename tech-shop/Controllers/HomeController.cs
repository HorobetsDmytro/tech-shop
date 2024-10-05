using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tech_shop.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using tech_shop.Models;

namespace tech_shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public HomeController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index(int page = 1, string sortOrder = "", int? categoryId = null,
                                   double? minPrice = null, double? maxPrice = null, string searchTerm = "")
        {
            int pageSize = 8;
            var query = string.IsNullOrWhiteSpace(searchTerm)
            ? _productRepository.GetProduct()
            : _productRepository.SearchProducts(searchTerm);



            // Фільтрація за категорією
            if (categoryId.HasValue)
            {
                query = query.Where(p => p.CategoryId == categoryId.Value);
            }

            // Фільтрація за ціною
            if (minPrice.HasValue)
            {
                query = query.Where(p => p.Price >= minPrice.Value);
            }
            if (maxPrice.HasValue)
            {
                query = query.Where(p => p.Price <= maxPrice.Value);
            }

            // Сортування
            switch (sortOrder)
            {
                case "price_asc":
                    query = query.OrderBy(p => p.Price);
                    break;
                case "price_desc":
                    query = query.OrderByDescending(p => p.Price);
                    break;
                default:
                    query = query.OrderBy(p => p.Name);
                    break;
            }

            int totalItems = query.Count();
            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            var paginatedProducts = query.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.SortOrder = sortOrder;
            ViewBag.CategoryId = categoryId;
            ViewBag.MinPrice = minPrice;
            ViewBag.MaxPrice = maxPrice;
            ViewBag.SearchTerm = searchTerm;
            ViewBag.Categories = _categoryRepository.GetAll();

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