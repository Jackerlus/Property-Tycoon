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
        private int playerNumber;
        private bool justVisiting;
        private bool rollBan;
        private int numJailFree;
        private Roll roll;
        private int rollcounter;
        private int goTile;
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
            rollcounter = 0;
            roll = new Roll();
            rollBan = false;
            CurrentGame = cg;
            
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
                s = p.getName()+"aquired";
                money = money - p.getCost();
                p.setBankOwned(false);
                p.SetOwner(this);
                properties.Add(p);
            }

            else if (p.getPlayer() == this)
            {
                s = "you already own this";
            }

            else {
                s = "this property is owned by" + p.getName();
            }
      
            return s;
        }

        public void drawcard() {
            
        }

        public int getJailFreeNo()
        {
            return numJailFree;
        }

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
                if (!inJail)
                {
                    position = position + val;
                    if (position > 40 && position != JAIL)
                    {
                        position = position % 40;
                        
                    }
                    if (position == JAIL) {
                        goToJail();

                    }
                    if (position == GO)
                    {
                    CurrentGame.GoTile.action(this);
                    }
                    if (position == FREE)
                    {
                    CurrentGame.justVising.action(this);
                    }
                    if (position == Pot1 || position == Pot2) {
                        MessageBox.Show(" PotLuck");
                        CurrentGame.potLuck.action(this);
                    }
                    if (position == 8 || position == 23)
                    {
                        MessageBox.Show(" Opportunity knocks");
                        CurrentGame.opportunities.action(this);
                    }
            }
            
            
            return position;
        }
        /// <summary>
        /// methood to gget the value of the dice roll
        /// </summary>
        /// <returns></returns>

        public int getRollValue()
        {
            return roll.rollDice();
        }
        /// <summary>
        /// this method rolls the dice classes and returns a result. unless there is a double the user cannot roll again. if there are 
        /// too many doubles in a row then the current player is sent to jail
        /// </summary>
        /// <returns></returns>
        public String rolldice()
        {
            String s = "";
            if (rollBan == false)
            {
                roll.Rolls();
                
                if (!inJail)
                {

                    move(roll.Rolls());
                    if (roll.isEqual(roll.getDie1(), roll.getDie2()))
                    {
                        s = "Double "+roll.getDie1()+"!! roll again ";
                        move(getRollValue());
                        rollBan = false;
                        return s;
                    }

                    if (roll.getDoubleCounter() == 3)
                    {
                        goToJail();
                        s = "third double to jail you go";
                        rollBan = true;
                    }
                    else {
                        rollBan = true;
                    }
                    
                }

                else if (getPosition() == JAIL && inJail && jailTurn < 3)
                {
                    jailTurn++;
                    s = "No double. you remain in jail";
                    rollBan = true;
                }
                else if (getPosition() == JAIL && inJail && jailTurn == 3)
                {
                    leaveJail();

                    s = "youve paid 50 and have left jail";
                    addmoney(-50);
                    move(getRollValue());
                    rollBan = true;
                }

            }
            else {
                s = "you have previously rolled. end turn";
                }
            MessageBox.Show(s);
            return s;

        }

        public int moveto(int pos)
        {

            position = pos;
            MessageBox.Show("this is the new position" + position);
            return position;
        }
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
        /*
        public String checkRent() {
            if (this.position == pr)
            {

            } 
        }*/
    }
    
}
