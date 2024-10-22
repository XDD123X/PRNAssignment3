
using BusinessObject.Model;
namespace Repositories
{
    public interface IProductRepository
    {
        List<Product> GetProducts();

        Product FindProductById(int productId);
        List<Product> FindProductByKey(string key);
        List<Product> FindProductByPrice(decimal? minPrice, decimal? maxPrice);
        void CreateProduct(Product p);
        void UpdateProduct(Product p);
        void DeleteProduct(int id);
    }
}
