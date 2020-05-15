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
    /// Interaction logic for setPlayers.xaml
    /// </summary>
    public partial class setPlayers : Window
    {
        Board CurrentBoard;
        private  ArrayList a;
        private ArrayList b;
        Player CurrentPlayer;
        int time;
        /// <summary>
        /// this method sets the players
        /// </summary>
        /// <param name="cg"></param>
        public setPlayers(Board cg)
        {  
            CurrentBoard = cg;
            a = new ArrayList();
            b = new ArrayList();
            
            InitializeComponent();
           
        }
        /// <summary>
        /// this method add the new window to the board
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddPlayer_Click(object sender, RoutedEventArgs e)
        {

            
            try
            {
                Window2 p = new Window2(CurrentBoard, this);
                p.ShowDialog();
                ListView.ItemsSource = CurrentBoard.getPlayerNames();
                CheckMinPlayer();
                CheckMaxPlayer();


            }

            catch (TooManyPlayersException)
            {


            }
            catch (ArgumentOutOfRangeException) {
               
            }
            catch (NotEnoughPlayersException) {
                
            }
            

        }
        /// <summary>
        /// this method checks the minimum number of players
        /// </summary>
        private void CheckMinPlayer()
        {
            if ((CurrentBoard.getNoOfPlayers() < 2))
            {
                throw new NotEnoughPlayersException();
            }
        }
        /// <summary>
        /// this checks if the max number of players has been exceeded
        /// </summary>
        private void CheckMaxPlayer() {
            if (CurrentBoard.getNoOfPlayers() == 6)
            {
                throw new TooManyPlayersException();
            }
        }
        /// <summary>
        /// this method starts the normal method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Normal_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentBoard.getNoOfPlayers() >= 2)
            {
                CurrentBoard.setTime(0);
                CurrentBoard.SetGameType(0);


                Close();
            }
            else {
                MessageBox.Show("The minimum players must be 2");
            
            }
                
        }
        /// <summary>
        /// this method starts the abridge game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Abridged_Click(object sender, RoutedEventArgs e)
        {

            if (CurrentBoard.getNoOfPlayers() >=2)
            {
                SetTime T = new SetTime();
                T.ShowDialog();


                CurrentBoard.setTime(T.getTime());
                CurrentBoard.SetGameType(1);
                Close();
            }
            else
            {
                MessageBox.Show("The minimum players must be 2");

            }
            

        }
        /// <summary>
        /// this method removes a player from the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemovePlayer_Click(object sender, RoutedEventArgs e)
        {
            CurrentBoard.getPlayerList().Remove(ListView.SelectedItem);
            CurrentBoard.getPlayerList().TrimToSize();

        }


    }
}
