using Microsoft.VisualStudio.TestTools.UnitTesting;
using Property_Tycoon;
using System.Windows;

namespace PropertyTycoonTests

{
    [TestClass]
    public class DiceUnitTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            Roll r = new Roll();
            r.Rolls();
            Assert.IsTrue(r.rollValue() > 1 && r.rollValue() < 13);

        }

        [TestMethod]
        public void getGetDieValue()
        {
            Roll r = new Roll();
            r.Rolls(1);
            Assert.IsNotNull(r.getDie1() == 2);

        }

        [TestMethod]
        public void DiceRollSumTest()
        {
            Roll r = new Roll();
            r.Rolls();

            Assert.AreEqual(r.getDie1() + r.getDie2(), r.rollValue());

        }
        [TestMethod]
        public void DiceDoubleCheck()
        {
            Roll r = new Roll();
            r.Rolls(1);
            Assert.IsTrue(r.isEqual(r.getDie1(), r.getDie2()));

        }
        [TestMethod]
        public void noDoubleCheck()
        {
            Roll r = new Roll();
            r.Rolls();
            Assert.AreNotEqual(r.getDie1(), r.getDie2());

        }
    }

    [TestClass]
    public class BoardUnitTests
    {
        Board currentGame;
        [TestMethod]
        public void PropertyCount()
        {
            currentGame = new Board();
            Assert.IsTrue(currentGame.getGameBoard().Count == 40);
        }
        [TestMethod]
        public void postionCheck()
        {
            currentGame = new Board();
            Assert.IsTrue(currentGame.GetProperty(39).getName() == "Turing heights");
        }

    }


        [TestClass]
    public class PieceUnitTests
    {
        [TestMethod]
        public void PieceInstaceTest()
        {
            Assert.IsNotNull( new Piece("CAT","test/path"));
        }
        [TestMethod]
        public void PieceInstaceTest2()
        {
            Piece p = new Piece("CAT", "test/path");
            Assert.IsTrue(p.getfilePath() == "test/path");
        }
        [TestMethod]
        public void PieceInstaceTest3()
        {
            Piece p = new Piece("CAT", "test/path");
            Assert.IsTrue(p.getName() == "CAT");
        }
    }
    [TestClass]
    public class NoNPropertyUnitTests
    {
      
        public NonProperties justVising = new Visting(11);
        public NonProperties Jail = new GoToJail(31);
        public NonProperties FreeParking = new FreeParking(21);

        public NonProperties incomeTax = new IncomeTax(2);
        public NonProperties SuperTax = new SuperTax(39);
        public NonProperties potLuck;
        Board b = new Board();
        public NonProperties opportunities;
        Player player = new Human("TESTPLAYER", 1000, new Piece("Cat", "/Filepath"), new Board());
        [TestMethod]
        public void InstanceOfClassTypes()
        {
            Assert.IsNotNull(b.justVising);
            Assert.IsNotNull(b.Jail);
            Assert.IsNotNull(b.FreeParking);
            Assert.IsNotNull(b.incomeTax);
            Assert.IsNotNull(b.SuperTax);
       
        }
        [TestMethod]
        public void PotLuckActiontest()
        {

            b.potLuck.action(player);
            Assert.IsTrue(player.getMoney() == 1010);

        }

        [TestMethod]
        public void JailActionTest()
        {
            b.Jail.action(player);
            Assert.IsTrue(player.isInJail());

        }
        [TestMethod]
        public void FreeParkingActionTest()
        {
            player.move(3);
            b.justVising.action(player);
            
            Assert.IsTrue(player.getMoney() == 1000);

        }
        [TestMethod]
        public void SuperTaxActionTest()
        {

            b.SuperTax.action(player);
            

            Assert.IsTrue(player.getMoney() == 900);

        }
        [TestMethod]
        public void IncomeTaxActionTest()
        {

            b.incomeTax.action(player);


            Assert.IsTrue(player.getMoney() == 800);
        }


    }

        [TestClass]
    public class PropertyUnitTests
    {
        [TestMethod]
        public void InstanceOfSpace()
        {
            Property p = new Property(1,100,"Test",10,20,30,40,50,60,Group.Blue);
            Assert.IsNotNull(p);

        }
        [TestMethod]
        public void PropertyPostitionTest()
        {
            Property p = new Property(1, 100, "Test", 10, 20, 30, 40, 50, 60, Group.Blue);
            Assert.IsNotNull(p);

        }
        [TestMethod]
        public void PropertyCostTest()
        {
            Property p = new Property(1, 100, "Test", 10, 20, 30, 40, 50, 60, Group.Blue);
            Assert.IsTrue(p.getPosition() == 1);

        }
        [TestMethod]
        public void PropertyNametest()
        {
            Property p = new Property(1, 100, "Test", 10, 20, 30, 40, 50, 60, Group.Blue);
            Assert.AreEqual(p.getName(),"Test");

        }
        [TestMethod]
        public void PropertyRentTest()
        {
            Property p = new Property(1, 100, "Test", 10, 20, 30, 40, 50, 60, Group.Blue);
            Assert.IsTrue(p.getRent() == 10);

        }
        [TestMethod]
        public void BuyPropertyTest()
        {
            
            Property p = new Property(1, 100, "Test", 10, 20, 30, 40, 50, 60, Group.Blue);
            Player player = new Human("TESTPLAYER", 100, new Piece("Cat", "/Filepath"), new Board());
            player.buyProperty(p);

        }
        [TestMethod]
        public void PropertyAddHouse()
        {
            
           
            Property p = new Property(1, 100, "Test", 10, 20, 30, 40, 50, 60, Group.Blue);
            Property q = new Property(2, 100, "TestB", 10, 20, 30, 40, 50, 60, Group.Blue);
            Board CG = new Board(); 
            Player player = new Human("TESTPLAYER",100,CG.getPiece(0), CG);
            CG.addplayer(player);
            player.buyProperty(p);
            player.buyProperty(q);
            p.addHouse();

        }
        [TestMethod]
        public void PropertyAddHotel()
        {
            Player player = new Human("TESTPLAYER", 100, new Piece("Cat", "/Filepath"), new Board());
            Property p = new Property(1, 100, "Test", 10, 20, 30, 40, 50, 60, Group.Blue);
            p.checkHouses();
            p.checkHouses();
            p.checkHouses();
            p.checkHouses();
            p.convertHouseToHotel();
            Assert.IsTrue(p.hotelCheck());

        }
        [TestMethod]
        public void PropertyStationIntialisation()
        {
            Property p = new Property(1, 100, "Test", 10, 20, 30, 40, 50, 60, Group.Station);
            Assert.IsNotNull(p);

        }
        [TestMethod]
        public void PropertyUtilityUtisation()
        {
            Property p = new Property(1, 100, "Test", 10, 20, 30, 40, 50, 60, Group.Utility);
            Assert.IsNotNull(p);

        }
        [TestMethod]
        public void mortgagePropertyTest()
        {
            Player player = new Human("TESTPLAYER", 100, new Piece("Cat", "/Filepath"), new Board());
            Property p = new Property(1, 100, "Test", 10, 20, 30, 40, 50, 60, Group.Utility);
            

        }

        [TestMethod]
        public void UnmortgagePropertyTest()
        {
            Player player = new Human("TESTPLAYER", 100, new Piece("Cat", "/Filepath"), new Board());
            Property p = new Property(1, 100, "Test", 10, 20, 30, 40, 50, 60, Group.Utility);


        }

        [TestMethod]
        public void SellHouse()
        {
            Player player = new Human("TESTPLAYER", 100, new Piece("Cat", "/Filepath"), new Board());
            Property p = new Property(1, 100, "Test", 10, 20, 30, 40, 50, 60, Group.Utility);
            p.addHouse();
            p.sellHouse();
            Assert.IsTrue(p.checkHouses() == 0);

        }
        [TestMethod]
        public void SellHotel()
        {
            Player player = new Human("TESTPLAYER", 100, new Piece("Cat", "/Filepath"), new Board());
            Property p = new Property(1, 100, "Test", 10, 20, 30, 40, 50, 60, Group.Utility);
            p.addHouse();
            p.addHouse();
            p.addHouse();
            p.addHouse();
            p.convertHouseToHotel();
            p.sellHotel();
            Assert.IsTrue(p.checkHouses() == 4);

        }

    }

    [TestClass]
    public class  PlayerUnitTests
    {
        [TestMethod]
        public void Initalise()
        {
            Player player = new Human("TESTPLAYER", 100, new Piece("Cat", "/Filepath"), new Board());
            Assert.IsNotNull(player);

        }
        [TestMethod]
        public void SetPositionTest() 
        {
            Player player = new Human("TESTPLAYER", 100, new Piece("Cat", "/Filepath"), new Board());
            player.move(2);
            Assert.IsTrue(player.getPosition() == 2);
        }
        [TestMethod]
        public void BuyPropertyTest()
        {


        }
        [TestMethod]
        public void GetNameTest()
        {
            Player player = new Human("TESTPLAYER", 100, new Piece("Cat", "/Filepath"), new Board());
            
            Assert.IsTrue(player.getName().Equals( "TESTPLAYER"));

        }
        [TestMethod]
        public void getCashTest()
        {
            Player player = new Human("TESTPLAYER", 100, new Piece("Cat", "/Filepath"), new Board());
          
            Assert.IsTrue(player.getMoney() == 100);

        }

        [TestMethod]
        public void PlayerAddMoneyTest()
        {
            Player player = new Human("TESTPLAYER", 100, new Piece("Cat", "/Filepath"), new Board());
            player.addmoney(1900);
            Assert.IsTrue(player.getMoney() == 2000);

        }

        [TestMethod]
        public void GetTypeTest()
        {
            Player player = new Human("TESTPLAYER", 100, new Piece("Cat", "/Filepath"), new Board());
            Assert.IsTrue(player.GetType() is Human);

        }
        [TestMethod]
        public void getPropertiesTest()
        {
            Board cg = new Board();
            Player player = new Human("TESTPLAYER", 100, new Piece("Cat", "/Filepath"), new Board());
            player.buyProperty(cg.GetProperty(0));
            Assert.IsTrue(player.getProperties().Count == 1);
        }
        [TestMethod]
        public void GoToJailTest()
        {
            Board cg = new Board();
            Player player = new Human("TESTPLAYER", 100, new Piece("Cat", "/Filepath"), new Board());
            player.move(30);
            Assert.IsTrue(player.isInJail() == true);
        }
        [TestMethod]
        public void GoToMoveJailTest()
        {


        }
        [TestMethod]
        public void GoToJail()
        {


        }
        [TestMethod]
        public void AddGetOutofJailFreeTest()
        {
            Board cg = new Board();
            Player player = new Human("TESTPLAYER", 100, new Piece("Cat", "/Filepath"), new Board());
            player.addGetOutOfJail();
            Assert.IsTrue(player.getJailFreeNo() == 1);

        }
        [TestMethod]
        public void CheckGroupingTrue()
        {
            Board cg = new Board();
            Player player = new Human("TESTPLAYER", 100, new Piece("Cat", "/Filepath"), new Board());
            player.moveto(39);
            player.rolldice();
            player.buyProperty(cg.GetProperty(1));
            player.buyProperty(cg.GetProperty(3));

            Assert.IsTrue(player.Checkgrouping(cg.GetProperty(1)));
        }
        [TestMethod]
        public void CheckGroupingFalse()
        {
            Board cg = new Board();
            Player player = new Human("TESTPLAYER", 100, new Piece("Cat", "/Filepath"), new Board());
            player.moveto(39);
            player.rolldice();
            player.buyProperty(cg.GetProperty(1));

            Assert.IsFalse(player.Checkgrouping(cg.GetProperty(1)));

        }


    }
}
    
