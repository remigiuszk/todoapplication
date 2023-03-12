using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.ViewModels;

namespace ToDoApp.Commands
{
    public class ExitTaskEditingCommand : CommandBase
    {
        private readonly TasksListViewModel _tasksListVM;
        public override void Execute(object parameter)
        {
            _tasksListVM.IsVisibleBoolean = false;
        }

        public ExitTaskEditingCommand(TasksListViewModel tasksListVM)
        {
            _tasksListVM = tasksListVM;
        }
    }
}
