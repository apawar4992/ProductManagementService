using ProductManagement.Models;

namespace ProductManagement.Manager
{
    public interface ICategoryManager
    {
        Task<List<Category>> GetCategories();
    }
}
