using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for Player_Prototype.xaml
    /// </summary>
    public partial class Player_Prototype : Window
    {
        int A = 12;

        Property currentprop;
        public Board currentGame;
        private ArrayList properties = new ArrayList(39);
        private ArrayList prop;
        private Player currentPlayer;
        public Player_Prototype()
        {
            
            currentGame = new Board();
            properties = currentGame.returnProperties();
            prop = currentGame.getPlayerList();
    
            currentPlayer = (Player )prop[0];
           

        
      
                    InitializeComponent();
             Player2details();
            currentPlayer.buyProperty((Property) properties[1]);
            currentPlayer.buyProperty((Property)properties[4]);
            currentPlayer.buyProperty((Property)properties[13]);
            currentPlayer.buyProperty((Property)properties[16]);
        }

        public bool checkOwnership(ArrayList target) {
            bool flag = false;
            foreach (Property item in target)
            {
                if (item.getOwner() == currentPlayer.getName())
                {
                    flag = true;
                }
                else {
                    flag = false;
                }
            }

            return flag;
        }

        public NonProperties getFreeParking() {
            return currentGame.FreeParking;
        }


        private void EndTurn(object sender, RoutedEventArgs e)
        {
            if (prop.Count == prop.IndexOf(currentPlayer)+1) {
                currentPlayer = (Player)prop[0];
            }
            else
            {
                currentPlayer = (Player)prop[prop.IndexOf(currentPlayer)+1];
            }

            checkRent(currentPlayer);
            currentPlayer.endTurn();
            currentprop = null;
            Update(this, e);
            
        }
        public void checkRent(Player p) {
            if (properties[currentPlayer.getPosition()] is Property)
            {
                Property prop = (Property)properties[currentPlayer.getPosition()];
                if (p.getPosition()== prop.getPosition() && prop.getPlayer() != currentPlayer)
                {
                    currentPlayer.addmoney(-prop.getRent());
                 
                }
            }

        }
        public ListBox ListProperties(Player input) {
            
            ArrayList p = input.getProperties();
            ListBox CurrentProperties = new ListBox();

            foreach (Property item in p)
            {
                CurrentProperties.Items.Add(p);
            }

            
            return CurrentProperties;
        }
        public string ListAllProperties()
        {
            string s = "";
           for(int i = 0; i < 39; i++)
                if (properties[i] is Property)
                {
                   Property p = (Property)properties[i];
                    s = s + "\n" + p.getName();
                }
                else
                {
                    s = s + "\n" + properties[i].GetType();
                }
            return s;
        }



        
        public void Player2details() //Write to a label element called "player2"
        {


            Player.Content = "Name:  " + currentPlayer.getName() + "\n" +
                              "pos: " + currentPlayer.getPosition() + "\n" +
                              "money: " + currentPlayer.getMoney() + "\n" +
                              "GOJFC: " + currentPlayer.getJailFreeNo() + "\n"
                              + "injail?: " + currentPlayer.isInJail() + "\n" +
                              "jailno: " + currentPlayer.getJailTurns() + "\n" + "Properties: \n";
                          
        }

        private void BuyProperty(object sender, RoutedEventArgs e)
        {
     
            if (properties[currentPlayer.getPosition()] is Property)
            {
                Property p = (Property)properties[currentPlayer.getPosition()];
                currentPlayer.buyProperty((Property)properties[currentPlayer.getPosition()]);  

            }
            else {
                MessageBox.Show( "you cannot buy this...");
            }
            Update(this, e);


        }
        

        private void addHouse(object sender, RoutedEventArgs e)
        {
            try
            {
            currentprop.addHouse();
                MessageBox.Show("Houses: "+currentprop.checkHouses()+" Rent Value: "+currentprop.getRent());
            }
            catch (System.NullReferenceException NoHouseSelected)
            {

                MessageBox.Show("Please select a property you own before attempting to add a house");
            }
        

            
            

        }

        private void morgageProperty(object sender, RoutedEventArgs e)
        {
            try
            {
                currentPlayer.MortgageProperty(currentprop);
            }
            catch (System.NullReferenceException NoHouseSelected)
            {

                MessageBox.Show("Please select a property you own before attempting to add a house");
            }
        }


        private void RollDice(object sender, RoutedEventArgs e)
        {

            currentPlayer.rolldice();
            
            
            Update(this, e);
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            Selected.Content = currentPlayer.getName();
            Player2details();
            PropertyList.ItemsSource=(currentPlayer.getPropertyNames());
        }





        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                CurrentProperty.Content = currentPlayer.GetProperty(PropertyList.SelectedIndex).getName();
                Update(this, e);

                currentprop = currentPlayer.GetProperty(PropertyList.SelectedIndex);
            }
            catch (Exception)
            {

                
            }
  
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PlayerMenu p = new PlayerMenu(currentprop,(Human)currentPlayer);
                p.Show();
            }
            catch (Exception)
            {

                MessageBox.Show("Select a current property before entering the menu");
                
            }
        }

        private void roll6_Click(object sender, RoutedEventArgs e)
        {
            currentPlayer.move(6);
        }

        private void randroll_Click(object sender, RoutedEventArgs e)
        {
            currentPlayer.move(12);
        }

        private void Tesla_Click(object sender, RoutedEventArgs e)
        {
            currentPlayer.move(13);
        }

        private void Completeutil_Click(object sender, RoutedEventArgs e)
        {
            currentPlayer.buyProperty((Property)properties[29]);
        }
    }
}
