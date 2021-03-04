using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace VodovozWpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public void OnStartup(object sender, StartupEventArgs e)
        {
            
            var navigationService = DI.ServiceProvider.GetService<NavigationService>();

            MainWindow mainWindow = DI.ServiceProvider.GetService<MainWindow>();
            mainWindow.Show();
            navigationService.NavigateTo(AppPageEnum.EmployeesControlPage, null);

        }
    }
}
