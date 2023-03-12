using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Models;

namespace ToDoApp.Services
{
    public class CategoryStoreService
    {
        private static CategoryStoreService _instance;
        public static CategoryStoreService Instance()
        {
            if (_instance == null)
            {
                _instance = new CategoryStoreService();
            }
            return _instance;
        }

        private List<CategoryModel> _categoryList;

        public CategoryStoreService()
        {
            _categoryList = new List<CategoryModel>();
            CategoryModel startingCategory = new CategoryModel();
            startingCategory.Name = "My Category";
            startingCategory.Hashtag = "#hashtag";
            startingCategory.CategoryId = Guid.NewGuid();
            startingCategory.CategoryDate = DateTime.Now;
            _categoryList.Add(startingCategory);
        }

        public static void AddCategory(CategoryModel _newCategory)
        {
            Instance()._categoryList.Add(_newCategory);
        }

        public static List<CategoryModel> ReturnAllCategories()
        {
            return Instance()._categoryList;
        }

        public static CategoryModel GetCategoryByDescription(string taskDescription)
        {
            CategoryModel searchedCategory = Instance()._categoryList.FirstOrDefault
                (category => category.Hashtag == taskDescription);
            return searchedCategory;
        }
    }
}
