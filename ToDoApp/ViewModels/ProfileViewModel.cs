using System.Windows.Input;
using ToDoApp.Commands;

namespace ToDoApp.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {
        public ICommand DisplayContentCommand { get; }
        public ICommand AddCategoryCommand { get; }

        private bool _isVisibleCategories;
        public bool IsVisibleCategories
        {
            get { return _isVisibleCategories; }
            set
            {
                _isVisibleCategories = value;
                OnPropertyChanged(nameof(IsVisibleCategories));
            }
        }

        private bool _isVisibleAdd;
        public bool IsVisibleAdd
        {
            get { return _isVisibleAdd; }
            set
            {
                _isVisibleAdd = value;
                OnPropertyChanged(nameof(IsVisibleAdd));
            }
        }

        public ProfileViewModel()
        {
            DisplayContentCommand = new DisplayContentCommand(this);
            AddCategoryCommand = new AddCategoryCommand(this);
        }
    }
}
