using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VodovozWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(ApplicationWindowViewModel appVm)
        {
            InitializeComponent();
            DataContext = appVm;
        }

        

        private void DataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            Console.WriteLine("hello:)");
        }

        private void DataGrid_RowEditEnding_1(object sender, DataGridRowEditEndingEventArgs e)
        {
            
        }
    }
}
