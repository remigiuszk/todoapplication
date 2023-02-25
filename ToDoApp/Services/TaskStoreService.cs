using System.Collections.Generic;
using System.Windows.Input;
using ToDoApp.Commands;
using ToDoApp.Models;
using ToDoApp.ViewModels;
using System.Linq;
using System.Collections.ObjectModel;
using System;

namespace ToDoApp.Services
{
    public class TaskStoreService
    {
        //SINGLETON CLASS//

        public List<TaskModel> _tasksList;

        public TaskStoreService()
        {
            _tasksList = new List<TaskModel>();
            TaskModel _defaultTask = new TaskModel();
            _defaultTask.Name = "Title";
            _defaultTask.Description = "Description";
            _defaultTask.Value = 1;
            _defaultTask.Id = Guid.NewGuid();
            _tasksList.Add(_defaultTask);
        }

        private static TaskStoreService _instance;
        public static TaskStoreService Instance()
        {
            if (_instance == null)
            {
                _instance = new TaskStoreService();
            }
            return _instance;
        }

        public static void AddNewTask(TaskModel newTask)
        {
            _instance._tasksList.Add(newTask);
        }

        public static void RemoveTask(Guid rTaskID)
        {
            var taskToRemoving = Instance()._tasksList.FirstOrDefault(t => t.Id == rTaskID);
            _instance._tasksList.Remove(taskToRemoving);
        }

        public static List<TaskModel> ReturnAllTasks()
        {
            return Instance()._tasksList;
        }

        public static TaskModel FindTask(Guid taskID)
        {
            return Instance()._tasksList.FirstOrDefault(t => t.Id == taskID);
        }
    }
}
