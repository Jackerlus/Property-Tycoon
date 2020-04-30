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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Property_Tycoon
{
    /// <summary>
    /// Interaction logic for addPlayer.xaml
    /// </summary>
    public partial class addPlayer : UserControl
    {
        Player P;
        string Name;
        Board Cg;
        public addPlayer(Board CurrentBoard)
        {
            Cg = CurrentBoard;
            Name = "";
            InitializeComponent();


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

           

        }

        private void UserBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Name = UserBox.Text;
            MessageBox.Show(Name);
        }
    }
    
}
