using BusinessObject.Model;
using DataAccess;
using DataAccess.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public void CreateCategory(Category p) => CategoryDAO.CreateCategory(p);


        public void DeleteCategory(int id) => CategoryDAO.DeleteCategory(id);


        public Category FindCategoryById(int CategoryId) => CategoryDAO.FindCategoryById(CategoryId);

        public List<Category> GetCategories() => CategoryDAO.GetCategorys();

        public void UpdateCategory(Category p) => CategoryDAO.UpdateCategory(p);

    }
}
