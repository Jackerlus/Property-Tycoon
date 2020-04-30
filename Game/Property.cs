using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Property_Tycoon
{

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
        private bool ismortgaged;


        private bool hasHotel;
        private Group colour; 

        private int houseNo;


        // public Player owner { get { return owner; }set { owner = value; } }
        /// <summary>
        /// constructor for the class
        /// </summary>
        /// <param name="position">The current position of the property</param>
        /// <param name="_price">The cost to buy the property</param>
        /// <param name="_name">The name of the property </param>
        /// <param name="_rent"> The current rent of the property</param>
        /// <param name="_bankOwned"> Boolean to see if the bank owns the property</param>
        /// <param name="_colour"> Current Group that the property belongs to </param>
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
            ismortgaged = false;
        }
        public void setMortgaged(bool value) {
            ismortgaged = value;
        }
        
        public bool getMortgaged()
        {
            return ismortgaged;
        }
        public int getRent1() {
            return rentBase;
        }
        public int getRent2()
        {
            return rent1;
        }
        public int getRent3()
        {
            return rent2;
        }
        public int getRent4()
        {
            return rent3;
        }
        public int getRent5()
        {
            return rent4;
        }
        public int getHotel()
        {
            return rentH;
        }
        /// <summary>
        /// gets the name of the property
        /// </summary>
        /// <returns>String Value. name variable</returns>
        public string getName() {
            return name;
        }
        /// <summary>
        /// Gets the Cost of the property 
        /// </summary>
        /// <returns>price variable</returns>
        public int getCost() {
            return price;
        }
        /// <summary>
        /// This method returns the current Rent of the property
        /// </summary>
        /// <returns> rent variable</returns>
        public int getRent() {
            if (getColour().Equals(Group.Utility))
            {
                rent = UtilityRent(getPlayer());

            }
            if (getColour().Equals(Group.Station))
            {
                rent = StationRent(getPlayer());
            }
            else { }
            return rent;
            
            
        }
        /// <summary>
        /// returns the player that currently owns the builing
        /// </summary>
        /// <returns>Owner Obejct</returns>
        public Player getPlayer() {
            return owner;
        }
        /// <summary>
        /// returns the current owners name 
        /// </summary>
        /// <returns>String value. Owners name</returns>
        public String getOwner() {
            return owner.getName();
        }
        /// <summary>
        /// sets the owner of property
        /// </summary>
        /// <param name="p"></param>
        public void SetOwner(Player p) {
            owner = p;
        }
        /// <summary>
        /// checks to see if the bank owns the property
        /// </summary>
        /// <returns>Boolean value. True if the property is owned by the bank</returns>
        public bool isBankOwned() {
            return bankOwned;
        }
        /// <summary>
        /// sets the boolean if the bank owns the property or not
        /// </summary>
        /// <param name="a">boolean value to be assigned to the bankOwned variable</param>
        public void setBankOwned(bool a) {
            bankOwned = a;
        }
        /// <summary>
        /// returns The enum value of the group that the property belongs to
        /// </summary>
        /// <returns> Enum value of the group</returns>
        public Enum getColour() {
            return colour;
        }



        /// <summary>
        /// Method  called when a player mortgages the property. if it is owned by the bank then no rent is due
        /// </summary>
        public void mortgageProperty(Property p)
        {
            if (p.isBankOwned() == false)
            {
                rent = 0;
                houseNo = 0;
                hasHotel = false;
                setBankOwned(true);
                MessageBox.Show(p.getName() + " has been mortgaged");
            }
            else { 
            MessageBox.Show(p.getName() + " has already been mortgaged");
            }
        }

        public void UnmortgageProperty(Property p)
        {
            if (p.isBankOwned() == true)
            {
                setBankOwned(false);
                rent = rentBase;
                MessageBox.Show(p.getName() + " Un-mortgaged");
            }
            else
            {
                MessageBox.Show(p.getName() + " never had a mortgage");
            }
        }


        /// <summary>
        ///  This method returns the current number of houses
        /// </summary>
        /// <returns>integer value. current number of houses</returns>
        public int checkHouses() {
            return houseNo;
        }
        /// <summary>
        /// this method checks to see if there is a hotel at the property
        /// </summary>
        /// <returns>boolean value . True if there is a hotel</returns>
        public bool hotelCheck() {
            return hasHotel;
        }
        /// <summary>
        ///  method to change the value of the rent taken. dependant on the number of houses currently on the property
        /// </summary>
        /// <returns></returns>
        public string addHouse() {
            string s = "";
            if (this.getColour().Equals(Group.Utility))
            {
                s = "You cannot add Houses to Utilites";
            }
            if (this.getColour().Equals(Group.Station))
            {
                s = "You cannot add Houses to Stations";
            }
            if (!this.getColour().Equals(Group.Utility) || !this.getColour().Equals(Group.Station))
            {
                if (getPlayer().Checkgrouping(this))
                {
                    

                    if (this.checkHouses() < 4 && hasHotel == false)
                    {
                        houseNo = houseNo + 1;
                        getPlayer().addmoney(-getHouseCost());
                        s = ("Number of houses is " + houseNo);
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
                    s = "you do not own all the "+ getColour().ToString() +" properties";
                   
                }
                if (this.getColour().Equals(Group.Utility))
                {
                    s = "You cannot add Houses to Utilites";
                }
                if (this.getColour().Equals(Group.Station))
                {
                    s = "You cannot add Houses to Stations";
                }
            }
            MessageBox.Show(s);
            return s;
        }
        /// <summary>
        /// Method checks the group cost and returns a value of the cost to buld a house
        /// </summary>
        /// <returns></returns>
        private int getHouseCost()
        {
            switch (getColour())
            {
                case Group.Brown:
                    return 50;
                case Group.Blue:
                    return 50;
                case Group.Deep_Blue:
                    return 200;
                case Group.Green:
                    return 200;
                case Group.Orange:
                    return 100;
                case Group.Purple:
                    return 100;
                case Group.Red:
                    return 150 ;
                case Group.Yellow:
                    return 150;
                default:
                    return 0;
            }
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
             if (this.getColour().Equals(Group.Utility))
            {
                s = "You cannot add Hotels to Utilites";
            }
             if (this.getColour().Equals(Group.Station))
            {
                s = "You cannot add Hotels to Stations";
            }
            return s;
        }
        /// <summary>
        /// This method calculates the rent of the utility properties.
        /// </summary>
        /// <param name="p">current player</param>
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
        /// <summary>
        /// This method calculates the rent of the Station properties.
        /// </summary>
        /// <param name="p">current player</param>
        /// <returns></returns>
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
