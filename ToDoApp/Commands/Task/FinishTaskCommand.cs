using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Models;
using ToDoApp.Services;
using ToDoApp.ViewModels;

namespace ToDoApp.Commands
{
    public class FinishTaskCommand : CommandBase
    {
        private readonly TasksListViewModel _tasksListVM;
        public override void Execute(object parameter)
        {
            if (_tasksListVM.TasksList.Count > 0 && _tasksListVM.SelectedTask != null)
            {
                Guid selectedTaskID = _tasksListVM.SelectedTask.TaskId;
                TaskModel returnedTaskModel = TaskStoreService.FindTask(selectedTaskID);
                returnedTaskModel.IsCompleted = true;
                _tasksListVM.GetAllTasks();
            }
        }

        public FinishTaskCommand(TasksListViewModel tasksListVM)
        {
            _tasksListVM = tasksListVM;
        }
    }
}
