using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProductManagement.Models;
using ProductManagement.Repository.Models;

namespace ProductManagement.Repository
{
    public class ProductRepository : IProductRepository
    {
        public readonly ILogger<ProductRepository> _logger;
        public ProductRepository(ILogger<ProductRepository> logger)
        {
            _logger = logger;
        }

        public async Task<List<Product>> GetProducts(int subCategoryId)
        {
            List<Product> products = new List<Product>();
            try
            {
                List<ProductRecord> productRecords;
                using (ProductManagementSystemContext context = new ProductManagementSystemContext())
                {
                    productRecords = await context.Products.Where(item => item.SubCategoryId == subCategoryId).ToListAsync();
                }

                if (productRecords != null)
                {
                    productRecords.ForEach(item =>
                    {
                        products.Add(new Product()
                        {
                            Name = item.Name,
                            ProductCode = item.ProductCode,
                            Price = item.Price,
                            Quantity = item.Quantity,
                            Description = item.Description,
                            Image = item.Image,
                        });
                    });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception occoured in product repository:" + ex.Message, ex);
            }

            return products;
        }
    }
}