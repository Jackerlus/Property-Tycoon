using System;

namespace Monopoly
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

    public class Property{

        private string propertyName;
        private Boolean isOwned;
        private int houseCount;
        private Boolean hotel;
        // private Player owner;
        private int rent;
        private int price;
        private Boolean isMorgaged;
        private int MorgagePrice;

        public Property( string Name,int initalRent, int cost, int Morgagecost){

            rent = initalRent;
            price = cost;
            MorgagePrice = Morgagecost;
            houseCount = 0;
            hotel = false;
            // owner = " ";
            propertyName = Name;
            isMorgaged = false;
            isOwned = false;
        }
        public int addHouse(int newRentVal){
            if (houseCount > 4){
                houseCount = 0;
                hotel = true;
                rent = newRentVal;
            }
            houseCount ++;
            rent = newRentVal;
        }
        public void morgageProperty(){
            isMorgaged = true;
        }
        public void unMorgageProperty(){

            isMorgaged = false;
        }
        public Boolean isMorgaged(){
            return isMorgaged;
        }
        public string getOwner(){
            return owner;
        }
        public void setOwner( string name){
            owner = name;
        }
        public int getRent(){
            return rent;
        }
        public void getNumberOfHouses(){
            console.WriteLine("There are "+houseCount+" number of houses");

    }

    public class Roll
    {
        private int numOfDoubles = 0;
        Dice diceOne = new Dice();
        Dice diceTwo = new Dice();

        public void rolls()
        {
            int die1 = diceOne.rollDice();
            int die2 = diceTwo.rollDice();
            Boolean doubleCheck = IsEqual(die1, die2);
            if (doubleCheck)
            {
                Console.WriteLine("Die 1 returns " + die1 + " and Die 2 returns " + die2 + " which are doubles!");
                Console.WriteLine("The streak of doubles is equal to: " + numOfDoubles);
                if (numOfDoubles > 2)
                {
                    Console.WriteLine("Caught 'speeding', Go to Jail!");
                    numOfDoubles = 0;

                }
            }
            else
            {
                Console.WriteLine("Die 1 returns " + die1 + " and Die 2 returns " + die2 + " which are not doubles!");
                Console.WriteLine("The streak of doubles is equal to: " + numOfDoubles);
            }
        }
        public Boolean IsEqual(int val1, int val2)
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

    class Program
    {
        static void Main(string[] args)
        {
            // Roll roll1 = new Roll();
            // for (int i = 1; i <= 100; i++)
            // {
            //     roll1.rolls();
            // }
            Property p = new Property("BTN station", 22, 300,150);
            p.getNumberOfHouses;


        }
    }
}

