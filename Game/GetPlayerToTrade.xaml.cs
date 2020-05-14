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
    /// Interaction logic for GetPlayerToTrade.xaml
    /// </summary>
    public partial class GetPlayerToTrade : Window
    {
        Board CurrentGame;
        Player P;
        public GetPlayerToTrade(Board cg)
        {
            CurrentGame = cg;
           
            InitializeComponent();
            PlayerCombo.ItemsSource = CurrentGame.getPlayerNames();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Close();
        }

        public Player getPlayer()
        {
            return P;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {

                P = (Player)CurrentGame.getPlayerList()[PlayerCombo.SelectedIndex];

            }
            catch (Exception)
            {


            }
        }
    }
}
