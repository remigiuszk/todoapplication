using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Models;
using ToDoApp.ViewModels;

namespace ToDoApp.Services
{
    public static class MappingService
    {
        public static IEnumerable<TaskModel> ToTaskModel(IEnumerable<TaskViewModel> source)
        {
            var result = new List<TaskModel>();

            foreach (var item in source)
            {
                result.Add(ToTaskModel(item));
            }

            return result;
        }

        public static TaskModel ToTaskModel(TaskViewModel source)
        {
            return new TaskModel()
            {
                Name = source.TaskTitle,
                Description = source.TaskDescription,
                Value = source.TaskValue,
                Id = source.Id,
                IsCompleted = source.IsCompleted
            };
        }

        public static IEnumerable<TaskViewModel> ToTaskViewModel(IEnumerable<TaskModel> source)
        {
            var result = new List<TaskViewModel>();

            foreach (var item in source)
            {
                result.Add(ToTaskViewModel(item));
            }

            return result;
        }

        public static TaskViewModel ToTaskViewModel(TaskModel source)
        {
            return new TaskViewModel()
            {
                TaskTitle = source.Name,
                TaskDescription = source.Description,
                TaskValue = source.Value,
                Id = source.Id,
                IsCompleted = source.IsCompleted
            };
        }
    }
}
