using System;
using System.Collections.Generic;
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

namespace DataGrid
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
           InitializeComponent();
           Loaded += DemoDataGrid_Loaded;
        }


        public void DemoDataGrid_Loaded(object sender,RoutedEventArgs e)
        {
            List<dynamic> list = new List<dynamic>()
            {
                new {CarName = "BMW",Color="White",Brand="BMW"},
                 new {CarName = "BMW",Color="White",Brand="BMW"},
                  new {CarName = "BMW",Color="White",Brand="BMW"}
            };
            dgCarList.ItemsSource = list;
        }


    }
}
