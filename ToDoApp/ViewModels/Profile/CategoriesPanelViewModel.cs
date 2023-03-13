using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ToDoApp.Commands;
using ToDoApp.Commands.Profile;
using ToDoApp.Models;
using ToDoApp.Services;
using ToDoApp.ViewModels.Profile;

namespace ToDoApp.ViewModels
{
    public class CategoriesPanelViewModel : BaseViewModel
    {
        public ICommand DisplayCategoriesCommand { get; }
        public ICommand AddCategoryCommand { get; }
        public ICommand DisplayAddPanelCommand { get; }
        public ICommand ShowCalendarCommand { get; }
        public ICommand DisplayTaskListviewCommand { get; }

        #region Categories booleans properties

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

        private bool _isVisibleAddPanel;
        public bool IsVisibleAddPanel
        {
            get { return _isVisibleAddPanel; }
            set
            {
                _isVisibleAddPanel = value;
                OnPropertyChanged(nameof(IsVisibleAddPanel));
            }
        }

        private bool _isVisibleCalendar;
        public bool IsVisibleCalendar
        {
            get { return _isVisibleCalendar; }
            set
            {
                _isVisibleCalendar = value;
                OnPropertyChanged(nameof(IsVisibleCalendar));
            }
        }

        private bool _isVisibleListview;
        public bool IsVisibleListview
        {
            get { return _isVisibleListview; }
            set
            {
                _isVisibleListview = value;
                OnPropertyChanged(nameof(IsVisibleListview));
            }
        }
        #endregion

        private CategoryViewModel _newCategoryVM;
        public CategoryViewModel NewCategoryVM
        {
            get { return _newCategoryVM; }
            set
            {
                _newCategoryVM = value;
                OnPropertyChanged(nameof(NewCategoryVM));
            }
        }

        private CategoryViewModel _selectedCategory;
        public CategoryViewModel SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                _selectedCategory = value;
                OnPropertyChanged(nameof(SelectedCategory));
            }
        }

        private ObservableCollection<CategoryViewModel> _categoryList;
        public ObservableCollection<CategoryViewModel> CategoryList
        {
            get { return _categoryList; }
            set
            {
                _categoryList = value;
                OnPropertyChanged(nameof(CategoryList));
            }
        }

        private ObservableCollection<TaskViewModel> _categoryTasksList;
        public ObservableCollection<TaskViewModel> CategoryTasksList
        {
            get { return _categoryTasksList; }
            set 
            { 
                _categoryTasksList = value;
                OnPropertyChanged(nameof(CategoryTasksList));
            }
        }

        //public ICommand CreateTaskCommand { get; }

        public CategoriesPanelViewModel()
        {
            DisplayCategoriesCommand = new DisplayCategoriesCommand(this);
            DisplayAddPanelCommand = new DisplayAddPanelCommand(this);
            AddCategoryCommand = new AddCategoryCommand(this);
            DisplayTaskListviewCommand = new DisplayTaskListviewCommand(this);
            //CreateTaskCommand = new CreateTaskCommand(this);
            _newCategoryVM = new CategoryViewModel();
            _categoryList = new ObservableCollection<CategoryViewModel>();
            _selectedCategory = new CategoryViewModel();
            _categoryTasksList = new ObservableCollection<TaskViewModel>();
            GetCategories();
        }

        public void GetCategories()
        {
            CategoryList.Clear();

            var categories = CategoryStoreService.ReturnAllCategories();
            foreach (CategoryModel categoryModel in categories)
            {
                CategoryViewModel categoryVM = MappingService.ToCategoryViewModel(categoryModel);
                CategoryList.Add(categoryVM);
            }
        }

        public void GetCategoryTaskList()
        {
            CategoryTasksList.Clear();
            var categoryTasks = TaskStoreService.ReturnCategoryTaskList();
            foreach (TaskModel categoryTaskModel in categoryTasks)
            {
                TaskViewModel categoryTaskVM = MappingService.ToTaskViewModel(categoryTaskModel);
                _categoryTasksList.Add(categoryTaskVM);
            }
        }
    }
}
