using Microsoft.Extensions.Logging;
using ProductManagement.Models;
using ProductManagement.Repository;

namespace ProductManagement.Manager
{
    public class SubCategoryManager : ISubCategoryManager
    {
        public readonly ILogger<SubCategoryManager> _logger;
        public readonly ISubCategoryRepository _subCategoryRepository;

        public SubCategoryManager(ISubCategoryRepository subCategoryRepository, ILogger<SubCategoryManager> logger)
        {
            _subCategoryRepository = subCategoryRepository;
            _logger = logger;
        }

        public async Task<List<SubCategory>> GetSubCategories(int categoryId)
        {
            return await _subCategoryRepository.GetSubCategories(categoryId);
        }
    }
}
