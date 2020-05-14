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
            currentValue = 0;
            CurrentGame = CG;
            players = CG.getPlayerList();
            InitializeComponent();
        }
        private void refresh() {
            CurrentBidlabel.Content = "CurrentBid:" +currentValue;
            Propertylabel.Content = Property.getName() + "Base Cost :£" + Property.getCost();
            Player p = (Player) players[0];
            CurrentBidderlabel.Content = p.getName();
        }
        private void Nextplayer() {
            if (players.Count == players.IndexOf(players) + 1)
            {
                currentBidder = (Player)players[0];
            }
            else
            {
                currentBidder = (Player)players[players.IndexOf(currentBidder) + 1];
            }
        }

        private void submitBidBtn_Click(object sender, RoutedEventArgs e)
        {
           
            currentValue = currentValue + bid;
            HighestBidder = currentBidder;
            Nextplayer();
        }

        private void BackOut_Click(object sender, RoutedEventArgs e)
        {
            if (players.Count > 1)
            {
                players.Remove(currentBidder);
                Nextplayer();
            }
            else {
                giveProperty();
                }
            
        }
        private void giveProperty() { 
            HighestBidder.addmoney(Property.getCost());
            HighestBidder.buyProperty(Property);
        }
    }
}
