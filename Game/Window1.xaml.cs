using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Property_Tycoon
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        int a; 
        public Window1()
        {
            InitializeComponent();
        }
        public void data(String input) {
            message.Content = input;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            a = 0;  
            this.Close();
            
           
        }
        public int getChoice() {
            return a;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            a = 1;
            this.Close();


        }
    }
}
