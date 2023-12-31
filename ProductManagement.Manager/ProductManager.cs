using Microsoft.Extensions.Logging;
using ProductManagement.Models;
using ProductManagement.Repository;

namespace ProductManagement.Manager
{
    public class ProductManager : IProductManager
    {
        public readonly IProductRepository _productRespository;
        public readonly ILogger<ProductManager> _logger;
        public ProductManager(IProductRepository productRespository, ILogger<ProductManager> logger)
        {
            _logger = logger;
            _productRespository = productRespository;
        }

        public async Task<List<Product>> GetProducts(int subcategoryId)
        {
            _logger.LogInformation($"Receieved: request in manager with subcategory identifier: {subcategoryId}");
            return await _productRespository.GetProducts(subcategoryId);
        }
    }
}