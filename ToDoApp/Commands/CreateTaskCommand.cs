using System;
using ToDoApp.Models;
using ToDoApp.Services;
using ToDoApp.ViewModels;

namespace ToDoApp.Commands
{
    public class CreateTaskCommand : CommandBase
    {
        private readonly TasksListViewModel _tasksListVM;

        public override void Execute(object parameter)
        {
            if (_tasksListVM.NewTaskViewModel.TaskTitle != string.Empty && _tasksListVM.NewTaskViewModel.TaskDescription
                != string.Empty && _tasksListVM.NewTaskViewModel.TaskValue != 0)
            {
                TaskModel newTask = new TaskModel()
                {
                    Id = Guid.NewGuid(),
                    Name = _tasksListVM.NewTaskViewModel.TaskTitle,
                    Description = _tasksListVM.NewTaskViewModel.TaskDescription,
                    Value = _tasksListVM.NewTaskViewModel.TaskValue,
                    IsCompleted = false
                };

                TaskStoreService.AddNewTask(newTask);
                _tasksListVM.GetAllTasks();
                _tasksListVM.NewTaskViewModel.TaskTitle = string.Empty;
                _tasksListVM.NewTaskViewModel.TaskDescription = string.Empty;
                _tasksListVM.NewTaskViewModel.TaskValue = 0;
            }
            else return;
        }

        public CreateTaskCommand(TasksListViewModel tasksListVM)
        {
            _tasksListVM = tasksListVM;
        }
    }
}
