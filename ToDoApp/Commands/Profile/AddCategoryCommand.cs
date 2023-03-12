using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml;
using ToDoApp.Commands.Profile;
using ToDoApp.Models;
using ToDoApp.Services;
using ToDoApp.ViewModels;

namespace ToDoApp.Commands
{
    public class AddCategoryCommand : CommandBase
    {
        private readonly CategoriesPanelViewModel _categoriesVM;
        public override void Execute(object parameter)
        {
            if ((_categoriesVM.NewCategoryVM.Name != string.Empty && _categoriesVM.NewCategoryVM.Name != null)
                && (_categoriesVM.NewCategoryVM.Hashtag != string.Empty && _categoriesVM.NewCategoryVM.Hashtag != null))
            {
                CategoryModel newCategory = new CategoryModel
                {
                    CategoryId = Guid.NewGuid(),
                    Name = _categoriesVM.NewCategoryVM.Name,
                    Hashtag = _categoriesVM.NewCategoryVM.Hashtag,
                    CategoryDate = _categoriesVM.NewCategoryVM.CategoryDate,
                };
                CategoryStoreService.AddCategory(newCategory);
                _categoriesVM.GetCategories();
                _categoriesVM.NewCategoryVM.Name = string.Empty;
                _categoriesVM.NewCategoryVM.Hashtag = string.Empty;
                _categoriesVM.NewCategoryVM.CategoryDate = DateTime.Now;
                _categoriesVM.IsVisibleAddPanel = false;
                _categoriesVM.IsVisibleListview = false;
            }
        }

        public AddCategoryCommand(CategoriesPanelViewModel categoriesVM)
        {
            _categoriesVM = categoriesVM;
        }
    }
}
