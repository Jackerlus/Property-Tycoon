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
    }
    class IncomeTax : Space, NonProperties
    {
        public IncomeTax(int position) : base(position)
        {

        }

        public string action(Player player)
        {
            String s = " you have paid $200";
            player.addmoney(-200);
            return s;
        }
    }
    class Opportunity : Space, NonProperties
    {
        Cards c;
        public Opportunity(int position,Cards Deck) : base(position)
        {

             c = Deck;
        }

        public string action(Player p)
        {
           
            c.drawOppKnocks(p);
                return "";
        }
    }
    class Pot : Space, NonProperties
    {
        
        
        Cards c;
        public Pot(int position, Cards Deck) : base(position)
        {
            c = Deck;

        }

        public string action(Player p)
        {

            c.drawPotLuck(p);

            return "";
        }
    }


    class SuperTax : Space, NonProperties
    {
        public SuperTax(int position) : base(position)
        {

        }

        public string action(Player player)
        {
            String s = " you have paid $100";

            player.addmoney(-100);
            return s;
        }
    }


    /// <summary>
    /// class for the goal tile
    /// </summary>
    class Go : Space, NonProperties
    {
        public Go(int position) : base(position)
        {

        }

        public string action(Player p)
        {
            p.addmoney(200);
            string s = "you have recieved $200";
            return s;
        }
    }
    /// <summary>
    /// class for the go to jail tile
    /// </summary>
    class GoToJail : Space, NonProperties
    {
        public GoToJail(int position) : base(position)
        {

        }

        public string action(Player player) {
            player.goToJail();
            String s = "thats it youre in jail buckeroo";
            return s;
        }
    }
    /// <summary>
    /// This class is for the just visining tile
    /// </summary>
    class Visting : Space, NonProperties
    {
        public Visting(int position) : base(position)
        {

        }

        public string action(Player player)
        {
            String s = "";
            return s;
        }
    }

    /// <summary>
    /// class for the free parking tile
    /// </summary>
    class FreeParking : Space, NonProperties {
        private int FreeMoney;
        public FreeParking(int position) : base(position)
        {
            FreeMoney = 0;

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

}
        }

    
   

