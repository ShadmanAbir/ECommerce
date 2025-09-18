using ECommerce.API.Models;

namespace ECommerce.API.Services
{
    public class CategoryService
    {
        private readonly ECommerceContext _context;
        public CategoryService(ECommerceContext context)
        {
            _context = context;
        }
        public List<Category> categories { get; set; }

        public Category GetCategoryById(int id)
        {

        }

        public Category addCategory(string name)
        {
        }

        public Category UpdateCategory(string name)
        {
        }

        public void DeleteCategory(int id)
        {
        }

    }
}
