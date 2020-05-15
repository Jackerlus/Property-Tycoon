using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Property_Tycoon
{
    /// <summary>
    /// interface for the non purchaceable tiles
    /// </summary>
    public interface  NonProperties {
       
        string action(Player p);
        string action(Player p , int a);
        String getName();
    }
    /// <summary>
    /// this is the Income Tax Class
    /// </summary>
    public class IncomeTax : Space, NonProperties
    {
        public IncomeTax(int position) : base(position)
        {

        }
        /// <summary>
        /// this method returns the name of the class
        /// </summary>
        /// <returns></returns>
        public String getName() {
            return "Income Tax"; ;
        }
        /// <summary>
        /// this method adds 200 to the players money
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public string action(Player player)
        {
            String s = " you have paid $200";
            player.addmoney(-200);
            return s;
        }

        public string action(Player p, int a)
        {
            throw new NotImplementedException();
        }
    }
    /// <summary>
    /// this method is for the Opportunity class
    /// </summary>
    public class Opportunity : Space, NonProperties
    {
        Cards c;
        public Opportunity(int position,Cards Deck) : base(position)
        {

             c = Deck;
        }
 /// <summary>
 /// this method returns the name of the class
 /// </summary>
 /// <returns>String</returns>
        public String getName()
        {
            return "Opportinity Knocks"; ;
        }
        /// <summary>
        /// this method draws an opportunity knocks card
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public string action(Player p)
        {
           
            c.drawOppKnocks(p);
                return "";
        }
        public string action(Player p, int a)
        {

            c.drawOppKnocks(p,1);
            return "";
        }
    }
    /// <summary>
    /// this is the class for the Pot Luck class
    /// </summary>
    public class Pot : Space, NonProperties
    {
        
        
        Cards c;
        public Pot(int position, Cards Deck) : base(position)
        {
            c = Deck;

        }
        /// <summary>
        /// this method returns the name
        /// </summary>
        /// <returns></returns>
        public String getName()
        {
            return "Pot Luck"; ;
        }
        /// <summary>
        /// this method draws from the pot luck
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public string action(Player p)
        {

            c.drawPotLuck(p);

            return "";
        }
        public string action(Player p, int a)
        {

            c.drawPotLuck(p,1);

            return "";
        }
    }

    /// <summary>
    /// This is the class for the Super tax class
    /// </summary>
    public class SuperTax : Space, NonProperties
    {
        public SuperTax(int position) : base(position)
        {

        }
        
        public String getName()
        {
            return "Super Tax" ;
        }

        public string action(Player player)
        {
            String s = " you have paid $100";

            player.addmoney(-100);
            return s;
        }

        public string action(Player p, int a)
        {
            throw new NotImplementedException();
        }
    }


    /// <summary>
    /// class for the goal tile
    /// </summary>
   public class Go : Space, NonProperties
    {
        public Go(int position) : base(position)
        {

        }
        public String getName()
        {
            return "Go"; ;
        }

        public string action(Player p)
        {
            p.addmoney(200);
            string s = "you have recieved $200";
            return s;
        }

        public string action(Player p, int a)
        {
            throw new NotImplementedException();
        }
    }
    /// <summary>
    /// class for the go to jail tile
    /// </summary>
    public class GoToJail : Space, NonProperties
    {
        public GoToJail(int position) : base(position)
        {

        }
        public String getName()
        {
            return "Jail"; ;
        }

        public string action(Player player) {
            player.goToJail();
            String s = "thats it youre in jail buckeroo";
            return s;
        }

        public string action(Player p, int a)
        {
            throw new NotImplementedException();
        }
    }
    /// <summary>
    /// This class is for the just visining tile
    /// </summary>
    public class Visting : Space, NonProperties
    {
        public Visting(int position) : base(position)
        {

        }
        String name;
        public String getName()
        {
            return "Just Visiting"; ;
        }

        public string action(Player player)
        {
            String s = "";
            return s;
        }

        public string action(Player p, int a)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// class for the free parking tile
    /// </summary>
    public class FreeParking : Space, NonProperties {
        private int FreeMoney;
        public FreeParking(int position) : base(position)
        {
          
            FreeMoney = 0;

        }
    
        public String getName()
        {
            return "Free Parking"; ;
        }
        /// <summary>
        /// This method adds money to the Free parking tile
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public void addMoney(int value) {
            FreeMoney = FreeMoney + value;
        }
        /// <summary>
        /// this version of action gives the player that has landed on the space all the money in free parking
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public string action(Player p)
            {
            p.addmoney(FreeMoney);
            FreeMoney = 0;
            string s = "Fines collected";
            return s;
        }

        public string action(Player p, int a)
        {
            throw new NotImplementedException();
        }
    }
        }

    
   

