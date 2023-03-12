using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.ViewModels;

namespace ToDoApp.Commands.Profile
{
    public class SelectDateCommand : CommandBase
    {
        private readonly CategoriesPanelViewModel _categoriesPanelVM;

        public override void Execute(object parameter)
        {
        }

        public SelectDateCommand(CategoriesPanelViewModel categoriesPanelVM)
        {
            _categoriesPanelVM = categoriesPanelVM;
        }
    }
}
