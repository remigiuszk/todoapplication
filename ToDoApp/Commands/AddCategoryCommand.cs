using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.ViewModels;

namespace ToDoApp.Commands
{
    public class AddCategoryCommand : CommandBase
    {
        private readonly ProfileViewModel _profileVM;
        public override void Execute(object parameter)
        {
            if (_profileVM.IsVisibleAdd == false)
            {
                _profileVM.IsVisibleAdd = true;
            }
            else _profileVM.IsVisibleAdd = false;
        }

        public AddCategoryCommand(ProfileViewModel profileVM)
        {
            _profileVM = profileVM;
        }
    }
}
