using System.Windows.Controls;
using ToDoApp.Services;
using ToDoApp.ViewModels;

namespace ToDoApp.Views
{
    /// <summary>
    /// Interaction logic for TasksListView.xaml
    /// </summary>
    public partial class TasksListView : UserControl
    {
        public TasksListView()
        {
            InitializeComponent();
            DataContext = new TasksListViewModel();
        }
    }
}
