using ProductManagement.Models;

namespace ProductManagement.Repository
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetCategories();
    }
}
