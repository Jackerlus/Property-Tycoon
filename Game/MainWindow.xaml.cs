using System.Windows;

namespace Property_Tycoon
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //lblConsole.Content = "";           
        }

        public void WriteToConsole(string input) //Write to a label element called "lblConsole"
        {
            //string currentText = lblConsole.Content.ToString();
            //lblConsole.Content = currentText + "\n" + input;
        }

        private void RollDice(object sender, RoutedEventArgs e)
        {
            //Initialises a new Roll object and returns the dice roll result

            Roll roll1 = new Roll();
            //WriteToConsole(roll1.Rolls());
        }
    }
}
