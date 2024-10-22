using BusinessObject.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProductDAO
    {
        public static List<Product> GetProducts()
        {
            var listProducts = new List<Product>();
            try
            {
                using (var context = new MyStoreDBContext())
                {
                    listProducts = context.Products
                        .Include(b => b.Category)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listProducts;
        }
        public static List<Product> FindProductByKey(string key)
        {
            var listProducts = new List<Product>();
            try
            {
                using (var context = new MyStoreDBContext())
                {
                    listProducts = context.Products
                        .Where(p => p.ProductName.Contains(key, StringComparison.CurrentCultureIgnoreCase))
                        .Include(b => b.Category)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listProducts;
        }
        public static Product FindProductById(int ProductId)
        {
            Product p = new Product();
            try
            {
                using (var context = new MyStoreDBContext())
                {
                    p = context.Products
                         .Include(b => b.Category)
                        .SingleOrDefault(x => x.ProductId == ProductId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return p;
        }
        public static List<Product> FindProductByPrice(decimal? minPrice, decimal? maxPrice)
        {
            var listProducts = new List<Product>();
            try
            {
                using (var context = new MyStoreDBContext())
                {
                    listProducts = context.Products
                        .Include(b => b.Category)
                        .ToList();
                    if(maxPrice != null)
                    {
                        listProducts = listProducts
                            .Where(p => p.UnitPrice < maxPrice)
                            .ToList();
                    }
                    if (minPrice != null)
                    {
                        listProducts = listProducts
                            .Where(p => p.UnitPrice > minPrice)
                            .ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listProducts;
        }
        public static void CreateProduct(Product p)
        {
            try
            {
                using (var context = new MyStoreDBContext())
                {
                    context.Products.Add(p);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static   void UpdateProduct(Product p)
        {
            try
            {
                using (var context = new MyStoreDBContext())
                {
                    context.Entry<Product>(p).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void DeleteProduct(int id)
        {
            try
            {
                using (var context = new MyStoreDBContext())
                {
                    var Product = context.Products
                        .SingleOrDefault(x => x.ProductId == id);

                    if (Product != null)
                    {
                        context.Products.Remove(Product);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Product not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
