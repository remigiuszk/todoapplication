using System;
using System.Linq;
using System.Windows.Input;
using ToDoApp.Commands;
using ToDoApp.Commands.Profile;
using ToDoApp.Services;
using ToDoApp.ViewModels;

namespace ToDoApp.Models
{
    public class CategoryTaskModel
    {
        //LINK TABLE//
        public Guid CategoryId { get; set; }
        public Guid TaskId { get; set; }
    }
}
