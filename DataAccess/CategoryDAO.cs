using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    using BusinessObject.Model;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace DataAccess
    {
        public class CategoryDAO
        {
            public static List<Category> GetCategorys()
            {
                var listCategorys = new List<Category>();
                try
                {
                    using (var context = new MyStoreDBContext())
                    {
                        listCategorys = context.Categories
                            .ToList();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                return listCategorys;
            }
            public static Category FindCategoryById(int CategoryId)
            {
                Category p = new Category();
                try
                {
                    using (var context = new MyStoreDBContext())
                    {
                        p = context.Categories
                            .SingleOrDefault(x => x.CategoryId == CategoryId);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                return p;
            }
            public static void CreateCategory(Category p)
            {
                try
                {
                    using (var context = new MyStoreDBContext())
                    {
                        context.Categories.Add(p);
                        context.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            public static void UpdateCategory(Category p)
            {
                try
                {
                    using (var context = new MyStoreDBContext())
                    {
                        context.Entry<Category>(p).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        context.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            public static void DeleteCategory(int id)
            {
                try
                {
                    using (var context = new MyStoreDBContext())
                    {
                        var Category = context.Categories
                            .SingleOrDefault(x => x.CategoryId == id);

                        if (Category != null)
                        {
                            context.Categories.Remove(Category);
                            context.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("Category not found.");
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

}
