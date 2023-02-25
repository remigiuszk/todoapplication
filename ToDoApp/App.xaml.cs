﻿using System.Windows;
using ToDoApp.ViewModels;

namespace ToDoApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            MainViewModel mainViewModel = new MainViewModel();

            MainWindow = new MainWindow()
            {
                DataContext = mainViewModel
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
