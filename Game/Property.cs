using System;

enum Group
{
	Red,
	Brown,
	Blue,
	Purple,
	Orange,
	Yellow,
	Green,
	Deepblue,
	Utility,
}
public class Property
{
	private int price;
	private String Name;
	private int RentBase;
	private int rent1;
	private int rent2;
	private int rent3;
	private int rent4;
	private int rentH;
	private Group propertyType;
	

	public Property(int position, int price , int name, int rent, int rent1, int rent2, int rent3, int rent4, int rentH, Group colour) : base(position , name)
	{
		this.rent1 = rent1;
		this.rent2 = rent2;
		this.rent3 = rent3;
		this.rent4 = rent4;
		this.rentH = rentH;
		this.price = price;
		this.rent = rent;
		this.Name = name;
		this.propertyType = colour;
		

	}
	public Property(int position, int price , int name,Group colour) : base (position, name){
		price = price;
		this.rent = rent;
		this.Name = name;
		this.price = price;
		this.propertyType = colour;
	}

	public String getName() {
		return Name;
	}
	public int getCost() {
		return price;
	}
	public int getRent() {
		return rent;

	}
	public bool isBankOwned()
	{
		return bankowned;
	}
	public void setBankOwned(bool a) {
		BankOwned = a;
	}
	public Group getColour() {
		return colour;
	}

	public void mortgageProperty()
    {
		if (isBankOwned())
		{
			rent = 0;
			houseNo = 0;
			hasHotel = false;
		}
		else {
			setBankOwned(false);
			rent = RentBase;
		}
    }
	public int checkHouses() {
		return houseNo;
	}
	public String addHouse() {
		String s = "";

		if (this.checkHouses() < 4 && hasHotel == false && !Group.Utility)
		{
			houseNo = houseNo + 1;
			s = "The number of houses is : " + houseNo;
			switch (houseNo)
			{
				case 1:
					rent = rent1;
					break;

				case 2:
					rent = rent2;
				case 3:
					rent = rent3;
				case 4:
					rent = rent4;
				case 5:
					rent = rentH;
				default:
					break;
			}
		}
		else if (hasHotel == true)
		{
			s = "there is already a hotel here;";

		}
		else {
			s = "there are already 4 Houses please buy a hotel";
		}
		reutun s;
	}
	public String convertHouseToHotel() {
		string s = "";
		if (hasHotel == true)
		{
			s = "this property already has a hotel";
		}
		else if (houseNo < 4) { s = "there are not enough houses to mak a hotel"; }
		else {
			houseNo = 0;
			hasHotel = true;
			s = "this property now has a hotel";
			rent - rentH;
		}
		return s;
	}

}
