using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ToDoApp.Models;
using ToDoApp.Services;
using ToDoApp.ViewModels;

namespace ToDoApp.Commands.Profile
{
    public class DisplayTaskListviewCommand : CommandBase
    {
        private readonly CategoriesPanelViewModel _categoriesPanelVM;
 
        public override void Execute(object parameter)
        {
            if (_categoriesPanelVM.IsVisibleListview == false)
            {
                _categoriesPanelVM.IsVisibleListview = true;
                GetCategoryTaskListFromStore();
            }
            else
            {
                _categoriesPanelVM.IsVisibleListview = false;
                RemoveCategoryTaskListFromStore();
            }
        }

        public DisplayTaskListviewCommand(CategoriesPanelViewModel categoriesPanelVM)
        {
            _categoriesPanelVM = categoriesPanelVM;
        }

        public DisplayTaskListviewCommand()
        {
            
        }

        public void GetCategoryTaskListFromStore()
        {
            Guid selectedCategoryId = _categoriesPanelVM.SelectedCategory.CategoryId;
            List<CategoryTaskModel> categoryTaskList = CategoryTaskStoreService.GetAllTasksForCategory(selectedCategoryId);
            foreach (CategoryTaskModel task in categoryTaskList)
            {
                Guid categoryTaskId = task.TaskId;
                TaskModel taskModel = TaskStoreService.FindTask(categoryTaskId);
                TaskStoreService.AddToCategoryTaskList(taskModel);
            }
            _categoriesPanelVM.GetCategoryTaskList();
        }

        public void RemoveCategoryTaskListFromStore()
        {
            Guid selectedCategoryId = _categoriesPanelVM.SelectedCategory.CategoryId;
            List<CategoryTaskModel> categoryTaskList = CategoryTaskStoreService.GetAllTasksForCategory(selectedCategoryId);
            foreach (CategoryTaskModel task in categoryTaskList)
            {
                Guid categoryTaskId = task.TaskId;
                TaskModel taskModel = TaskStoreService.FindTask(categoryTaskId);
                TaskStoreService.RemoveFromCategoryTaskList(taskModel);
            }
        }
    }
}
