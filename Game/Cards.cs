using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Property_Tycoon
{
    public class Cards
    {
		
		CardType type;
		String text;
		Window1 pickOrDraw;
		ArrayList opportunityKnocks = new ArrayList();
        ArrayList potLuck = new ArrayList();
		Board Game;
		Random rand = new Random();
		
		public enum CardType { POT,OPP }
		public Cards(Board currentGame)
		{
			Game = currentGame;
			text = "";

			for (int i = 0; i < 16; i++)
			{
				potLuck.Add(i);
				opportunityKnocks.Add(i);

			}
			
		}
			

		public void drawPotLuck(Player p)
		{

				int cardTaken = (int)potLuck[rand.Next(0, potLuck.Capacity)];
				potLuck.TrimToSize();
				pot(cardTaken, p);
		}
		public void drawOppKnocks(Player p)
		{

			int cardTaken = (int)potLuck[rand.Next(0, potLuck.Capacity)];
			opportunityKnocks.TrimToSize();
			oppKnocks(cardTaken, p);
		}


		private void pot(int a,Player p)
		{
			type = CardType.POT;
			switch (a)
			{
				case 0:
					inherit(p);
					break;
				case 1:
					beauty(p);
					break;
				case 3:
					moveToCrapper(p);
					break;
				case 4:
					stdLoanRefund(p);
					break;
				case 5:
					bankError(p);
					break;
				case 6:
					payBillTextBook(p);
					break;
				case 7:
					advanceToGo(p);
					break;
				case 8:
					fineOrDrawOpp(p);
					break;
				case 9:
					payInsurance(p);
					break;
				case 10:
					collectSavingBond(p);
					break;
				case 11:
					goToJail(p);
					break;
				case 12:
					recievedInterest(p);
					break;
				case 13:
					birthday(p);
					break;
				case 14:
					getOutofJailFree(p);
					break;
				case 16:
					bitcoin(p);
					break;

				default:
					break;
			}
		}
		private void bitcoin(Player p)
		{
			
			text = "From sale of bitcoin"
			+ "you get "
			+ "£50";
			
			p.addmoney(50);
			MessageBox.Show(text);
		}

		private void getOutofJailFree(Player p)
		{
			p.addGetOutOfJail();
			text = "you have been given a\n"
			+ "get out of jail free card \n"
			+ "this has no resale or trade value";
			MessageBox.Show(text);
			
		}

		private void birthday(Player p )
		{
			
			text = "It's Your birthday"
			+ "from each player "
			+ "Collect £10";
			for (int i = 0; i < Game.getNoOfPlayers(); i++)
			{
				p.addmoney(10);
			}
			
			MessageBox.Show(text);

		}

		private void goToJail(Player p)
		{
			
			text = "Go to Jail. \n"
			+ "Do not pass Go. \n"
			+ "Do not collect £200.";
			MessageBox.Show(text);
			p.goToJail();
			
		}

		private void recievedInterest(Player p)
		{
			
			text = "Recived intrest on"
			 + "shares.\n "
			 +"Collect £25";
			p.addmoney(25);
			MessageBox.Show(text);
		}

		private void collectSavingBond(Player P)
		{
			P.addmoney(100);
			
			text= "Savings bond matures. \n"
			+ "collect £100 ";

			MessageBox.Show(text);
		}

		private void payInsurance(Player p)
		{
			p.addmoney(-50);
			
			text = "Pay insurance fee of "+
			"£50 ";
			MessageBox.Show(text);
		}

		private void fineOrDrawOpp(Player p)
		{
			text = "Pay a $10 fine "
			+ "or "
			+ "take opportunity knocks";
			pickOrDraw = new Window1();
			pickOrDraw.data(text);
			pickOrDraw.Show();

			int choice = pickOrDraw.getChoice();

			switch (choice) {
				case 0:
					// this pays the fine.
					p.addmoney(-10);
					break;
				case 1:
					// this draws a card.
					drawOppKnocks(p);
					break;
				default:
					break;
			}

		}

		private void advanceToGo(Player p)
		{

			text= "Advance to go.";

			p.moveto(0);
			MessageBox.Show(text);
		}

		private void payBillTextBook(Player p)
		{

			text = "pay bill for textbooks "
			+ "£100";
			p.addmoney( -100);
			MessageBox.Show(text);
		}

		private void bankError(Player p)
		{

			text = "bank error in "
			+ "your favour. \n "
			+"Collect £200";
			p.addmoney( 200);
			MessageBox.Show(text);
		}

		private void stdLoanRefund(Player p)
		{

			text = "Student Loan refund. \n"
			
			+ "Collect £20";
			p.addmoney(20);
			MessageBox.Show(text);
		}

		private void inherit(Player p)
		{

			text = "You have inherited £50! \n ";
			
			p.addmoney(10);
			MessageBox.Show(text);
		}
		private void moveToCrapper(Player p)
		{
			
			
			
			text = "Go Back to crapper Street";

			MessageBox.Show(text);
			p.moveto(2);
		}
		private void beauty(Player p)
		{
			p.addmoney(10);
			text = "You have won second prize in a \n"
			+"beauty contest!\n"
			+"Collect £10";

			MessageBox.Show(text);
		}
	

	private void oppKnocks(int a, Player p)
	{
		type = Cards.CardType.OPP;
		switch (a)
		{
			case 0:
				divided(p);
				break;
			case 1:
				lipSync(p);
				break;
			case 3:
				moveToTuringHeights(p);
				break;
			case 4:
				moveToHanXinGardens(p);
				break;
			case 5:
				fine(p);
				break;
			case 6:
				uniFees(p);
				break;
			case 7:
				tripToHove(p);
				break;
			case 8:
				loanMatures(p);
				break;
			case 9:
				repairs(p);
				break;
			case 10:
				advanceToGo(p);
				break;
			case 11:
				repairsLess(p);
				break;
			case 12:
				goBack(p);
				break;
			case 13:
				advanceToSkywalker(p);
				break;
			case 14:
				goToJail(p);
				break;
			case 16:
				drunkInCharge(p);
				break;

			default:
				break;
		}
	}

		private void drunkInCharge(Player p)
		{
			p.addmoney(-20);

			text = "Drunk in charge of a skateboard. Fine £20";

			MessageBox.Show(text);
		}

		private void advanceToSkywalker(Player p)
		{
			

			text = "Advance to Skywalker Drive. If you pass GO collect £200";

			MessageBox.Show(text);
			p.moveto(12);
		}

		private void goBack(Player p)
		{
			

			text = "Go back 3 spaces";

			MessageBox.Show(text);
			p.move(-3);
		}

		private void repairsLess(Player p)
		{
			int houseCounter = 0;
			int hotelCounter = 0;
			foreach (Property item in p.getProperties())
			{
				houseCounter = houseCounter + item.checkHouses();
				if (item.hotelCheck())
				{
					hotelCounter = hotelCounter + 1;
				}
	
			}
			p.addmoney(-((houseCounter * 25 )+ (hotelCounter * 100)));
			text = "You are assessed for repairs, £25/house, £100/hotel";

			MessageBox.Show(text);
		}

		private void repairs(Player p)
		{
			int houseCounter = 0;
			int hotelCounter = 0;
			foreach (Property item in p.getProperties())
			{
				houseCounter = houseCounter + item.checkHouses();
				if (item.hotelCheck())
				{
					hotelCounter = hotelCounter + 1;
				}

			}
			

			text = "You are assessed for repairs, £40/house, £115/hotel";

			MessageBox.Show(text);
			p.addmoney(-((houseCounter * 40) + (hotelCounter * 115)));
		}

		private void loanMatures(Player p)
		{
			p.addmoney(150);

			text = "Loan matures, collect £150";

			MessageBox.Show(text);
		}

		private void tripToHove(Player p)
		{
			p.moveto(16);

			text = "Take a trip to Hove station. If you pass GO collect £200";

			MessageBox.Show(text);
		}

		private void uniFees(Player p)
		{
			p.addmoney(-150);

			text = "Pay university fees of £150";

			MessageBox.Show(text);
		}

		private void fine(Player p)
		{
			p.addmoney(-15);

			text = "Fined £15 for speeding";

			MessageBox.Show(text); 
		}

		private void moveToHanXinGardens(Player p)
		{
			p.moveto(25);

			text = "Advance to Turing Heights";

			MessageBox.Show(text);
		}

		private void moveToTuringHeights(Player p)
		{
			p.moveto(39);

			text = "Advance to Turing Heights";

			MessageBox.Show(text);
		}

		private void lipSync(Player p)
		{
			p.addmoney(100);

			text = "You have won a lip sync battle. Collect £100";

			MessageBox.Show(text);
		}

		private void divided(Player p)
		{
			p.addmoney(50);

			text = "Bank pays you a divided of £50";

			MessageBox.Show(text);
		}
	}
}
