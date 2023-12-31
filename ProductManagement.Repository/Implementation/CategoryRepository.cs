using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProductManagement.Models;
using ProductManagement.Repository.Models;

namespace ProductManagement.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        public readonly ILogger<CategoryRepository> _logger;
        public CategoryRepository(ILogger<CategoryRepository> logger)
        {
            _logger = logger;
        }

        public async Task<List<Category>> GetCategories()
        {
            List<Category> categories = new List<Category>();
            try
            {
                List<CategoryRecord> categoryRecords;
                using (ProductManagementSystemContext context = new ProductManagementSystemContext())
                {
                    categoryRecords = await context.Categories.ToListAsync();
                }

                if (categoryRecords != null)
                {
                    categoryRecords.ForEach(item =>
                    {
                        categories.Add(new Category()
                        {
                            Name = item.Name,
                            Id = item.Id,
                        });
                    });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception occoured in category repository:" + ex.Message, ex);
            }

            return categories;
        }
    }
}
