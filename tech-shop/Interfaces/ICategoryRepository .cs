using tech_shop.Models;

namespace tech_shop.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        // Додаткові методи, якщо потрібно
        IEnumerable<Category> GetCategories();
    }
}
