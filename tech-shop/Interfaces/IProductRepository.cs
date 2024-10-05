using tech_shop.Models;

namespace tech_shop.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetProductsByCategory(int categoryId);

        IEnumerable<Product> GetProduct();

        IQueryable<Product> SearchProducts(string searchTerm);
    }
}
