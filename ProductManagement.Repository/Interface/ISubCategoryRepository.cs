using ProductManagement.Models;

namespace ProductManagement.Repository
{
    public interface ISubCategoryRepository
    {
        Task<List<SubCategory>> GetSubCategories(int categoryId);
    }
}
