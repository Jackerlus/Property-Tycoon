using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;

namespace Property_Tycoon
{
    public class Board
    {
        public ArrayList properties;
        public ArrayList Tiles = new ArrayList(40);
        public ArrayList Brown = new ArrayList();
        public ArrayList Blue = new ArrayList();
        public ArrayList Purple = new ArrayList();
        public ArrayList Orange = new ArrayList();
        public ArrayList Red = new ArrayList();
        public ArrayList Green = new ArrayList();
        public ArrayList Yellow = new ArrayList();
        public ArrayList dBlue = new ArrayList();
        public ArrayList station = new ArrayList();
        public ArrayList Utility = new ArrayList();
        public ArrayList Players = new ArrayList();

        public NonProperties GoTile = new Go(0);
        public NonProperties justVising = new Visting(11);
        public NonProperties Jail = new GoToJail(31);
        public NonProperties FreeParking = new FreeParking(21);
     
        public NonProperties incomeTax = new IncomeTax(2);
        public NonProperties SuperTax = new SuperTax(39);
        public NonProperties potLuck;
        public NonProperties opportunities;

        private Property Brighton = new Property(6, 70, "Brighton st", 0, 0, 0, 0, 0, 0, Group.Station);
        private Property Hove = new Property(16, 70, "Hove st", 0, 0, 0, 0, 0, 0, Group.Station);
        private Property Lewes = new Property(26, 70, "Lewes st", 0, 0, 0, 0, 0, 0, Group.Station);
        private Property Falmer = new Property(36, 70, "Falmer st", 0, 0, 0, 0, 0, 0, Group.Station);
        private Property Tesla = new Property(13, 70, "Tesla Power Co", 0, 0, 0, 0, 0, 0, Group.Utility);
        private Property Edison = new Property(29, 70, "Edison Water", 0, 0, 0, 0, 0, 0, Group.Utility);

        public Cards Decks;
 


        public Board() {
            Tiles = new ArrayList();
            properties = new ArrayList();
            
            Decks = new Cards(this);
            potLuck = new Pot(8, Decks);
            opportunities = new Opportunity(8, Decks);
            Brown = new ArrayList();
            Blue = new ArrayList();
            Purple = new ArrayList();
            Orange = new ArrayList();
            Red = new ArrayList();
            Green = new ArrayList();
            Yellow = new ArrayList();
            dBlue = new ArrayList();
            station = new ArrayList();
            Utility = new ArrayList();

            Players = new ArrayList();
            populatePlayers();
            PopulateGame();
            addGroup();
            
        }

        private void populatePlayers()
        {
            Players.Add(new Human("Thomas", 1500, 0, 1, this));
            Players.Add(new Human("Tom", 1300, 0, 1, this));
            Players.Add( new Human("Jack", 1300, 0, 2, this));
            Players.Add(new Human("Mike", 1300, 0, 3, this));
        }
        public ArrayList getPlayerList() {
            return Players;
        }

        public int getNoOfPlayers() {
            return Players.Count;
        }
        public ArrayList getList(Property p) {

            switch (p.getColour())
            {
                case Group.Brown:
                    return Brown;
                case Group.Blue:
                    return Blue;
                case Group.Purple:
                    return Purple;
                case Group.Orange:
                    return Orange;
                case Group.Red:
                    return Red;
                case Group.Yellow:
                    return Yellow;
                case Group.Green:
                    return Green;
                case Group.Deep_Blue:
                    return dBlue;
                case Group.Station:
                    return station;
                case Group.Utility:
                    return Utility;
                    
                   
                default:
                    return null;
            }
        }
        private void addGroup()
        {
            
            for (int i = 0; i < Tiles.Count; i++)
            {
                if (Tiles[i] is Property)
                {
                    Property a = (Property)Tiles[i];
                    
                    switch (a.getColour())
                    {
                        case Group.Brown:
                            Brown.Add(a);
                            break;
                        case Group.Blue:
                            Blue.Add(a);
                            break;
                        case Group.Purple:
                            Purple.Add(a);
                            break;
                        case Group.Orange:
                            Orange.Add(a);
                            break;
                        case Group.Red:
                            Red.Add(a);
                            break;
                        case Group.Yellow:
                            Yellow.Add(a);
                            break;
                        case Group.Green:
                            Green.Add(a);
                            break;
                        case Group.Deep_Blue:
                            dBlue.Add(a);
                            break;
                        case Group.Station:
                            station.Add(a);
                            break;
                        case Group.Utility:
                            Utility.Add(a);
                            break;
                        default:
                            break;
                    }
                }
                else { 
                
                }
               

            }
            
        }
    
        private void PopulateGame()
        {
            String file1 = ("H:/PropertyTycoon2/Game/properties.csv");
            Group name = Group.Station;
            const char fieldSeparator = ',';
            using (System.IO.StreamReader SR = new StreamReader(file1))    // the way to go
                                                                           // while not end of file do
                                                                           // could also be (SR.Peek() != -1) or something like
                                                                           // ((currentLine = sr.ReadLine()) != null) :{

                while (!SR.EndOfStream) //best way to do it
                {


                    string[] cSValues = SR.ReadLine().Split(fieldSeparator);

                    switch (cSValues[10])
                    {
                        case "Brown":
                            name = Group.Brown;
                            break;
                        case "Blue":
                            name = Group.Blue;
                            break;
                        case "purple":
                            name = Group.Purple;
                            break;
                        case "Orange":
                            name = Group.Orange;
                            break;
                        case "Red":
                            name = Group.Red;
                            break;
                        case "Yellow":
                            name = Group.Yellow;
                            break;
                        case "Green":
                            name = Group.Green;
                            break;
                        case "Deep_Blue":
                            name = Group.Deep_Blue;
                            break;
                        case "Station":
                            name = Group.Station;
                            break;
                        case "Utility":
                            name = Group.Utility;
                            break;
                        default:
                            break;
                    }
                    properties.Add(new Property(Int32.Parse(cSValues[0]), Int32.Parse(cSValues[1]), cSValues[2], Int32.Parse(cSValues[3]), Int32.Parse(cSValues[4]), Int32.Parse(cSValues[5]), Int32.Parse(cSValues[6]), Int32.Parse(cSValues[7]), Int32.Parse(cSValues[8]), name));
                
                    Tiles = properties;
                    
                }

            Tiles.Insert(0, GoTile);
            Tiles.Insert(2, incomeTax);
            Tiles.Insert(3, potLuck);
            Tiles.Insert(6, Brighton);
            Tiles.Insert(8, opportunities);
            Tiles.Insert(11, justVising);
            Tiles.Insert(13, Tesla);
            Tiles.Insert(16, Hove);
            Tiles.Insert(18, potLuck);
            Tiles.Insert(21, FreeParking);

            Tiles.Insert(23, opportunities);

            Tiles.Insert(26, Falmer);
            Tiles.Insert(29, Edison);
            Tiles.Insert(31, Jail);
            Tiles.Insert(34, potLuck);
            Tiles.Insert(36, Lewes);
            Tiles.Insert(37, opportunities);
            
        }
        public ArrayList getProperties() {
            return properties;
        }
        public Property GetProperty(int val) {
            if (Tiles[val] is Property)
            {
                return ((Property)Tiles[val]);
            }
            else {
                return null;
            }
            
        }
    }
}
