using Microsoft.AspNetCore.Mvc;
using ProductManagement.Manager;
using ProductManagement.Models;

namespace ProductManagementService.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public readonly ILogger<CategoryController> _logger;
        public readonly ICategoryManager _categoryManager;

        public CategoryController(ICategoryManager categoryManager, ILogger<CategoryController> logger)
        {
            _categoryManager = categoryManager;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Category> categories = await _categoryManager.GetCategories();
            if (categories != null && categories.Any())
            {
                _logger.LogInformation($"{categories.Count()} :categories found");
                return Ok(categories);
            }
            else
            {
                _logger.LogInformation($"Categories not found");
                return Ok();
            }
        }
    }
}
