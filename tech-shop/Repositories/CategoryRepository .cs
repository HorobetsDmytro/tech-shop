using tech_shop.Interfaces;
using tech_shop.Models;

namespace tech_shop.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context) { }

        public override void Add(Category category)
        {
            // Додайте логування
            Console.WriteLine($"Adding category: {category.Name}");
            base.Add(category);
            Console.WriteLine("Category added successfully");
        }
    }
}
