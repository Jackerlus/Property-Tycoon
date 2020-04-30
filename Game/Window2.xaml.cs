using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        Board CurrentBoard;
        setPlayers SetPlayers;
        String Name;
        Piece piece;
        bool Human;
        
        public Window2(Board cg, setPlayers setPlayers)
        {
            SetPlayers = setPlayers;
            CurrentBoard = cg;
            Name = "";
            
           
            InitializeComponent();
            Plist.ItemsSource = CurrentBoard.getPieceNames();
        }
        public string getName() {
            return Name;
        }

        private void Plist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            piece = CurrentBoard.getPiece(Plist.SelectedIndex);
            
            
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                Name = UserBox.Text;
                validateName(Name);
                CurrentBoard.getPiece(Plist.SelectedIndex).setPicked(true);
                if (HumanCheckBox.IsChecked == true)
                {
                    CurrentBoard.addToArray(new Human(Name, 1500, piece, CurrentBoard));
                    MessageBox.Show("this player is Human ");
                }
                else {
                    CurrentBoard.addToArray(new Human(Name, 1500, piece, CurrentBoard));
                    MessageBox.Show("this player is COMP ");
                }
                
                
                this.Close();
            }
            catch (EmptyNameException)
            {
                
                
            }

        }


        private void validateName(string p)
        {
            Regex regex = new Regex("^[a-zA-Z]+$");
            if (p.Length < 1 || !regex.IsMatch(p) )
            {
                throw new EmptyNameException(p);
            }
        }

        private void UserBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Name = UserBox.Text;
            
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            Name = "";
            UserBox.Clear();
            
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Human = true;
        }
    }
}
[Serializable]
class EmptyNameException : Exception
{
    public EmptyNameException()
    {

    }

    public EmptyNameException(string name)
        : base(String.Format("Invalid Name: {0}", name))
    {

    }
}

class NotEnoughPlayersException : Exception
{
    public NotEnoughPlayersException()
    {

    }

    public NotEnoughPlayersException(int count)
        : base(String.Format("Not enough Players: {0}", count))
    {

    }
    
}

class TooManyPlayersException : Exception
{
    private static ArrayList n;

    public TooManyPlayersException()
    {

    }

    public TooManyPlayersException(int n)
        : base(String.Format("The Max number of players is {0}", n))
    {

    }
}
