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
        private void refresh() {
            PlayerNameLlabel.Content = Left.getName();
            PlayerNameRlabel.Content = Right.getName();
            RightPropertiesList.ItemsSource = Right.getPropertyNames();
            LeftPropetiesList.ItemsSource = Left.getPropertyNames();
            RightconfirmBtn.Background = Brushes.Red;
            leftConfirmBtn.Background = Brushes.Red;
        }

        private Player getRightPlayer()
        {
            GetPlayerToTrade Tradee = new GetPlayerToTrade(currentGame);
            Tradee.ShowDialog();
           
            return (Tradee.getPlayer());
        }

        private void LeftPropetiesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Llock == false)
            {
                LeftPlayer.Clear();
                LeftPlayer.AddRange(LeftPropetiesList.SelectedItems);
               
            }

        }

        private void RightPropertiesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Llock == false)
            {
                if (Rlock == false)
                {
                    RightPlayer.Clear();
                    RightPlayer.AddRange(RightPropertiesList.SelectedItems);
                }
            }
        
        }

        private void leftConfirmBtn_Click(object sender, RoutedEventArgs e)
        {
            String s = "";
            foreach (var item in LeftPropetiesList.SelectedItems)
            {
                s += item.ToString();
            }
            MessageBox.Show(s);
     
            if (Llock == false)
            {
                Llock = true;
                leftMoney = Convert.ToInt32(LeftMoneyBox.Text);
                leftConfirmBtn.Background = Brushes.Green;
            }
            else {
                leftConfirmBtn.Background = Brushes.Red;
                Llock = false;

            }
               



        }

        private void RightconfirmBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Rlock == false)
            {
                Rlock = true;

                RightPlayer.AddRange(RightPropertiesList.SelectedItems);
                RightMoney = Convert.ToInt32(RightMoneyBox.Text);
                RightconfirmBtn.Background = Brushes.Green; 
            }
            else
            {
                RightconfirmBtn.Background = Brushes.Red;
                Rlock = false;
            }

        }

        private void Complete_Click(object sender, RoutedEventArgs e)
        {

            if (Rlock == true && Llock == true)
            {
                Right.addmoney(leftMoney);
                Left.addmoney(RightMoney);
                Left.addmoney(-leftMoney);
                Right.addmoney(-RightMoney);
                String s = "";
                foreach (object item in RightPropertiesList.SelectedItems)
                {
                    if (item is Property)
                    {
                        Property p = (Property)item;
                        s += "Was:" + p.getOwner();
                        p.SetOwner(Left);
                        Right.RemoveFromPropertyArray(p);
                        Left.addToPropertyArray(p);
                        MessageBox.Show(p.getName() + "Has lost owner");
                        s += "\nNOW:"+p.getOwner();
                        MessageBox.Show(s);
                    }

                }
                foreach (object item in LeftPropetiesList.SelectedItems)
                {
                    currentGame.getProperties();

                    if (item is Property)
                    {
                        Property p = (Property)item;
                        p.SetOwner(Right);
                        Left.RemoveFromPropertyArray(p);
                        Right.addToPropertyArray(p);
                    }
                }
                refresh();
            }
            else {
                MessageBox.Show("both parties arent satisfied");
                Rlock = false;
                Llock = false;
                RightconfirmBtn.Background = Brushes.Red;
                leftConfirmBtn.Background = Brushes.Red;
            }
        }

    }
}
