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
        /// <summary>
        /// this method sets the message for the dialogue box
        /// </summary>
        /// <param name="input"></param>
        public void data(String input) {
            message.Content = input;
        }
        /// <summary>
        /// this button sets the value to the integer then closes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            a = 0;  
            this.Close();
            
           
        }
        /// <summary>
        /// This method returns the choice
        /// </summary>
        /// <returns></returns>
        public int getChoice() {
            return a;
        }
        /// <summary>
        /// this method returns the choice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            a = 1;
            this.Close();


        }
    }
}
