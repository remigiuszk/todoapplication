using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ToDoApp.Commands;
using ToDoApp.Models;
using ToDoApp.Services;
using System.Linq;

namespace ToDoApp.ViewModels
{
    public class TasksListViewModel : BaseViewModel
    {
        private TaskViewModel _newTaskViewModel;
        public TaskViewModel NewTaskViewModel
        {
            get { return _newTaskViewModel; }
            set
            {
                _newTaskViewModel = value;
                OnPropertyChanged(nameof(NewTaskViewModel));
            }
        }

        private TaskViewModel _editTaskViewModel;
        public TaskViewModel EditTaskViewModel
        {
            get { return _editTaskViewModel; }
            set
            {
                _editTaskViewModel = value;
                OnPropertyChanged(nameof(EditTaskViewModel));
            }
        }

        private TaskViewModel _selectedTask;
        public TaskViewModel SelectedTask
        {
            get { return _selectedTask; }
            set
            {
                _selectedTask = value;
                OnPropertyChanged(nameof(SelectedTask));
            }
        }

        private ObservableCollection<TaskViewModel> _tasksList;
        public ObservableCollection<TaskViewModel> TasksList
        {
            get { return _tasksList; }
            set
            {
                _tasksList = value;
                OnPropertyChanged(nameof(TasksList));
            }
        }

        private bool _isCompleted;
        public bool IsCompleted
        {
            get { return _isCompleted; }
            set
            {
                _isCompleted = value;
                OnPropertyChanged(nameof(IsCompleted));
            }
        }

        private bool _isVisibleBoolean;
        public bool IsVisibleBoolean
        {
            get { return _isVisibleBoolean; }
            set
            {
                _isVisibleBoolean = value;
                OnPropertyChanged(nameof(IsVisibleBoolean));
            }
        }

        private bool _isMoreThanOneTask;
        public bool IsMoreThanOneTask
        {
            get { return _isMoreThanOneTask; }
            set
            {
                _isMoreThanOneTask = value;
                OnPropertyChanged(nameof(IsMoreThanOneTask));
            }
        }

        public int Counter { get { return _tasksList.Count; } set { OnPropertyChanged(nameof(Counter)); } }

        public ICommand CreateTaskCommand { get; }
        public ICommand FinishTaskCommand { get; }
        public ICommand RemoveTaskCommand { get; }
        public ICommand EditTaskCommand { get; }
        public ICommand SaveChangesCommand { get; }
        public ICommand ExitTaskEditingCommand { get; }

        public TasksListViewModel()
        {
            CreateTaskCommand = new CreateTaskCommand(this);
            RemoveTaskCommand = new RemoveTaskCommand(this);
            FinishTaskCommand = new FinishTaskCommand(this);
            SaveChangesCommand = new SaveChangesCommand(this);
            ExitTaskEditingCommand = new ExitTaskEditingCommand(this);
            EditTaskCommand = new EditTaskCommand(this);
            TasksList = new ObservableCollection<TaskViewModel>();
            NewTaskViewModel = new TaskViewModel();
            EditTaskViewModel = new TaskViewModel();
            GetAllTasks();
        }

        public void GetAllTasks()
        {
            TasksList.Clear();

            var tasksListModel = TaskStoreService.ReturnAllTasks();

            foreach (TaskModel taskModel in tasksListModel.Where(t => t.IsCompleted == false))
            {
                TaskViewModel task = MappingService.ToTaskViewModel(taskModel);
                TasksList.Add(task);
            }
            
            CountTasks();
        }

        public void CountTasks()
        {
            Counter++;
            if (TasksList.Count > 1)
            {
                IsMoreThanOneTask = true;
            }
            else
            {
                IsMoreThanOneTask = false;
            }
        }
    }
}
