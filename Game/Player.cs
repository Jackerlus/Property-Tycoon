using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Property_Tycoon
{
    public interface Player
    {
        /// <summary>
        /// method that ends the players turn
        /// </summary>
        void endTurn();

        /// <summary>
        /// method to get the current position of a player
        /// </summary>
        /// <returns></returns>
        int getPosition();
        /// <summary>
        /// returns player name
        /// </summary>
        /// <returns></returns>
        string getName();
        /// <summary>
        /// Method that removes from the property array 
        /// </summary>
        /// <param name="p"></param>
        void RemoveFromPropertyArray(Property p);
        /// <summary>
        /// a method that adds to a property array
        /// </summary>
        /// <param name="p"></param>
        void addToPropertyArray(Property p);
        String buyProperty(Property p);
        /// <summary>
        /// this method adds to the current players get out of jail free cards 
        /// </summary>
        void addGetOutOfJail();
        /// <summary>
        /// this method rolls the dice classes and returns a result. unless there is a double the user cannot roll again. if there are 
        /// too many doubles in a row then the current player is sent to jail
        /// </summary>
        /// <returns></returns>
        String rolldice();
        /// <summary>
        /// This method checks to see if the player owns both utilites
        /// </summary>
        /// <returns></returns>
        bool hasBothUtilities();

        /// <summary>
        /// methood to get the value of the dice roll
        /// </summary>
        /// <returns></returns>
        int getRollValue();

        int move(int val);
        /// <summary>
        /// this method moves to moves the player to a position specified buy pos
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        int moveto(int pos);
        int  getMoney();
        /// <summary>
        /// method to mortgage a property
        /// </summary>
        /// <param name="p"></param>
        void MortgageProperty(Property p);
        /// <summary>
        /// returns property list
        /// </summary>
        /// <returns></returns>
        ArrayList getProperties();
        ArrayList getPropertyNames();
        /// <summary>
        /// this method returns the property at the index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        Property GetProperty(int index);
        /// <summary>
        /// method to get the current position of a player
        /// </summary>
        /// <returns></returns>
        void setPosition(int val);
        /// <summary>
        /// this method adds money to the players account
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        int addmoney(int val);
        /// <summary>
        /// method that simulates leaving jail
        /// </summary>
        void leaveJail();
        /// <summary>
        /// A method that sends the player to jail
        /// </summary>
        void goToJail();
        /// <summary>
        /// method that uses a get of jail free card;
        /// </summary>
        /// <returns></returns>
        string useGetOutofJail();
        /// <summary>
        /// a method that returns a player
        /// </summary>
        /// <returns></returns>
        public Player getPlayer();
        /// <summary>
        /// this method adds to the current players get out of jail free cards 
        /// </summary>
        void addGetOutofJail(int val);
        /// <summary>
        /// a method that shows remaining jail free cards
        /// </summary>
        /// <returns>Int</returns>
        int getJailFreeNo();
        /// <summary>
        /// A method that says how many turns the user has been in jail for
        /// </summary>
        /// <returns>integer</returns>
        int getJailTurns();
        /// <summary>
        /// A boolean that checks if the user is in jail
        /// </summary>
        /// <returns>boolean</returns>
        bool isInJail();
        /// <summary>
        /// This method gets the number of Stations that the player has 
        /// </summary>
        /// <returns></returns>
        int getNumOfStations();
        String getPieceImg();
        /// <summary>
        /// A method that sees if the player owns the set of properties
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        bool Checkgrouping(Property p);
  
        /// <summary>
        /// a method that retires a player from the game
        /// </summary>
        void retire();
        /// <summary>
        /// returns if the player has passed go
        /// </summary>
        /// <returns></returns>
        bool HasPassedGo();
    }
}
