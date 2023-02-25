using System;

namespace ToDoApp.Models
{
    public class TaskModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }
        public bool IsCompleted { get; set; }
    }
}
