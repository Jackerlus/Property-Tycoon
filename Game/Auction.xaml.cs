using System;
using System.Collections;
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
    /// Interaction logic for Auction.xaml
    /// </summary>
    public partial class Auction : Window
    {
        private int bid;
        private int currentValue;
        private Board CurrentGame;
        private Property Property;
        private ArrayList players;
        private Player HighestBidder;
        private Player currentBidder;
        public Auction(Board CG, Property prop)
        {
            Property = prop;
            currentValue = prop.getCost();
            CurrentGame = CG;
            players = callAuction();
            currentBidder = (Player)players[0];
            HighestBidder = currentBidder;

            InitializeComponent();
            refresh();
        }

        private ArrayList callAuction()
        {
            ArrayList p = new ArrayList();
            foreach (Player item in CurrentGame.getPlayerList() )
            {
                if (item.HasPassedGo() == true)
                {
                    p.Add(item);
                }
            }
            return p;
        }

        private void refresh() {
            CurrentBidlabel.Content = "CurrentBid: " + currentValue;
            HighestBidderlabel.Content = HighestBidder.getName();
            Propertylabel.Content = Property.getName() + " Base Cost :£ " + Property.getCost();

            CurrentBidderlabel.Content = "Current Bidder"+ currentBidder.getName();
        }
        private void Nextplayer() {
            try
            {
                 currentBidder = (Player)players[players.IndexOf(currentBidder) + 1];
            }
            catch (ArgumentOutOfRangeException )
            {

                currentBidder = (Player)players[0];
            }
            refresh();
        }

        private void submitBidBtn_Click(object sender, RoutedEventArgs e)
        {
            if (currentValue + bid < currentBidder.getMoney())
            {
                currentValue = currentValue + bid;
                HighestBidder = currentBidder;
                Nextplayer();
            }
            else {
                MessageBox.Show("You cannot afford this bid. please choose a different value or drop out.");
            }
           
            
            
        }

        private void BackOut_Click(object sender, RoutedEventArgs e)
        {
            if (players.Count > 1)
            {
                players.Remove(currentBidder);
                Nextplayer();
            }
            else {
                HighestBidder.addmoney(Property.getCost());
                HighestBidder.buyProperty(Property);
                HighestBidder.addmoney(-currentValue);
                Close();
            }
            refresh();
        }
        private void EnterValuebox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                bid = Convert.ToInt32(EnterValuebox.Text);
            }
            catch (FormatException)
            {

            }
        }
    }
}
