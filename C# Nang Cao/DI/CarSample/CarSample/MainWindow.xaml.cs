using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace CarSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        ManagementCategory categories = new ManagementCategory();
        private void Window_Loaded(object sender, RoutedEventArgs e) => LoadCategories();


        private void LoadCategories()
        {
            lvCategories.ItemsSource = categories.GetCategories();
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var category = new Category { CategoryName = txtCategoryName.Text };
                categories.Insert(category);
                LoadCategories();
            }catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var category = new Category {CategoryID= Convert.ToInt16(txtCategoryID.Text), CategoryName = txtCategoryName.Text };
                categories.Update(category);
                LoadCategories();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
