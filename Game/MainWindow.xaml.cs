using System;
using System.Collections;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media;

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




        }
        private void StartTime()
        {
            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 1000;
            timer1.Start();
        }

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

 


    }
}
