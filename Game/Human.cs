using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Property_Tycoon
{
    class Human : Player
    {
        private int JAIL = 31;
        private int VISITING = 11;
        private int GO = 0;
        private int FREE = 5;
        private int Pot1 = 3;
        private int Pot2 = 34;
        private ArrayList properties;
        
        private String playerName;
        private int money;
        private int position;
        private bool inJail;
        private int jailTurn;
        private bool rollBan;
        private int numJailFree;
        int moveSpace;
  
      
        private Board CurrentGame;

        public Human(string name, int money, int position, int playerno, Board cg)
        {
            
            this.money = money;
            this.playerName = name;
            this.jailTurn = 0;
            this.numJailFree = 0;
            this.inJail = false;
            this.position = position;
            this.properties = new ArrayList();
            moveSpace = 0;
 
            rollBan = false;
            CurrentGame = cg;
            
        }
        /// <summary>
        /// This method sets the current player postion
        /// </summary>
        /// <param name="val"></param>
        public void setPosition(int val) {
            position = val;
        }
        /// <summary>
        /// This method checks to see if the player owns both utilites
        /// </summary>
        /// <returns></returns>
        public bool hasBothUtilities() {
            int counter = 0;
            foreach (Property item in properties)
            {
                if (item.getColour().Equals(Group.Utility))
                {
                    counter++;
                }
            }
            return (counter == 2);
            
        }
        /// <summary>
        /// This method gets the number of Stations that the player has 
        /// </summary>
        /// <returns></returns>
        public int getNumOfStations()
        {
            int counter = 0;
            foreach (Property item in properties)
            {
                if (item.getColour().Equals(Group.Station))
                {
                    counter++;
                }
            }
            return counter;
        }


        /// <summary>
        /// this method adds to the get out of jail free cards part
        /// </summary>
        /// <param name="val"></param>
        public void addGetOutofJail(int val)
        {
            numJailFree++;
        }

        /// <summary>
        /// this method adds money to the players account
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public int addmoney(int val)
        {
            if (!inJail)
            {
                money = money + val;
                
            }
            return money;

        }
      
        /// <summary>
        /// this method allows the user to purchase a property
        /// </summary>
        /// <param name="p"></param>
        public String buyProperty(Property p)
        {
            String s = "";
            if (p.isBankOwned())
            {
                s = p.getName() + " aquired";
                money = money - p.getCost();
                p.setBankOwned(false);
                p.SetOwner(this);
                properties.Add(p);
            }

            else if (p.getPlayer() == this)
            {
                s = "You already own this";
            }
            else if (getMoney() < p.getCost()) {
                s = " You cannot afford this property";
            }

            else
            {
                s = p.getName() + " is owned by" + p.getOwner();
            }
            MessageBox.Show(s);
            return s;
        }

        public void drawcard() {
            
        }
        /// <summary>
        /// this method returns the number of get out of jail free cards avalible to the player.
        /// </summary>
        /// <returns></returns>
        public int getJailFreeNo()
        {
            return numJailFree;
        }

        /// <summary>
        /// this method allows the user to see how many turns left in jail they have.
        /// </summary>
        /// <returns></returns>
        public int getJailTurns()
        {
            return jailTurn;
        }


        /// <summary>
        /// returns the amount of money the player has
        /// </summary>
        /// <returns></returns>
        public int getMoney()
        {
            return money;
        }


        /// <summary>
        /// this method calls the GO tiles action method
        /// </summary>
        /// <param name="goSpace"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public String goSpace(Go goSpace,Player p) {
            goSpace.action(p);
            return "you have recieved 200";
        }


        /// <summary>
        /// returns player name
        /// </summary>
        /// <returns></returns>
        public string getName()
        {
            return playerName;
        }


        /// <summary>
        /// returns property list
        /// </summary>
        /// <returns></returns>
        public ArrayList getProperties()
        {
            return properties;
        }


        /// <summary>
        /// this method gets the names of the properties
        /// </summary>
        /// <returns></returns>
        public ArrayList getPropertyNames() {
            ArrayList names = new ArrayList();
            String s;
            foreach (Property item in getProperties())
            {
                s = item.getName();
                names.Add(s);
            }
            return names;
        }
        /// <summary>
        /// this method returns the property at the index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Property GetProperty(int index) {
            return (Property)properties[index];
        }
        /// <summary>
        /// method that simulates jail
        /// </summary>
        public void goToJail()
        {
            inJail = true;
            jailTurn = 0;
            position = VISITING;
        }
        /// <summary>
        /// method that simulates leaving jail
        /// </summary>
        public void leaveJail()
        {
            money = money - 50;
            jailTurn = 0;
            inJail = false;
        }
        /// <summary>
        /// method to mortgage a property
        /// </summary>
        /// <param name="p"></param>
        public void MortgageProperty(Property p)
        {
            if (this.properties.Contains(p))
            {
                money = money + (p.getCost() / 2);
                p.mortgageProperty();
            }
        }
        /// <summary>
        /// method to move a player around the board
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public int move(int val)
        {
            setPosition(getPosition() + val);
            if (getPosition() > 40 && position != JAIL)
            {
                setPosition(getPosition() % 40);
                CurrentGame.GoTile.action(getPlayer());
            }               
            if (getPosition() == JAIL) {
                   goToJail();
               }
            if (getPosition() == FREE)
            {
                CurrentGame.justVising.action(getPlayer());
            }
            if (getPosition()== GO)
            {
                CurrentGame.GoTile.action(getPlayer());
            }
            if (getPosition() == 8 || getPosition() == 23)
            {
                MessageBox.Show(" Opportunity knocks");
                CurrentGame.opportunities.action(this);
            }
            if (getPosition() == Pot1 || getPosition() == Pot2)
            {
                MessageBox.Show(" PotLuck");
                CurrentGame.potLuck.action(this);
            }
            if (getPosition() == 5)
            {
                MessageBox.Show(CurrentGame.incomeTax.action(this));
            }
            if (getPosition() == 39)
            {
                MessageBox.Show(CurrentGame.SuperTax.action(this));
            }
            if (CurrentGame.GetProperty(getPosition()) != null)
            {
                if (CurrentGame.GetProperty(getPosition()).isBankOwned() == false) {
                    if (CurrentGame.GetProperty(getPosition()).getPlayer() != getPlayer() )
                    {
                     CurrentGame.GetProperty(getPosition()).getPlayer().addmoney(CurrentGame.GetProperty(getPosition()).getRent());
                    addmoney(-CurrentGame.GetProperty(getPosition()).getRent());
                    MessageBox.Show("rent of " + CurrentGame.GetProperty(getPosition()).getRent()+" paid from " + getName() +" to " + CurrentGame.GetProperty(getPosition()).getOwner());
                    }
                    
                }
            }



            return position;
        }

        /// <summary>
        /// methood to get the value of the dice roll
        /// </summary>
        /// <returns></returns>

        public int getRollValue()
        {
            return moveSpace;
        }

        /// <summary>
        /// this method rolls the dice classes and returns a result. unless there is a double the user cannot roll again. if there are 
        /// too many doubles in a row then the current player is sent to jail
        /// </summary>
        /// <returns></returns>
        public String rolldice()
        {   
            Roll dice = new Roll();
            dice.Rolls();
            moveSpace = 0;
            if (rollBan == false)
            {


                if (isInJail() == false)
                {

                    moveSpace = moveSpace + dice.rollValue();
                    MessageBox.Show(moveSpace + "");
                    if (dice.getDie1() == dice.getDie2())
                    {
                        MessageBox.Show("Double 1!! both dice show " + dice.getDie1());

                        dice.Rolls();

                        moveSpace = moveSpace + dice.rollValue();

                        if (dice.getDie1() == dice.getDie2())
                        {
                            MessageBox.Show("Double 2 !! Again! both dice show " + dice.getDie1());
                            dice.Rolls();
                            moveSpace = moveSpace + dice.rollValue();


                            if (dice.getDie1() == dice.getDie2())
                            {
                                MessageBox.Show("Jail time for you");
                                goToJail();
                                moveSpace = VISITING;
                            }
                        }
                    }
                    rollBan = true;

                }
                move(moveSpace);
            }
            else if (inJail && jailTurn < 3 && dice.getDie1() == dice.getDie2())
            {

                jailTurn++;
                rollBan = true;
                MessageBox.Show("No double.you remain in jail");
            }
            else if (inJail && jailTurn == 3)
            {
                leaveJail();
                addmoney(-50);
                rollBan = true;
                jailTurn = 0;
                MessageBox.Show("youve paid 50 and have left jail");
            }
            else 
            {
                MessageBox.Show("You have Previously Rolled please end your turn");
            }

            return "";
        }



        /// <summary>
        /// this method moves to moves the player to a position specified buy pos
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public int moveto(int pos)
        {
            position = pos;
            return position;
        }
        /// <summary>
        /// this method adds to the current players get out of jail free cards 
        /// </summary>
        public void addGetOutOfJail() {
            numJailFree++;
        }
        /// <summary>
        /// method that uses a get of jail free card;
        /// </summary>
        /// <returns></returns>
        public String useGetOutofJail()
        {
            String s = "";
            if (numJailFree > 0)
            {
                jailTurn = 0;
                inJail = false;
                numJailFree--;
                s = ("you have " + numJailFree + " get out of free jail cards left");

            }
            else {
                s = "You are out of jail";
            }
            return s;
        }
        /// <summary>
        /// method to get the current position of a player
        /// </summary>
        /// <returns></returns>
        public int getPosition() { return position; }
        /// <summary>
        /// method that ends the players turn
        /// </summary>
        public void endTurn() {
            rollBan = false;
        }
        /// <summary>
        ///  method to check if the player is in jail
        /// </summary>
        /// <returns></returns>
        public bool isInJail() {
            return inJail;
        }

        public Player getPlayer()
        {
            return this;
        }

        public bool Checkgrouping(Property p) {
            ArrayList temp = CurrentGame.getList(p);
            int counter = 0;
            bool flag = true;
            while (flag == true && counter < temp.Count)
            {
                if (temp[counter] is Property)
                {
                    Property T = (Property)temp[counter];
                    if (T.getPlayer() == getPlayer())
                    {
                        flag = true;
                    }
                    else {
                        flag = false;
                    }
                }
                counter++;
            }
            return flag;
        }



        
    }
    
}
