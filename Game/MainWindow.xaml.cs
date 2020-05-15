using System;
using System.Collections;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Property_Tycoon
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Property currentprop;
        public Board currentGame;
        private ArrayList properties = new ArrayList(39);
        private ArrayList prop;
        private Player currentPlayer;
        private Property CurrentProperty;
        private Timer timer1;
        private int counter;

        public MainWindow()
        {

            currentGame = new Board();
            properties = currentGame.returnProperties();
            prop = currentGame.getPlayerList();
            counter = currentGame.getTime();
            
            currentPlayer = (Player)prop[0];
            
            

            InitializeComponent();
            
            StartTime();
   
            generateBoard();
            generatePropertyText();
            update();




        }
        /// <summary>
        /// this is a method to start the timer
        /// </summary>
        private void StartTime()
        {
            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 1000;
            timer1.Start();
        }
        /// <summary>
        /// This method adds the tick for the countdown clock
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan time = TimeSpan.FromSeconds(counter);
         
            counter--;
            if (counter == 0)
            {
                timer1.Stop();
                currentGame.abridgeGame();
            }
            

            T.Content = time.Hours+" Hour(s) "+time.Minutes+ " Minute(s) and "+ time.Seconds +" Second(s)";
        }
        /// <summary>
        /// this method generates the property names
        /// </summary>
        private void generatePropertyText() { 
            String s = "Label";
            for (int i = 0; i < 40; i++)
            {
                var label = (System.Windows.Controls.TextBlock)this.FindName((s + i.ToString()));
                
                if (label != null)
                {
                    

                    System.Windows.Controls.TextBlock l = (System.Windows.Controls.TextBlock)label;
                    l.Text = currentGame.getspaceName(i);

                }
            }

        }
        /// <summary>
        /// Generate Board for the game
        /// </summary>
        private void generateBoard()
            {
                string s = "Property";

                for ( int i = 0 ; i < 40; i++)
                {
                    var rect = (System.Windows.Shapes.Rectangle)this.FindName((s+i.ToString()));
                    if (rect != null)
                    {


                        if (properties[i] is Property)
                        {
                            switch (currentGame.GetProperty(i).getColour())
                            {
                                case Group.Brown:
                                    rect.Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(103, 52, 0));
                                    break;
                                case Group.Blue:
                                    rect.Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 255, 255));
                                    break;
                                case Group.Purple:
                                    rect.Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(128, 0, 255));
                                    break;
                                case Group.Deep_Blue:
                                    rect.Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 0, 255));
                                    break;
                                case Group.Green:
                                    rect.Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 255, 0));
                                    break;
                                case Group.Orange:
                                    rect.Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 128, 0));
                                    break;
                                case Group.Red:
                                    rect.Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 0, 0));
                                    break;
                                case Group.Station:
                                    rect.Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0xff, 0xff, 0x90));
                                    break;
                                case Group.Yellow:
                                    rect.Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 125, 0x90));
                                    break;
                                case Group.Utility:
                                    rect.Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(128, 128, 128));
                                    break;
                                default:
                                    break;
                            }
                        }
                        else {
                            rect.Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 255, 255));
                        }
                    }

                }
            }
        /// <summary>
        /// This is the method to add the maker to the board
        /// </summary>
        private void placeMarker() {

            String s = "pos";
            for (int i = 0; i < 40; i++)
            {
                var label = (System.Windows.Shapes.Ellipse)this.FindName((s + i.ToString()));

                if (i == currentPlayer.getPosition())
                {


                    System.Windows.Shapes.Ellipse l = (System.Windows.Shapes.Ellipse)label;
                    l.Fill = System.Windows.Media.Brushes.Red;

                }
            }
        }
        /// <summary>
        /// This is the method used to remove the Marker for the current player
        /// </summary>
        private void removeMarker()
        {

            String s = "pos";
            for (int i = 0; i < 40; i++)
            {
                var label = (System.Windows.Shapes.Ellipse)this.FindName((s + i.ToString()));

                if (i == currentPlayer.getPosition())
                {


                    System.Windows.Shapes.Ellipse l = (System.Windows.Shapes.Ellipse)label;
                    l.Fill = System.Windows.Media.Brushes.White;

                }
            }
        }
        /// <summary>
        /// This is the method that updates the players menu
        /// </summary>
        private void update()
        {

            ImageBox.Source = new BitmapImage(new Uri("H:/PropertyTycoon2/Game/" + currentPlayer.getPieceImg()));
            CurrentPlayerInfo.Content =
             "Name:  " + currentPlayer.getName() + "\n" +
                              "pos: " + currentPlayer.getPosition() +"\n" +
                              "money: " + currentPlayer.getMoney() + "\n" +
                              "GOJFC: " + currentPlayer.getJailFreeNo() + "\n"
                              + "injail?: " + currentPlayer.isInJail() + "\n" +
                              "jailno: " + currentPlayer.getJailTurns() + "\n" + "Properties List: \n";
            OwnedProperties.ItemsSource = (currentPlayer.getPropertyNames());
            
            
        }
        /// <summary>
        /// this method ends the turn for the current player
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EndTurnBtn_Click(object sender, RoutedEventArgs e)
        {
                removeMarker();
                 if (prop.Count == prop.IndexOf(currentPlayer) + 1)
                 {
                     currentPlayer = (Player)prop[0];
                 }
                 else
                 {
                     currentPlayer = (Player)prop[prop.IndexOf(currentPlayer) + 1];
                 }

                 currentPlayer.endTurn();
            
            placeMarker();
            update();
        }
        /// <summary>
        /// this method selects the property from the combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
               
                CurrentProperty  = currentPlayer.GetProperty(OwnedProperties.SelectedIndex);
             

                currentprop = currentPlayer.GetProperty(OwnedProperties.SelectedIndex);
                update();
            }
            catch (Exception)
            {


            }
        }
        /// <summary>
        /// this method calls the property managment tile
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisplayBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                new PlayerMenu(currentprop,(Human)currentPlayer).ShowDialog();
                update();
            }
            catch (NullReferenceException )
            {

                System.Windows.MessageBox.Show("Please seleect a property first");
            }
        }
        /// <summary>
        /// this method rolls the dice for the player
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RollBtn_Click(object sender, RoutedEventArgs e)
        {
            removeMarker();
            currentPlayer.rolldice();
            placeMarker();
            update();
        }

        /// <summary>
        /// this method is the process to buy a property
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuyProperty_Click(object sender, RoutedEventArgs e)
        {

            if (properties[currentPlayer.getPosition()] is Property)
            {
                Property p = (Property)properties[currentPlayer.getPosition()];
                currentPlayer.buyProperty((Property)properties[currentPlayer.getPosition()]);

            }
            else
            {
                System.Windows.MessageBox.Show("you cannot buy this...");
            }
            update();

        }
        /// <summary>
        /// this method is the process to Retire a player
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Retire_Click(object sender, RoutedEventArgs e)
        {
            currentPlayer.retire();
            update();

        }
        /// <summary>
        /// this method is the logic for the trade button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Trade_Click(object sender, RoutedEventArgs e)
        {
             new TradeScreen(currentPlayer, currentGame).ShowDialog();
             update();
        }
    }
}
