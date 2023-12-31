using Microsoft.AspNetCore.Mvc;
using ProductManagement.Manager;
using ProductManagement.Models;

namespace ProductManagementService.Controllers
{
    [Route("api/subcategory")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        public readonly ILogger<CategoryController> _logger;
        public readonly ISubCategoryManager _subCategoryManager;

        public SubCategoryController(ISubCategoryManager subCategoryManager, ILogger<CategoryController> logger)
        {
            _subCategoryManager = subCategoryManager;
            _logger = logger;
        }

        [HttpGet]
        [Route("{categoryId:int}")]
        public async Task<IActionResult> Get(int categoryId)
        {
            if (categoryId <= 0)
            {
                _logger.LogWarning("Category identifier value should be greater than zero.");
                throw new Exception();
            }

            List<SubCategory> subCategories = await _subCategoryManager.GetSubCategories(categoryId);
            if (subCategories != null && subCategories.Any())
            {
                _logger.LogInformation($"{subCategories.Count()} :subCategories found");
                return Ok(subCategories);
            }
            else
            {
                _logger.LogInformation($"SubCategories not found");
                return Ok();
            }
        }
    }
}
