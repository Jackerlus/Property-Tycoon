using System;
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
    /// Interaction logic for SetTime.xaml
    /// </summary>
    public partial class SetTime : Window
    {
        int time;
        public SetTime()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            time = (Convert.ToInt32(Hour.Text) * 3600) + (Convert.ToInt32(Minutes.Text) * 60) + (Convert.ToInt32(Seconds.Text));
            Close();

        }
        public int getTime() {
            return time;
        }
    }
}
