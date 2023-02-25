using System.Windows.Input;
using ToDoApp.Commands;

namespace ToDoApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public TasksListViewModel TasksListViewModel { get; }
        public FinishedTasksViewModel FinishedTasksViewModel { get; }
        public ProfileViewModel ProfileViewModel { get; }

        private BaseViewModel _selectedViewModel;
        public BaseViewModel SelectedViewModel
        {
            get { return _selectedViewModel; }
            set 
            { 
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }
        public ICommand UpdateViewCommand { get; set; }
        public MainViewModel()
        {
            TasksListViewModel = new TasksListViewModel();
            ProfileViewModel = new ProfileViewModel();
            UpdateViewCommand = new UpdateViewCommand(this);
        }
    }
}
