using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.ViewModels;

namespace ToDoApp.Commands
{
    public class DisplayContentCommand : CommandBase
    {
        private readonly ProfileViewModel _profileVM;
        public override void Execute(object parameter)
        {
            if (_profileVM.IsVisibleCategories == false)
            {
                _profileVM.IsVisibleCategories = true;
            }
            else
            {
                _profileVM.IsVisibleCategories = false;
                _profileVM.IsVisibleAdd = false;
            }
            
        }

        public DisplayContentCommand(ProfileViewModel profileVM)
        {
            _profileVM = profileVM;
        }
    }
}
