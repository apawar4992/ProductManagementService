using ProductManagement.Models;

namespace ProductManagement.Repository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProducts(int subcategoryId);
    }
}
