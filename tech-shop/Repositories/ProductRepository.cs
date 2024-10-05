using tech_shop.Interfaces;
using tech_shop.Models;

namespace tech_shop.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context) { }

        public IEnumerable<Product> GetProductsByCategory(int categoryId)
        {
            return _dbSet.Where(p => p.CategoryId == categoryId).ToList();
        }

        public override void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public IEnumerable<Product> GetProduct()
        {
            return _context.Products.ToList();
        }
        
        public IQueryable<Product> GetProducts()
        {
            return _context.Products.AsQueryable();
        }

        public IQueryable<Product> SearchProducts(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return GetProducts();

            return _context.Products.Where(p => p.Name.Contains(searchTerm));
        }
    }
}
