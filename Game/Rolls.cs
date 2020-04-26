using System;
namespace Property_Tycoon
{
    public class Roll
    {
        private int numOfDoubles;
        private int sumOfDice;
        private int die1, die2;
        private Dice diceOne;
        private Dice diceTwo; 

        public Roll() {
            diceOne = new Dice();
            diceTwo = new Dice();
            numOfDoubles = 0;
            sumOfDice = 0;
        }
        public int Rolls()
        {
            //Roll Dice
             die1 = diceOne.rollDice();
             die2 = diceTwo.rollDice();

            sumOfDice = die1 + die2;
            numOfDoubles++;
            return sumOfDice;
        }
        public int rollValue() {
            return sumOfDice;
        }
        public int  getDie1() {
            return die1;    
        }
        public int getDie2()
        {
            return die2;
        }
        public int getDoubleCounter() {
            return numOfDoubles;
        }

        public Boolean isEqual(int val1, int val2)
        {
            //Check if dice are equal
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
        public string DiceRollsText()
        {

            String consoleOutput = "";

            //Send result of dice roll to console
            consoleOutput += "Dice 1 returns " + die1;
            consoleOutput += "\nDice 2 returns " + die2;

            //Check for double
            if (isEqual(die1,die2))
            {
                consoleOutput += "\nDouble roll!";
            }
            consoleOutput += "\n------------------";
            return consoleOutput;

        }
    }
}