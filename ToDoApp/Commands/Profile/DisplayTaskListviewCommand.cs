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
            else _categoriesPanelVM.IsVisibleListview = false;
        }

        public DisplayTaskListviewCommand(CategoriesPanelViewModel categoriesPanelVM)
        {
            _categoriesPanelVM = categoriesPanelVM;
        }

        public DisplayTaskListviewCommand()
        {
            GetCategoryTaskListFromStore();
        }

        public void GetCategoryTaskListFromStore()
        {
            Guid selectedCategoryId = _categoriesPanelVM.SelectedCategory.CategoryId;
            CategoryTaskModel categoryTaskModel = CategoryTaskStoreService.GetAllTasksForCategory(selectedCategoryId);
            Guid taskId = categoryTaskModel.TaskId;
            TaskModel taskModel = TaskStoreService.FindTask(taskId);
            TaskStoreService.AddToCategoryTaskList(taskModel);
            _categoriesPanelVM.GetCategoryTasksList();
        }
    }
}
