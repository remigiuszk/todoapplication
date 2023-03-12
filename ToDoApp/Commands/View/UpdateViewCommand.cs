﻿using ToDoApp.ViewModels;

namespace ToDoApp.Commands
{
    public class UpdateViewCommand : CommandBase
    {
        private MainViewModel viewModel;

        public UpdateViewCommand(MainViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            if (parameter.ToString() == "Profile")
            {
                viewModel.SelectedViewModel = new ProfileViewModel();
            }
            else if (parameter.ToString() == "Tasks")
            {
                viewModel.SelectedViewModel = new TasksListViewModel();
            }
            else if (parameter.ToString() == "FinishedTasks")
            {
                viewModel.SelectedViewModel = new FinishedTasksViewModel();
            }
            else if (parameter.ToString() == "Categories")
            {
                    viewModel.SelectedViewModel = new CategoriesPanelViewModel();
            }
            else if (parameter.ToString() == "Settings")
            {
                viewModel.SelectedViewModel = new SettingsViewModel();
            }
        }
    }
}
