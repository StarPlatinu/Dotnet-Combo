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
using static System.Net.Mime.MediaTypeNames;

namespace DataBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //tb2.SetBinding(TextBox.TextProperty, new Binding()
            //{
            //    ElementName = "tb1",
            //    Path = new PropertyPath("Text")
            //});

            tb2.SetBinding(TextBox.TextProperty, new Binding()
            {
                ElementName = "TheSlider",
                Path = new PropertyPath("Value")
            });
        }

        private void tb2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int k = (int)TheSlider.Value;

            Debug.WriteLine(k);
        }
    }
}
