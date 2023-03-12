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
    public class EditTaskCommand : CommandBase
    {
        private readonly TasksListViewModel _tasksListVM;
        public override void Execute(object parameter)
        {
            if (_tasksListVM.SelectedTask != null)
            {
                _tasksListVM.EditTaskViewModel = _tasksListVM.SelectedTask;

                TaskModel copiedTaskModel = new TaskModel
                {
                    Name = _tasksListVM.SelectedTask.TaskTitle,
                    Description = _tasksListVM.SelectedTask.TaskDescription,
                    Value = _tasksListVM.SelectedTask.TaskValue,
                    TaskId = _tasksListVM.SelectedTask.TaskId
                };

                var copiedTaskViewModel = MappingService.ToTaskViewModel(copiedTaskModel);
                _tasksListVM.EditTaskViewModel = copiedTaskViewModel;
                _tasksListVM.IsVisibleBoolean = true;
                _tasksListVM.GetAllTasks();
            }
            else return;
        }

        public EditTaskCommand(TasksListViewModel tasksListVM)
        {
            _tasksListVM = tasksListVM;
        }
    }
}
