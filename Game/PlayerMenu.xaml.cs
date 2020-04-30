using Microsoft.CSharp.RuntimeBinder;
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
    /// Interaction logic for PlayerMenu.xaml
    /// </summary>
    public partial class PlayerMenu : Window
    {
        Property property;
        ArrayList images;
        
        public PlayerMenu(Property p)
        {
  
            property = p;
            InitializeComponent();
            Refresh();
        }
        private Brush getColour() {
            switch (property.getColour())
            {
                case Group.Brown:
                    return Brushes.Brown;
                case Group.Blue:
                    return Brushes.Blue;
                case Group.Purple:
                    return Brushes.Purple;
                    
                case Group.Orange:
                    return Brushes.Orange;
                    
                case Group.Red:
                    return Brushes.Red;

                case Group.Yellow:
                    return Brushes.Yellow;
                    
                case Group.Green:
                    return Brushes.Green;
                  
                case Group.Deep_Blue:
                    return Brushes.DarkBlue;
                   
                case Group.Station:
                    return Brushes.Black;


                case Group.Utility:
                    return Brushes.LightGray;
                    
                default:
                    return null;
            }

        }


        private void Refresh()
        {

            rect.Fill = getColour();
            PropertyName.Content = property.getName();
            if (!property.getColour().Equals(Group.Utility) || !property.getColour().Equals(Group.Station))
            { PropertyInfo.Content = 
                  "Base rent :            \t £" + property.getRent1() +"\n"
                + "Rent with 1 property  :\t £" + property.getRent2() + "\n"
                + "Rent with 2 properties:\t £" + property.getRent3() + "\n"
                + "Rent with 3 properties:\t £" + property.getRent4() + "\n"
                + "Rent with 4 properties:\t £" + property.getRent5() + "\n"
                + "Rent with Hotel:       \t £" + property.getHotel() + "\n";
            }
            if (property.getColour().Equals(Group.Station))
            {
                PropertyInfo.Content = 
                 "Rent with 1 Station : \t£" + property.getRent1() + "\n"
                + "Rent with 2 Stations: \t£" + property.getRent2() + "\n"
                + "Rent with 3 Stations: \t£" + property.getRent3() + "\n"
                + "Rent with 4 Stations: \t£" + property.getRent4() + "\n";

            }

        
            if(property.getColour().Equals( Group.Utility)) {
               
                PropertyInfo.FontSize = 13;
                PropertyInfo.Content = "\n"
                + "Rent with 1 Utility: 4* the value \n\tshown on the dice. \n\n"
                + "Rent with 2 Utilities: 10* the \n\t value shown on the\n\t dice.\n";

            }
        }
    }
}
