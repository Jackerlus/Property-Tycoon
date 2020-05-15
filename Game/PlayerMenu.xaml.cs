using Microsoft.CSharp.RuntimeBinder;
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
    /// Interaction logic for PlayerMenu.xaml
    /// </summary>
    public partial class PlayerMenu : Window
    {
        Human CurrentPlayer;
        Property currentProperty;
        ArrayList images;
        /// <summary>
        /// constructor for the class
        /// </summary>
        /// <param name="p"></param>
        /// <param name="player"></param>
        public PlayerMenu(Property p,Human player)
        {

            CurrentPlayer = player;
            currentProperty = p;
            InitializeComponent();
            Refresh();
        }
        /// <summary>
        /// a method that gets the brush colour for a particualr property
        /// </summary>
        /// <returns></returns>
        private Brush getColour() {
            switch (currentProperty.getColour())
            {
                case Group.Brown:
                    return Brushes.Brown;
                case Group.Blue:
                    return Brushes.LightBlue;

                case Group.Purple:
                    return Brushes.Purple;
                    
                case Group.Orange:
                    return Brushes.Orange;
                    
                case Group.Red:
                    return Brushes.Red;

                case Group.Yellow:
                    return Brushes.Yellow;
                    
                case Group.Green:
                    return Brushes.Green;
                  
                case Group.Deep_Blue:
                    return Brushes.DarkBlue;
                   
                case Group.Station:
                    return Brushes.Black;


                case Group.Utility:
                    return Brushes.LightGray;
                    
                default:
                    return Brushes.Fuchsia;
            }

        }

        /// <summary>
        /// a method that changes the property in view.
        /// </summary>
        private void Refresh()
        {

            rect.Fill = getColour();
            PropertyName.Content = currentProperty.getName();
            if (!currentProperty.getColour().Equals(Group.Utility) || !currentProperty.getColour().Equals(Group.Station))
            {
                PropertyInfo.Content =
                    "Base rent :            \t £" + currentProperty.getRent1() + "\n"
                  + "Rent with 1 house  :\t £" + currentProperty.getRent2() + "\n"
                  + "Rent with 2 houses :\t £" + currentProperty.getRent3() + "\n"
                  + "Rent with 3 houses :\t £" + currentProperty.getRent4() + "\n"
                  + "Rent with 4 houses :\t £" + currentProperty.getRent5() + "\n"
                  + "Rent with Hotel:       \t £" + currentProperty.getHotel() + "\n"
                  + " Owner: \t" + currentProperty.getOwner(); 
            }
            if (currentProperty.getColour().Equals(Group.Station))
            {
                PropertyInfo.Content = 
                 "Rent with 1 Station : \t£" + currentProperty.getRent1() + "\n"
                + "Rent with 2 Stations: \t£" + currentProperty.getRent2() + "\n"
                + "Rent with 3 Stations: \t£" + currentProperty.getRent3() + "\n"
                + "Rent with 4 Stations: \t£" + currentProperty.getRent4() + "\n"
                + " Owner: \t" + currentProperty.getOwner();

            }

        
            if(currentProperty.getColour().Equals( Group.Utility)) {
               
                PropertyInfo.FontSize = 13;
                PropertyInfo.Content = "\n"
                + "Rent with 1 Utility: 4* the value \n\tshown on the dice. \n\n"
                + "Rent with 2 Utilities: 10* the \n\t value shown on the\n\t dice.\n"
                + " Owner: \t" + currentProperty.getOwner();


            }
        }

        /// <summary>
        /// This handles the process of mortgaging a property
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MortgageBtn_Click(object sender, RoutedEventArgs e)
        {
            if (currentProperty.getMortgaged() == false && currentProperty.hotelCheck() == false && currentProperty.checkHouses() == 0)
            {
                CurrentPlayer.MortgageProperty(currentProperty);

            }
            else {
                MessageBox.Show("Error please sell all Improvements first");
            }

        }


        /// <summary>
        /// This method handles the process of unmortgaging a property
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UnMortgageBtn_Click(object sender, RoutedEventArgs e)
        {
            if (currentProperty.getMortgaged() == true && CurrentPlayer.getMoney() > 0)
            {
                CurrentPlayer.UnMortgageProperty(currentProperty);
            }
            else {
                MessageBox.Show("You dont have enough money to buy back property");
            }

        }

        /// <summary>
        /// This method handles the process of buying a house for a property
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuyHousebtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                currentProperty.addHouse();
                System.Windows.Forms.MessageBox.Show("Houses: " + currentProperty.checkHouses() + " Rent Value: " + currentProperty.getRent());
            }
            catch (System.NullReferenceException NoHouseSelected)
            {

                System.Windows.Forms.MessageBox.Show("Please select a currentProperty you own before attempting to add a house");
            }
        }
        /// <summary>
        /// This method handles the process of selling a house for a property
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sellHousebtn_Click(object sender, RoutedEventArgs e)
        {
            currentProperty.sellHouse();
        }
        /// <summary>
        /// This method handles the process of buying a house for a property
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuyHotelbtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(currentProperty.convertHouseToHotel());
        }
        /// <summary>
        /// This method handles the process of buying a hotel for a property
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sellHotelbtn_Click(object sender, RoutedEventArgs e)
        {
            currentProperty.sellHotel();
        }
    }
}
