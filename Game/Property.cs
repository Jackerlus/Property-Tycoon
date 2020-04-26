using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Property_Tycoon
{
    public enum Group {
    Brown,
    Blue,
    Purple,
    Orange,
    Red,
    Yellow,
    Green,
    Deep_Blue,
    Utility,
    Station,
    
    } 
    /// <summary>
    /// A class for all the properties in the game. 
    /// </summary>
    public class Property : Space
    {

        /// <summary>
        /// these are the varibles in order to get the data for each purchaceable property
        /// </summary>
        private int price;
        private String name;
        private int rentBase;
        private int rent;
        private int rent1;
        private int rent2;
        private int rent3;
        private int rent4;
        private int rentH;
        private bool bankOwned;
        private Player owner;


        private bool hasHotel;
        private Group colour; 

        private int houseNo;


        // public Player owner { get { return owner; }set { owner = value; } }
        /// <summary>
        /// constructor for the class
        /// </summary>
        /// <param name="position"></param>
        /// <param name="_price"></param>
        /// <param name="_name"></param>
        /// <param name="_rent"></param>
        /// <param name="_bankOwned"></param>
        /// <param name="_colour"></param>
        public Property(int position, int _price, string _name, int _rent, int _rent1, int _rent2, int _rent3, int _rent4, int _rentH, Group _colour) : base(position)
        {
            this.rent1 = _rent1;
            this.rent2 = _rent2;
            this.rent3 = _rent3;
            this.rent4 = _rent4;
            this.rentH = _rentH;
            price = _price;
            rent = _rent;
            rentBase = _rent;
            name = _name;
            colour = _colour;
            houseNo = 0;
            hasHotel = false;
            bankOwned = true;
        }
        
       
        public override string ToString()
        {
            return name;
        }
        public string getName() {
            return name;
        }
        public int getCost() {
            return price;
        }
        public int getRent() {
            if (getColour().Equals(Group.Utility))
            {
                return UtilityRent(getPlayer());
            }
            if (getColour().Equals(Group.Station))
            {
                return StationRent(getPlayer());
            }
            else { 
            return rent;
            }
            
        }
        public Player getPlayer() {
            return owner;
        }
        public String getOwner() {
            return owner.getName();
        }
        public void SetOwner(Player p) {
            owner = p;
        }
        public bool isBankOwned() {
            return bankOwned;
        }
        public void setBankOwned(bool a) {
            bankOwned = a;
        }
        public Enum getColour() {
            return colour;
        }



        /// <summary>
        /// method  called when a player mortgages the property. if it is owned by the bank then no rent is due
        /// </summary>
        /// <param name="val"></param>
        public void mortgageProperty()
        {
            if (bankOwned)
            {
                rent = 0;
                houseNo = 0;
                hasHotel = false;
            }
            else
            {
                bankOwned = false;
                rent = rentBase;
                     }
        }
       
        /// <summary>
        ///  This method returns the current number of houses
        /// </summary>
        /// <returns></returns>
        public int checkHouses() {
            return houseNo;
        }
        /// <summary>
        /// this method checks to see if there is a hotel at the property
        /// </summary>
        /// <returns></returns>
        public bool hotelCheck() {
            return hasHotel;
        }
        /// <summary>
        ///  method to change the value of the rent taken. dependant on the number of houses currently on the property
        /// </summary>
        /// <returns></returns>
        public string addHouse() {
            string s = "";
            if (!this.getColour().Equals(Group.Utility) || !this.getColour().Equals(Group.Station))
            {
                if (getPlayer().Checkgrouping(this))
                {
                    

                    if (this.checkHouses() < 4 && hasHotel == false)
                    {
                        houseNo = houseNo + 1;
                        s = ("number of houses is " + houseNo);
                        switch (houseNo)
                        {
                            case 1:
                                rent = rent1;
                                break;
                            case 2:
                                rent = rent2;
                                break;
                            case 3:
                                rent = rent3;
                                break;

                            case 4:
                                rent = rent4;
                                break;
                        }
                    }

                    else if (hasHotel == true)
                    {
                        s = ("there is already a hotel here. no more houses can be purchased");
                    }
                    else
                    {
                        s = ("there are already 4 houses. please buy a hotel");
                    }
                }
                else {
                    s = "you do not own all the"+getColour().ToString() +" properties";
                    MessageBox.Show(s);
                }
            }
            else if(this.getColour().Equals(Group.Utility)) {
                s = "You cannot add Houses to Utilites";
            }
            else if (this.getColour().Equals(Group.Station))
            {
                s = "You cannot add Houses to Stations";
            }
            return s;
        }
        /// <summary>
        /// This method converts the houses into a hotel. a new rent price is also assigned
        /// </summary>
        /// <returns></returns>
        public String convertHouseToHotel() {
            string s = "";
            if (!this.getColour().Equals(Group.Utility) || !this.getColour().Equals(Group.Station))
            {
                if (hasHotel == true)
                {
                    s = ("this property already has a hotel");
                }
                else if (houseNo < 4) { s = "there are not enough houses to make a hotel"; }
                else
                {
                    houseNo = 0;
                    hasHotel = true;
                    s = "this property now has a hotel";
                    rent = rentH;
                }
            }
            else if (this.getColour().Equals(Group.Utility))
            {
                s = "You cannot add Hotels to Utilites";
            }
            else if (this.getColour().Equals(Group.Station))
            {
                s = "You cannot add Hotels to Stations";
            }
            return s;
        }
        /// <summary>
        /// This method calculates the rent of the utility properties.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public int UtilityRent(Player p) {
            if (p.hasBothUtilities())
            {
                return 10 * p.getRollValue();
            }
            else {
                return 4 * p.getRollValue(); 
            }
        }
        public int StationRent(Player p) {

            switch (p.getNumOfStations())
            {
                case 1:
                    return 25;
                   
                case 2:
                    return 50;
                
                case 3:
                    return 100;
               
                case 4:
                    return 200;
               
               default:
                    return 0;

            }
        }


    }
}
