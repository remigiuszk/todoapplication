using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Models;
using ToDoApp.Services;
using ToDoApp.ViewModels;

namespace ToDoApp.Commands
{
    public class RemoveTaskCommand : CommandBase
    {
        private readonly TasksListViewModel _tasksListVM;

        public override void Execute(object parameter)
        {
            if (_tasksListVM.Counter > 1)
            {
                Guid removeTaskID = _tasksListVM.SelectedTask.TaskId;
                TaskModel taskModel = TaskStoreService.FindTask(removeTaskID);
                CategoryModel categoryOfTask = CategoryStoreService.GetCategoryByDescription(taskModel.Description);
                CategoryTaskModel taskToRemove = new CategoryTaskModel
                {
                    CategoryId = categoryOfTask.CategoryId,
                    TaskId = taskModel.TaskId,
                };
                CategoryTaskStoreService.RemoveCategoryTask(taskToRemove);
                TaskStoreService.RemoveTask(removeTaskID);
                _tasksListVM.GetAllTasks();
            }
            else return;
        }

        public RemoveTaskCommand(TasksListViewModel tasksListVM)
        {
            _tasksListVM = tasksListVM;
        }
    }
}
