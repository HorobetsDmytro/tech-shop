using Microsoft.AspNetCore.Mvc;
using tech_shop.Interfaces;
using tech_shop.Models;

namespace tech_shop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            var products = _productRepository.GetAll();
            ViewBag.Categories = _categoryRepository.GetAll();
            return View(products);
        }

        public IActionResult Details(int id)
        {
            var product = _productRepository.GetById(id);

            var categories = _categoryRepository.GetAll();

            ViewBag.Categories = categories;

            return View(product);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = _categoryRepository.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _productRepository.Add(product);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                Console.WriteLine("Помилка");
            }
            ViewBag.Categories = _categoryRepository.GetAll();
            return View(product);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _productRepository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewBag.Categories = _categoryRepository.GetAll();
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _productRepository.Update(product);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categories = _categoryRepository.GetAll();
            return View(product);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = _productRepository.GetById(id);
            //if (product == null)
            //{
            //    return NotFound();
            //}

            var categories = _categoryRepository.GetAll();

            ViewBag.Categories = categories;
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _productRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}