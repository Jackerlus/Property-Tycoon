using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;

namespace Property_Tycoon
{
    public enum Group
    {
        
        Brown,
        Blue,
        Purple,
        Orange,
        Red,
        Yellow,
        Green,
        Deep_Blue,
        Utility,
        Station,

    }
    public enum BoardPiece {
        Boot, Smartphone, Goblet, Hatstand, Cat, Spoon,empty
    }
    public class Board
    {

        /// <summary>
        /// arrays for all the properties and their groups along with the player array
        /// </summary>
        private ArrayList properties;
        private ArrayList Tiles = new ArrayList(39);
        private ArrayList Brown = new ArrayList();
        private ArrayList Blue = new ArrayList();
        private ArrayList Purple = new ArrayList();
        private ArrayList Orange = new ArrayList();
        private ArrayList Red = new ArrayList();
        private ArrayList Green = new ArrayList();
        private ArrayList Yellow = new ArrayList();


        private ArrayList dBlue = new ArrayList();



        private ArrayList station = new ArrayList();
        private ArrayList Utility = new ArrayList();
        private ArrayList Players = new ArrayList();
        private ArrayList pieces = new ArrayList();
        


        /// <summary>
        /// intitalises all the Non obtainable properties
        /// </summary>
        public NonProperties GoTile = new Go(0);



        public NonProperties justVising = new Visting(11);
        public NonProperties Jail = new GoToJail(31);
        public NonProperties FreeParking = new FreeParking(21);

        public NonProperties incomeTax = new IncomeTax(2);
        public NonProperties SuperTax = new SuperTax(39);
        public NonProperties potLuck;
        public NonProperties opportunities;

        /// <summary>
        /// initalises all the different Special properties
        /// </summary>
        private Property Brighton = new Property(6, 70, "Brighton station", 25, 50, 100, 200, 0, 0, Group.Station);
        private Property Hove = new Property(16, 70, "Hove station", 25, 50, 100, 200, 0, 0, Group.Station);
        private Property Lewes = new Property(26, 70, "Lewes station", 25, 50, 100, 200, 0, 0, Group.Station);
        private Property Falmer = new Property(36, 70, "Falmer station", 25, 50, 100, 200, 0, 0, Group.Station);
        private Property Tesla = new Property(13, 70, "Tesla Power Co", 0, 0, 0, 0, 0, 0, Group.Utility);
        private Property Edison = new Property(29, 70, "Edison Water", 0, 0, 0, 0, 0, 0, Group.Utility);
        private int mode;
        int time;
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
            //mode = GameMode;

            Players = new ArrayList();
            populatePieces();
            
            //populatePlayers();
            PopulateGame();
            addGroup();

        }
        public ArrayList getGameBoard() {

            return Tiles;
        }
        public void addplayer(Player p) {
            Players.Add(p);
        
        }
        /// <summary>
        /// this method removes a player 
        /// </summary>
        /// <param name="p"></param>
        public void removePlayer(Player p) {
            if (Players.Count != 1)
            {
                Players.Remove(p);
                Players.TrimToSize();
            }
            else {
                MessageBox.Show(p.getName() +"Wins!!");
                    }
            }
        /// <summary>
        /// this method gets the game type
        /// </summary>
        /// <returns></returns>
        public int getGameType()
        {
            return mode;
        }
        /// <summary>
        /// This method sets the game type 
        /// </summary>
        /// <param name="val"></param>
        public void SetGameType(int val)
        {
             mode = val;
        }/// <summary>
        /// This method gets the current time
        /// </summary>
        /// <returns></returns>
        public int getTime()
        {
            return time;
        }
        /// <summary>
        /// this method sets the time
        /// </summary>
        /// <param name="val"></param>
        public  void setTime(int val) {
            time = val;
        }

        /// <summary>
        /// this method sets the new pieces
        /// </summary>
        private void populatePieces()
        {
                pieces.Add(new Piece("Boot", "/Images/boot.png"));
                pieces.Add(new Piece("Smartphone", "/Images/phone.png"));
                pieces.Add(new Piece("Goblet", "/Images/chalice.png"));
                pieces.Add(new Piece("Hatstand", "/Images/hatstand.png"));
                pieces.Add(new Piece("Cat", "/Images/cat.png"));
                pieces.Add(new Piece("Spoon", "/Images/spoon.png"));
            
        }
        /// <summary>
        /// This method generates the Board pieces
        /// </summary>
        /// <returns></returns>
        public ArrayList getBoardPieces() {
            ArrayList A = new ArrayList();
            foreach (Piece item in pieces)
            {
                if (item.getPicked() == false)
                {
                    A.Add(item);
                }
            }
            return A;
        }
        /// <summary>
        /// this method gets a current game piece
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public Piece getPiece(int val) {
            return (Piece)pieces[val];
        }




        /// <summary>
        /// this method gets the Tiles array
        /// </summary>
        /// <returns></returns>
        public ArrayList returnProperties()
        {
            return Tiles;
        }
        /// <summary>
        /// this mehtod adds the new players to the game (Player array)
        /// </summary>
        private void populatePlayers()
        {
            try { 
            setPlayers p = new setPlayers(this);
            
            
                p.ShowDialog();
                //checkPlayers();
            }
            catch (System.ArgumentOutOfRangeException)
            {
                MessageBox.Show("Please Enter players into the game");
                
            }
            


        }
        /// <summary>
        /// this method checks the minimum number of players
        /// </summary>
        private void checkPlayers()
        {
            if (getNoOfPlayers() < 2)
            {
                throw new NotEnoughPlayersException();
            }
        }
        /// <summary>
        /// this method adds a player to the array
        /// </summary>
        /// <param name="p"></param>
        public void addToArray(Player p) {
            Players.Add(p);
        }
        /// <summary>
        /// this method returns a list of all the current players
        /// </summary>
        /// <returns></returns>
        public ArrayList getPlayerList() {
            return Players;
        }
        /// <summary>
        /// This method gets the count of all the players currently in the game
        /// </summary>
        /// <returns></returns>
        public int getNoOfPlayers() {
            return Players.Count;
        }
        /// <summary>
        /// This method gets the grouping array of the property P
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
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
        /// <summary>
        /// this method goes though the tiles array and assigns each property to its colour array
        /// </summary>
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
        /// <summary>
        /// this method gets the players names
        /// </summary>
        /// <returns></returns>
        public ArrayList getPlayerNames()
        {
            ArrayList names = new ArrayList();
            String s;
            foreach (Player item in getPlayerList())
            {
                if (item is Human)
                {
                    s = item.getName();
                    names.Add(s);
                }

            }
            return names;
        }
        /// <summary>
        /// this method gets the piece names
        /// </summary>
        /// <returns></returns>
        public ArrayList getPieceNames()
        {
            ArrayList names = new ArrayList();
            String s;
            foreach (Piece item in getBoardPieces())
            {
                if (item is Piece)
                {
                    s = item.getName();
                    names.Add(s);
                }

            }
            return names;
        }

        /// <summary>
        /// This method reads in the properties from the CSV and constructs each property from this data
        /// </summary>
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
                        case "Purple":
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
                        case "Deep blue":
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
            Tiles.Insert(2, potLuck);

            Tiles.Insert(4, incomeTax);
            
            Tiles.Insert(5, Brighton);
            Tiles.Insert(7, opportunities);
            Tiles.Insert(10, justVising);
            Tiles.Insert(12, Tesla);
            Tiles.Insert(15, Hove);
            Tiles.Insert(17, potLuck);
            Tiles.Insert(20, FreeParking);

            Tiles.Insert(22, opportunities);

            Tiles.Insert(25, Falmer);
            Tiles.Insert(28, Edison);
            Tiles.Insert(30, Jail);
            Tiles.Insert(33, potLuck);
            Tiles.Insert(35, Lewes);
            Tiles.Insert(36, opportunities);
            Tiles.Insert(38, SuperTax);
            
        }
        /// <summary>
        /// this method returns the properties
        /// </summary>
        /// <returns></returns>
        public ArrayList getProperties() {
            return properties;
        }
        /// <summary>
        /// this method gets the property at the specific index
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public Property GetProperty(int val) {
            if (Tiles[val] is Property)
            {
                return ((Property)Tiles[val]);
            }
            else {
                return null;
            }
            
        }
        /// <summary>
        /// this method gets the name of the tile 
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public String getspaceName(int val) {
            if (Tiles[val] is Property)
            {
                Property p = (Property)Tiles[val];
                return p.getName();
            }
            if (Tiles[val] is Go)
            {
                Go g = (Go)Tiles[val];
                return g.getName();
            }
            if (Tiles[val] is Visting)
            {
                Visting j = (Visting)Tiles[val];
                return j.getName() ;
            }
            if (Tiles[val] is GoToJail)
            {
                GoToJail j = (GoToJail)Tiles[val];
                return j.getName();
            }
            if (Tiles[val] is IncomeTax  )
            {
                IncomeTax i = (IncomeTax)Tiles[val];
                return i.getName();
            }
            if (Tiles[val] is SuperTax)
            {
                SuperTax s = (SuperTax)Tiles[val];
                return s.getName();
            }
            if (Tiles[val] is Pot)
            {
                return "Pot Luck";

            }
            if (Tiles[val] is Opportunity)
            {
                return "Opportunity Knocks";
            }
            if (Tiles[val] is FreeParking)
            {
                return "Free Parking";
            }
            else {
                return "NotFound ";
            }
        }
        /// <summary>
        /// this method abridges the game
        /// </summary>
        public void abridgeGame()
        {
            string S ="";
            foreach (Human item in Players)
            {
                S= S + "\n Player: " + item.getName() + "finished with £" + calcAssets(item) + " worth of assets";
            }
            MessageBox.Show(S);
        }
        /// <summary>
        /// this method calculates the assets of each player
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private int calcAssets(Human p)
        {
            int houseCounter = 0;
            foreach (Property item in p.getProperties())
            {
                switch (item.getColour())
                {
                    case Group.Brown:
                        houseCounter = houseCounter + (item.checkHouses() * 50);
                        break;
                    case Group.Blue:
                        houseCounter = houseCounter + (item.checkHouses() * 50);
                        break;
                    case Group.Purple:
                        houseCounter = houseCounter + (item.checkHouses() * 100);
                        break;
                    case Group.Orange:
                        houseCounter = houseCounter + (item.checkHouses() * 100);
                        break;
                    case Group.Red:
                        houseCounter = houseCounter + (item.checkHouses() * 150);
                        break;
                    case Group.Yellow:
                        houseCounter = houseCounter + (item.checkHouses() * 150);
                        break;
                    case Group.Green:
                        houseCounter = houseCounter + (item.checkHouses() * 200);
                        break;
                    case Group.Deep_Blue:
                        houseCounter = houseCounter + (item.checkHouses() * 200);
                        break;
                    default:
                        break;
                }

            }

            int HoteCounter = 0;
            foreach (Property item in p.getProperties())
            {
                switch (item.getColour())
                {
                    case Group.Brown:
                        if (item.hotelCheck() == true)
                        {
                            HoteCounter = HoteCounter + 5 *50;
                        }
                        
                        break;
                    case Group.Blue:
                        if (item.hotelCheck() == true)
                        {
                            HoteCounter = HoteCounter + 5 * 50;
                        }
                        break;
                    case Group.Purple:
                        if (item.hotelCheck() == true)
                        {
                            HoteCounter = HoteCounter + 5 * 100;
                        }
                        break;
                    case Group.Orange:
                        if (item.hotelCheck() == true)
                        {
                            HoteCounter = HoteCounter + 5 * 100;
                        }
                        break;
                    case Group.Red:
                        if (item.hotelCheck() == true)
                        {
                            HoteCounter = HoteCounter + 5 * 150;
                        }
                        break;
                    case Group.Yellow:
                        if (item.hotelCheck() == true)
                        {
                            HoteCounter = HoteCounter + 5 * 150;
                        }
                        break;
                    case Group.Green:
                        if (item.hotelCheck() == true)
                        {
                            HoteCounter = HoteCounter + 5 * 200;
                        }
                        break;
                    case Group.Deep_Blue:
                        if (item.hotelCheck() == true)
                        {
                            HoteCounter = HoteCounter + 5 * 200;
                        }
                        break;
                    default:
                        break;
                }

            }
            int propcost = 0;
            foreach (Property item in p.getProperties())
            {
                if (item.getMortgaged() == false)
                {
                    propcost = propcost + item.getCost();
                }
                else{
                    propcost = propcost + (item.getCost() / 2);
                }
                
            }


            return HoteCounter + houseCounter + p.getMoney() + propcost;
        }
    }
}
