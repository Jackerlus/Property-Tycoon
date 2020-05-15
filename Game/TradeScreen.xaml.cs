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
    /// Interaction logic for TradeScreen.xaml
    /// </summary>
    public partial class TradeScreen : Window
    {
        private ArrayList LeftPlayer;
        private ArrayList RightPlayer;
        private int RightMoney;
        private int leftMoney;
        private Player Left;
        private Player Right;
        private Board currentGame;
        private bool Llock,Rlock;
        public TradeScreen(Player L, Board cg)
        {
            Llock = false;
            Rlock = false;
            currentGame = cg;
            Left = L;
            Right = getRightPlayer();
            LeftPlayer = new ArrayList();
            RightPlayer = new ArrayList();
            RightMoney = 0;
            leftMoney = 0;
            
           
            InitializeComponent();
            refresh();
        }
        /// <summary>
        /// this method Refreshes the window
        /// </summary>
        private void refresh() {
            PlayerNameLlabel.Content = Left.getName();
            PlayerNameRlabel.Content = Right.getName();
            RightPropertiesList.ItemsSource = Right.getPropertyNames();
            LeftPropetiesList.ItemsSource = Left.getPropertyNames();
            RightconfirmBtn.Background = Brushes.Red;
            leftConfirmBtn.Background = Brushes.Red;
        }
        /// <summary>
        /// this method calls the window to select the other player to trade with
        /// </summary>
        /// <returns></returns>
        private Player getRightPlayer()
        {
            GetPlayerToTrade Tradee = new GetPlayerToTrade(currentGame);
            Tradee.ShowDialog();
           
            return (Tradee.getPlayer());
        }
        /// <summary>
        /// This method gets the players properties
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LeftPropetiesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Llock == false)
            {
                LeftPlayer.Clear();
                LeftPlayer.AddRange(LeftPropetiesList.SelectedItems);
               

            }

        }
        /// <summary>
        /// this method finds the  property object from the name
        /// </summary>
        /// <param name="b"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        private ArrayList findProperties(IList b,Player p) {
            ArrayList temp = new ArrayList();
            for (int i = 0; i < b.Count; i++)
            {
                if (b[i].Equals(p.GetProperty(i).getName()))
                {
                    temp.Add(p.GetProperty(i));
                }
            }
            return temp;
        }
        /// <summary>
        /// This method gets the players properties
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RightPropertiesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Rlock == false)
            {
                if (Rlock == false)
                {
                    RightPlayer.Clear();
                    RightPlayer.AddRange(RightPropertiesList.SelectedItems);
                  
                }

            }
        
        }
        /// <summary>
        /// this method locks in the left players assets
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void leftConfirmBtn_Click(object sender, RoutedEventArgs e)
        {

            if (Llock == false)
            {
                Llock = true;
                try {
                    if (Convert.ToInt32(LeftMoneyBox.Text) < Left.getMoney())
                    {
                        leftMoney = Convert.ToInt32(LeftMoneyBox.Text);

                    }
                    else {
                        MessageBox.Show("You do not have enough money money has been set to 0");
                        leftMoney = 0;
                    }
                    LeftPlayer.AddRange(LeftPropetiesList.SelectedItems);
                    leftConfirmBtn.Background = Brushes.Green;

                }
                catch (System.FormatException)
                {

                    MessageBox.Show("InvalidInput");
                }
            }
            else {
                leftConfirmBtn.Background = Brushes.Red;
                Llock = false;

            }
       



        }
        /// <summary>
        /// this method locks in the right players assets
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RightconfirmBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Rlock == false)
            {
                Rlock = true;

                try
                {
                    if (Convert.ToInt32(RightMoneyBox.Text) < Right.getMoney())
                    {
                        RightMoney = Convert.ToInt32(RightMoneyBox.Text);

                    }
                    else
                    {
                        MessageBox.Show("You do not have enough money has been set to 0");
                        RightMoney = 0;
                    }
                    RightPlayer.AddRange(RightPropertiesList.SelectedItems);
                    RightconfirmBtn.Background = Brushes.Green;
                }
                catch (System.FormatException)
                {

                    MessageBox.Show("InvalidInput");
                }
             
            }
            else
            {
                RightconfirmBtn.Background = Brushes.Red;
                Rlock = false;
            }
           
        }
        /// <summary>
        /// this method completes the trade
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Complete_Click(object sender, RoutedEventArgs e)
        {

            if (Rlock == true && Llock == true)
            {
                Right.addmoney(leftMoney);
                Left.addmoney(RightMoney);
                Left.addmoney(-leftMoney);
                Right.addmoney(-RightMoney);
                String s = "";
                foreach (object item in findProperties(RightPlayer,Right))
                {
                    if (item is Property)
                    {
                        Property p = (Property)item;
                        p.SetOwner(Left);
                        Right.RemoveFromPropertyArray(p);
                        Left.addToPropertyArray(p);
    
                        MessageBox.Show(s);
                    }

                }
                foreach (object item in findProperties(LeftPlayer,Left))
                {
                  

                    if (item is Property)
                    {
                        Property p = (Property)item;
                        p.SetOwner(Right);
                        Left.RemoveFromPropertyArray(p);
                        Right.addToPropertyArray(p);
                    }
                }
                refresh();
                Close();
            }
            else {
                MessageBox.Show("both parties aren't satisfied");
                Rlock = false;
                Llock = false;
                RightconfirmBtn.Background = Brushes.Red;
                leftConfirmBtn.Background = Brushes.Red;
            }
        }

    }
}
