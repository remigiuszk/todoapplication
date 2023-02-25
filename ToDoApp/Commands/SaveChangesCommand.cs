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
    public class SaveChangesCommand : CommandBase
    {
        private readonly TasksListViewModel _tasksListVM;
        public override void Execute(object parameter)
        {
            if (_tasksListVM.IsVisibleBoolean == true)
            {
                TaskViewModel editedTask = _tasksListVM.EditTaskViewModel;

                TaskModel editedTaskModel = MappingService.ToTaskModel(editedTask);
                editedTaskModel = new TaskModel
                {
                    Name = _tasksListVM.EditTaskViewModel.TaskTitle,
                    Description = _tasksListVM.EditTaskViewModel.TaskDescription,
                    Value = _tasksListVM.EditTaskViewModel.TaskValue,
                    Id = _tasksListVM.EditTaskViewModel.Id
                };

                Guid editedTaskID = _tasksListVM.EditTaskViewModel.Id;
                TaskModel taskToReplaceModel = TaskStoreService.FindTask(editedTaskID);
                taskToReplaceModel.Name = editedTaskModel.Name;
                taskToReplaceModel.Description = editedTaskModel.Description;
                taskToReplaceModel.Value = editedTaskModel.Value;
                taskToReplaceModel.Id = editedTaskModel.Id;
                _tasksListVM.GetAllTasks();
                _tasksListVM.IsVisibleBoolean = false;
                _tasksListVM.EditTaskViewModel.TaskTitle = string.Empty;
                _tasksListVM.EditTaskViewModel.TaskDescription = string.Empty;
                _tasksListVM.EditTaskViewModel.TaskValue = 0;
            }
            else return;
        }

        public SaveChangesCommand(TasksListViewModel tasksListVM)
        {
            _tasksListVM = tasksListVM;
        }
    }
}
