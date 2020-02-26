﻿
using System;

namespace Game
{
    public class Dice
    {

        private int counter;
        private Random randomiser = new Random();

        private void setDice(int die)
        {
            counter = die;
        }
        private int getDieValue()
        {
            return counter;
        }
        public int rollDice()
        {
            int value = randomiser.Next(6) + 1;
            setDice(value);
            return value;
        }

    }
}