﻿using System;
namespace Game
{
    public class Roll
    {
        private int numOfDoubles = 0;
        Dice diceOne = new Dice();
        Dice diceTwo = new Dice();

        public void rolls()
        {
            int die1 = diceOne.rollDice();
            int die2 = diceTwo.rollDice();
            Boolean doubleCheck = isEqual(die1, die2);
            if (doubleCheck)
            {
                Console.WriteLine("Die 1 returns " + die1 + " and Die 2 returns " + die2 + " which are doubles!");
                Console.WriteLine("The streak of doubles is equal to: " + numOfDoubles);
            }
            else
            {
                Console.WriteLine("Die 1 returns " + die1 + " and Die 2 returns " + die2 + " which are not doubles!");
                Console.WriteLine("The streak of doubles is equal to: " + numOfDoubles);
            }
        }

        public Boolean isEqual(int val1, int val2)
        {
            if (val1 == val2)
            {
                numOfDoubles++;
                return true;
            }
            else
            {
                numOfDoubles = 0;
                return false;
            }
        }
    }
}