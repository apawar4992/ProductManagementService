using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProductManagement.Models;
using ProductManagement.Repository.Models;

namespace ProductManagement.Repository
{
    public class SubCategoryRepository : ISubCategoryRepository
    {
        public readonly ILogger<SubCategoryRepository> _logger;
        public SubCategoryRepository(ILogger<SubCategoryRepository> logger)
        {
            _logger = logger;
        }

        public async Task<List<SubCategory>> GetSubCategories(int categoryId)
        {
            List<SubCategory> categories = new List<SubCategory>();
            try
            {
                List<SubCategoryRecord> subCategoryRecords;
                using (ProductManagementSystemContext context = new ProductManagementSystemContext())
                {
                    subCategoryRecords = await context.SubCategories.Where(x=>x.CategoryId == categoryId).ToListAsync();
                }

                if (subCategoryRecords != null)
                {
                    subCategoryRecords.ForEach(item =>
                    {
                        categories.Add(new SubCategory()
                        {
                            Name = item.Name,
                            Id = item.Id,
                            CategoryId = categoryId,
                        });
                    });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception occoured in sub category repository:" + ex.Message, ex);
            }

            return categories;
        }
    }
}
