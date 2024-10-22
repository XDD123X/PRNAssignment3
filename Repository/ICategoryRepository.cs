using BusinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ICategoryRepository
    {
        List<Category> GetCategories();

        Category FindCategoryById(int CategoryId);
        void CreateCategory(Category p);
        void UpdateCategory(Category p);
        void DeleteCategory(int id);
    }
}
