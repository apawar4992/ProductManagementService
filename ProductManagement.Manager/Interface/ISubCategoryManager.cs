using ProductManagement.Models;

namespace ProductManagement.Manager
{
    public interface ISubCategoryManager
    {
        Task<List<SubCategory>> GetSubCategories(int categoryId);
    }
}
