using System.Windows.Controls;
using ToDoApp.ViewModels;

namespace ToDoApp.Views
{
    /// <summary>
    /// Interaction logic for ProfileView.xaml
    /// </summary>
    public partial class ProfileView : UserControl
    {
        public ProfileView()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}
