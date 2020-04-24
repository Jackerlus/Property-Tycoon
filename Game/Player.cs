﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Property_Tycoon
{
    public interface Player
    {
        void endTurn();
        int getPosition();
        string getName();
        String buyProperty(Property p);
        void addGetOutOfJail();
        String rolldice();
        int getRollValue();
        int move(int val);
        int moveto(int pos);
        int  getMoney();
        void MortgageProperty(Property p);
        ArrayList getProperties();
        int addmoney(int val);
        void leaveJail();
        void goToJail();
        string useGetOutofJail();
        public Player getPlayer();
        void addGetOutofJail(int val);
        int getJailFreeNo();
        int getJailTurns();
        bool isInJail();
        
    }
}
