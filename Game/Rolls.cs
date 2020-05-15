using System;
namespace Property_Tycoon
{
    /// <summary>
    /// class for each roll of the dice
    /// </summary>
    public class Roll
    {
        //class variables 
        private int numOfDoubles;
        private int sumOfDice;
        private int die1, die2;
        private Dice diceOne;
        private Dice diceTwo;
        /// <summary>
        /// constuctor for the class
        /// </summary>
        public Roll() {
            diceOne = new Dice();
            diceTwo = new Dice();
            numOfDoubles = 0;
            sumOfDice = 0;
        }
        
        /// <summary>
        /// this method rolls the two dice objects
        /// </summary>
        /// <returns> the sum of the two dice objects</returns>
        public int Rolls(int seed)
        {
            //Roll Dice
             die1 = diceOne.rollDice(seed);
             die2 = diceTwo.rollDice(seed);

            sumOfDice = die1 + die2;
            numOfDoubles++;
            return sumOfDice;
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
        /// <summary>
        /// gets the sum of the two dice variables
        /// </summary>
        /// <returns>returns sum of dice variable</returns>
        public int rollValue() {
            return sumOfDice;
        }
        /// <summary>
        /// gets the value of the dice number
        /// </summary>
        /// <returns>integer value of the roll function of die one </returns>
        public int  getDie1() {
            return die1;    
        }
        /// <summary>
        /// gets the value of the dice number
        /// </summary>
        /// <returns>integer value of the roll function of die two </returns>
        public int getDie2()
        {
            return die2;
        }
        /// <summary>
        /// This method gets the number of doubles
        /// </summary>
        /// <returns> current number of doubles </returns>
        public int getDoubleCounter() {
            return numOfDoubles;
        }
        /// <summary>
        /// this method checks to see if the dice are equal
        /// </summary>
        /// <param name="val1"></param>
        /// <param name="val2"></param>
        /// <returns> boolean value. True if val 1 is equal to val 2</returns>
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
        /// <summary>
        /// message when both dice are rolled
        /// </summary>
        /// <returns>A string if the dice are equal</returns>
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