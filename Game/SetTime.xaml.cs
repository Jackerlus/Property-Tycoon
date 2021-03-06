﻿using System;
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
        /// <summary>
        /// this method Submits the time
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
            time = (Convert.ToInt32(Hour.Text) * 3600) + (Convert.ToInt32(Minutes.Text) * 60) + (Convert.ToInt32(Seconds.Text));
            }
            catch (System.FormatException)
            {

                
            }
            
            Close();

        }
        /// <summary>
        /// this method gets the time
        /// </summary>
        /// <returns></returns>
        public int getTime() {
            return time;
        }
    }
}
