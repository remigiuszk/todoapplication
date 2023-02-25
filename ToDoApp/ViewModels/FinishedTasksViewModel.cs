using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ToDoApp.Commands;
using ToDoApp.Models;
using ToDoApp.Services;

namespace ToDoApp.ViewModels
{
    public class FinishedTasksViewModel : BaseViewModel
    {
        public int FinishedCounter { get { return FinishedTasksList.Count; } set { OnPropertyChanged(nameof(FinishedCounter)); } }

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

        private ObservableCollection<TaskViewModel> _finishedTasksList;
        public ObservableCollection<TaskViewModel> FinishedTasksList
        {
            get { return _finishedTasksList; }
            set
            {
                _finishedTasksList = value;
                OnPropertyChanged(nameof(FinishedTasksList));
            }
        }

        public FinishedTasksViewModel()
        {
            FinishedTasksList = new ObservableCollection<TaskViewModel>();
            GetsFinishedTask();
        }
    
        public void GetsFinishedTask()
        {
            var finishedTasksModel = TaskStoreService.Instance()._tasksList.Where(t => t.IsCompleted == true);
            foreach(TaskModel taskModel in finishedTasksModel)
            {
                TaskViewModel finishedTask = MappingService.ToTaskViewModel(taskModel);
                FinishedTasksList.Add(finishedTask);
            }

            CountTasks();
        }

        public void CountTasks()
        {
            FinishedCounter++;
            if (FinishedTasksList.Count > 1)
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
