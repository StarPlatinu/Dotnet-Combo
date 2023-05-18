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

namespace Slot2_CarApplication
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

        private void DisplayButton_Click(object sender, RoutedEventArgs e)
        {
            if (HelloButton.IsChecked==true)
            {
                MessageBox.Show("Hello");
            }
            else if(GoodByeButton.IsChecked==true) 
            {
                MessageBox.Show("Good Bye");
            }
        }

        private void ChangeBtn_Click(object sender, RoutedEventArgs e)
        {
            txtWellcome.Text = "Passes!";
        }

        private void ClickMeBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Yo brother.");
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Button newButton = new Button();
            newButton.Content = "New Button";
            newButton.Click += NewButton_Click;
            newButton.Background =Brushes.Green;
            buttonContainer.Children.Add(newButton);
        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            // Code to execute when the dynamically created button is clicked
            // Add your desired functionality here

            MessageBox.Show("I am a new button");
        }


    }
}
