/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
import static java.lang.Boolean.TRUE;
import java.util.ArrayList;
/**
 *
 * @author Bayley
 */
public class Player {
    private int playerID;
    private int pos;
    private int numbOfLaps;

    public int getNumbOfLaps() {
        return numbOfLaps;
    }

    private int bal;
    private ArrayList<Property> owned;

    public Player(int playerID) {
        this.playerID = playerID;
        this.bal = 2000;
        this.owned = new ArrayList<Property>();
        this.pos = -1;
        this.numbOfLaps = 0;
    }
    //Returns players ID number.
    public int getPlayerID() {
        return playerID;
    }
    //Returns player's bal.
    public int getBal() {
        return bal;
    }
    
    public void buyProp(Property p) {
        if (bal < p.getValue()) {
            System.out.println("Player does not have enough money!\n");
        }
        else if(p.getOwned() && owned.contains(p)){
            System.out.println("This player already owns the property!\n" );
        }
        else if(p.getOwned()) {
            System.out.println("A player already owns the property!\n" );
        }
        else if(numbOfLaps == 0) {
            System.out.println("Player must complete 1 full rotation of the board before buying!\n" );
        }
        else {
            p.setOwned(Boolean.TRUE);
            Property newP = new Property(p.getName(), p.getColour(), p.getValue());
            owned.add(newP);
            bal -= p.getValue();
            System.out.println("Property: " + p.getName() + " has been purchased!\n" );
        }  
    }
    
    public void sellProp(Property p) {
        if (owned.contains(p)) {
            owned.remove(p);
            bal += p.getValue();
            p.setOwned(Boolean.FALSE);
        }
        else {
            System.out.println("Player doesnt own Property!");
        } 
    }
    
    //Postive values increase balance, negative values decrease balance.
    public void updateBal(int value) {
        bal = bal + value;
    }

    public ArrayList<Property> getOwned() {
        return owned;
    }
    //Gets the number of a properties already owned by player for a certain colour
    public int getColAmount(Enum c) {
        int x = 0;
        for (Property prop : owned) {
            if (prop.getColour() == c) {
                x++;
            }  
        }
        return x;
    }
    //Gets the number of a properties already owned by a given player for a certain colour
    public int getOppColAmount(Player play, PropertyColourType c) {
        int x = 0;
        for (Property prop : play.getOwned()) {
            if (prop.getColour() == c) {
                x++;
            }  
        }
        return x;
    }

    public int getPos() {
        return pos;
    }

    public void upDatePos(int roll) {
        if ((pos + roll) < 28) {
            pos += roll; 
        }
        else {
            pos = ((pos+roll)%28);
            numbOfLaps++;
        }
    }
    

}
