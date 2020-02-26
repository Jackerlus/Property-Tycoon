using System;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Roll roll1 = new Roll();
            for (int i = 1; i <= 10; i++)
            {
                roll1.rolls();
            }
            Console.ReadLine();
        }

        /*
        static void Main(string[] args)
        {
            Dice diceOne = new Dice();
            Dice diceTwo = new Dice();
            for (int s = 0; s < 6; s++)
            {
                Console.WriteLine("dice 1 returns " + diceOne.rollDice() + " ");
                Console.WriteLine("dice 1 returns " + diceOne.rollDice() + " ");
                Console.WriteLine(" ");
            }
        }
        */
    }
}
