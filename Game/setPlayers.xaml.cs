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
        public setPlayers(Board cg)
        {  
            CurrentBoard = cg;
            a = new ArrayList();
            b = new ArrayList();
            
            InitializeComponent();
           
        }

        public ArrayList getArrayList() {
            return a;
        }
        
        public ArrayList getArrayListb()
        {
            return b;
        }
        public void AddToArray(Player P) {
        
        }

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
        private void CheckMinPlayer()
        {
            if ((CurrentBoard.getNoOfPlayers() < 2))
            {
                throw new NotEnoughPlayersException();
            }
        }
        private void CheckMaxPlayer() {
            if (CurrentBoard.getNoOfPlayers() == 6)
            {
                throw new TooManyPlayersException();
            }
        }

        private void Normal_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentBoard.getNoOfPlayers() >= 2)
            {
                CurrentBoard.setTime(900000000);
                CurrentBoard.SetGameType(0);


                Close();
            }
            else {
                MessageBox.Show("The minimum players must be 2");
            
            }
                
        }

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

        private void RemovePlayer_Click(object sender, RoutedEventArgs e)
        {
            CurrentBoard.getPlayerList().Remove(ListView.SelectedItem);
            CurrentBoard.getPlayerList().TrimToSize();

        }


    }
}
