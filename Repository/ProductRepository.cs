using BusinessObject.Model;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        public void DeleteProduct(int id) => ProductDAO.DeleteProduct(id);

        public Product FindProductById(int productId) => ProductDAO.FindProductById(productId);


        public List<Product> GetProducts() => ProductDAO.GetProducts();

        public void CreateProduct(Product p) => ProductDAO.CreateProduct(p);

        public void UpdateProduct(Product p) => ProductDAO.UpdateProduct(p);

        public List<Product> FindProductByKey(string key) => ProductDAO.FindProductByKey(key);

        public List<Product> FindProductByPrice(decimal? minPrice, decimal? maxPrice) => ProductDAO.FindProductByPrice(minPrice, maxPrice);
    }
}
