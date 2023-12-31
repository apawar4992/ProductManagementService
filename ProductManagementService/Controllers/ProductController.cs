using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProductManagement.Manager;
using ProductManagement.Models;

namespace ProductManagementService.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        public readonly ILogger<ProductController> _logger;
        public readonly IProductManager _productManager;

        public ProductController(IProductManager productManager, ILogger<ProductController> logger)
        {
            _logger = logger;
            _productManager = productManager;
        }

        [HttpGet]
        [Route("{subCategoryId:int}")]
        public async Task<IActionResult> GetAsync(int subCategoryId)
        {
            List<Product> products;
            if (subCategoryId <= 0)
            {
                _logger.LogWarning("SubCategory identifier value should be greater than zero.");
                throw new Exception();
            }

            // call
            products = await _productManager.GetProducts(subCategoryId);
            if (products != null && products.Any())
            {
                _logger.LogInformation($"The products for specified sub category identifier: {subCategoryId} found");
                return Ok(products);
            }
            else
            {
                _logger.LogInformation($"The products for specified sub category identifier: {subCategoryId} not found");
                return Ok();
            }
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            //try
            //{
            return Ok();
            //}
            //catch (Exception)
            //{
            //    _logger.Log(LogLevel.Error, "Exception occoured in Get products");
            //}
        }

        [HttpPut]
        //[Route("{subCategoryId:int}")]
        [Route("{productCode}")]
        public IActionResult Update([FromBody] Product product, [FromQuery]string productCode)
        {
            //try
            //{

            //}
            //catch (Exception)
            //{
            //    _logger.Log(LogLevel.Error, "Exception occoured in Get products");
            //}

            return Ok();
        }

        [HttpDelete]
        [Route("{productCode}")]
        public IActionResult Delete(string productCode)
        {
            //try
            //{
            if (productCode.IsNullOrEmpty())
            {
                return BadRequest();
            }
            //}
            //catch (Exception)
            //{
            //    _logger.Log(LogLevel.Error, "Exception occoured in Get products");
            //}

            return Ok();
        }
    }
}