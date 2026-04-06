using WebApplication5.Models;

namespace WebApplication5.Services
{
    public interface IProductService
    {

        IEnumerable<Product> GetProducts();
        Product GetProduct(int id);
        void CreateProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
    }
}
