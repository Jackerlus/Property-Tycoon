using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Forms;

namespace Property_Tycoon
{
    public class Human : Player
    {
        private int JAIL = 30;
        private int VISITING = 10;
        private int GO = 0;
        private int FREE = 20;

        public ArrayList properties;
        
        private String playerName;
        private int money;
        private int position;
        private bool inJail;
        private int jailTurn;
        private bool rollBan;
        private int numJailFree;
        private Piece piece;
        private bool PassedGo;
        private int turnCount;
        private bool isretired;
        int moveSpace;
  
      
        private Board CurrentGame;
        /// <summary>
        /// This method is the constructor to make a new Player Object.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="money"></param>

        /// <param name="cg"></param>
        public Human(string name, int money, Piece _piece, Board cg)
        {
            PassedGo = false;
            turnCount = 0;
            isretired = false;
            
            this.money = money;
            this.playerName = name;
            this.jailTurn = 0;
            this.numJailFree = 0;
            this.inJail = false;
            this.position = 0;
            piece = _piece;
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
                if (item.getColour().Equals(Group.Station) && item.getPlayer() == this)
                {

                    counter = counter +1;
                }
            }
            return counter;
        }



        /// <summary>
        /// This method adds to the get out of jail free cards part
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
        /// a method that adds to a property array
        /// </summary>
        /// <param name="p"></param>
        public void addToPropertyArray(Property p) {
            properties.Add(p);
        }
        /// <summary>
        /// Method that removes from the property array 
        /// </summary>
        /// <param name="p"></param>
        public void RemoveFromPropertyArray(Property p)
        {
            properties.Remove(p);
        }

        /// <summary>
        /// this method allows the user to purchase a property
        /// </summary>
        /// <param name="p"></param>
        public String buyProperty(Property p)
        {
            String s = "";
            if (HasPassedGo() == true)
            {
                if (p.isBankOwned())
                {
                    s = p.getName() + " aquired";
                    addmoney(-p.getCost());
                    p.setBankOwned(false);
                    p.SetOwner(this);
                    properties.Add(p);
                }

                else if (p.getPlayer() == this)
                {
                    s = "You already own this";
                }
                else if (getMoney() < p.getCost())
                {
                    s = " You cannot afford this property";
                }

                else
                {
                    s = p.getName() + " is owned by" + p.getOwner();
                }
            }
            else {
                s = "Please pass go before attempting to buy";
            }
            System.Windows.MessageBox.Show(s);
            return s;
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
            position = VISITING;
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
                p.mortgageProperty(p);
            }
        }
        /// <summary>
        /// a method to unmortgage a property 
        /// </summary>
        /// <param name="p"></param>
        public void UnMortgageProperty(Property p)
        {
            if (this.properties.Contains(p))
            {
                addmoney(-((p.getCost()/2)+Convert.ToInt32(0.1*p.getCost())));
                p.mortgageProperty(p);
                System.Windows.MessageBox.Show(" Property no longer has a mortgage");
            }
        }
        /// <summary>
        /// returns if the player has passed go
        /// </summary>
        /// <returns></returns>
        public bool HasPassedGo() {

            return PassedGo;
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
                PassedGo = true;
                setPosition(getPosition() % 39);
                CurrentGame.GoTile.action(getPlayer());

              
            }
            if (HasPassedGo() == true && CurrentGame.GetProperty(getPosition()) is Property)
            {
                if (CurrentGame.GetProperty(getPosition()).isBankOwned() == true)
                {
                    String message = "This property doesn't have an owner. Do you want to buy it?";
                    string caption = "Option to purchase "+ CurrentGame.GetProperty(getPosition()).getName();
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;

                    result = System.Windows.Forms.MessageBox.Show(message, caption, buttons);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        System.Windows.Forms.MessageBox.Show("" + getPosition());

                        if (CurrentGame.returnProperties()[this.getPosition()] is Property)
                        {
                            Property p = (Property)CurrentGame.returnProperties()[this.getPosition()];
                            this.buyProperty((Property)CurrentGame.returnProperties()[this.getPosition()]);

                        }
                        else
                        {
                            System.Windows.MessageBox.Show("you cannot buy this...");
                        }
                    }
                    else
                    {
                        new Auction(CurrentGame, CurrentGame.GetProperty(getPosition())).ShowDialog();
                    }

                }
            }
            if (getPosition() == 30) {
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
            if (getPosition() == 7|| getPosition() == 22|| getPosition()==36)
            {
                System.Windows.MessageBox.Show(" Opportunity knocks");
                CurrentGame.opportunities.action(this);
            }
            if (getPosition() == 2 || getPosition() == 33 || getPosition() == 17)
            {
                System.Windows.MessageBox.Show(" Pot Luck");
                CurrentGame.potLuck.action(this);
            }
            if (getPosition() == 4)
            {
                System.Windows.MessageBox.Show(CurrentGame.incomeTax.action(this));
            }
            if (getPosition() == 38)
            {
                System.Windows.MessageBox.Show(CurrentGame.SuperTax.action(this));
            }
            if (CurrentGame.GetProperty(getPosition()) != null)
            {
                if (CurrentGame.GetProperty(getPosition()).isBankOwned() == false) {
                    if (CurrentGame.GetProperty(getPosition()).getPlayer() != getPlayer() )
                    {
                        if (Checkgrouping(CurrentGame.GetProperty(getPosition())) == true)
                        {
                            CurrentGame.GetProperty(getPosition()).getPlayer().addmoney(CurrentGame.GetProperty(getPosition()).getRent() + CurrentGame.GetProperty(getPosition()).getRent());
                            addmoney(-CurrentGame.GetProperty(getPosition()).getRent() * 2);
                            System.Windows.MessageBox.Show("rent of " + CurrentGame.GetProperty(getPosition()).getRent() * 2 + " paid from " + getName() + " to " + CurrentGame.GetProperty(getPosition()).getOwner());
                        }
                        else { 
                            CurrentGame.GetProperty(getPosition()).getPlayer().addmoney(CurrentGame.GetProperty(getPosition()).getRent());
                            addmoney(-CurrentGame.GetProperty(getPosition()).getRent());
                            System.Windows.MessageBox.Show("rent of " + CurrentGame.GetProperty(getPosition()).getRent()  + " paid from " + getName() + " to " + CurrentGame.GetProperty(getPosition()).getOwner());


                        }

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
                    System.Windows.MessageBox.Show(moveSpace + "");
                    if (dice.getDie1() == dice.getDie2())
                    {
                        System.Windows.MessageBox.Show("Double 1!! both dice show " + dice.getDie1());

                        dice.Rolls();

                        moveSpace = moveSpace + dice.rollValue();

                        if (dice.getDie1() == dice.getDie2())
                        {
                            System.Windows.MessageBox.Show("Double 2 !! Again! both dice show " + dice.getDie1());
                            dice.Rolls();
                            moveSpace = moveSpace + dice.rollValue();


                            if (dice.getDie1() == dice.getDie2())
                            {
                                System.Windows.MessageBox.Show("Jail time for you");
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
                System.Windows.MessageBox.Show("No double.you remain in jail");
            }
             else if (inJail && jailTurn == 3)
            {
                leaveJail();
                addmoney(-50);
                rollBan = true;
                jailTurn = 0;
                System.Windows.MessageBox.Show("youve paid 50 and have left jail");
            }
            else 
            {
                System.Windows.MessageBox.Show("You have Previously Rolled please end your turn");
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
            turnCount++;
            rollBan = false;
        }
        /// <summary>
        ///  method to check if the player is in jail
        /// </summary>
        /// <returns></returns>
        public bool isInJail() {
            return inJail;
        }
        /// <summary>
        /// a method that returns a player
        /// </summary>
        /// <returns></returns>
        public Player getPlayer()
        {
            
            return this;
        }/// <summary>
        /// A method to return the image filepath
        /// </summary>
        /// <returns></returns>
        public String getPieceImg() {
            return piece.getfilePath();
        }
        /// <summary>
        /// A method that sees if the player owns the set of properties
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
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
            System.Windows.MessageBox.Show(""+flag);
            return flag;
        }
        /// <summary>
        /// a method that retires a player from the game
        /// </summary>
        public void retire()
        {
            foreach (Property item in properties)
            {
                isretired = true;
                item.retire();
                CurrentGame.removePlayer(this);
                System.Windows.MessageBox.Show("player withdrawn");
            }
        }
    }
    
}
