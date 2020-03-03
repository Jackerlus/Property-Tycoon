using System;
namespace Property_Tycoon
{
    public class Roll
    {
        private int numOfDoubles = 0;

        public String Rolls()
        {

            //Initiate dice
            Dice diceOne = new Dice();
            Dice diceTwo = new Dice();

            //Roll Dice
            int die1 = diceOne.rollDice();
            int die2 = diceTwo.rollDice();

            Boolean doubleCheck = isEqual(die1, die2);

            String consoleOutput = "";

            //Send result of dice roll to console
            consoleOutput += "Dice 1 returns " + die1;
            consoleOutput += "\nDice 2 returns " + die2;

            //Check for double
            if (doubleCheck) {
                consoleOutput += "\nDouble roll!";
            }
            consoleOutput += "\n------------------";
            return consoleOutput;
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
    }
}