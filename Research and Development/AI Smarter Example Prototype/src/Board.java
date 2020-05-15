/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
import java.util.ArrayList;
import java.util.Random;
import static java.lang.Boolean.TRUE;
/**
 *
 * @author Bayley
 */
public class Board {
    private ArrayList<Property> boardTiles;
    private ArrayList<Player> playerList;

    public ArrayList<Property> getBoardTiles() {
        return boardTiles;
    }
    

    public Board() {
        this.boardTiles = new ArrayList<Property>();
        this.playerList = new ArrayList<Player>();
    }

    public static void main(String[] args) {
        Board b = new Board();
        b.populate(b.getBoardTiles());
        Player p1 = new Player(1);
        Player p2 = new Player(2);
        b.addTwoPlayers(p1, p2);
        b.simFirstxMoves(10, p1, p2);
        System.out.println("Simulation Complete! \n");
        b.playerTurn(p1);
        b.playerTurn(p2);
    }

    public ArrayList<Player> getPlayerList() {
        return playerList;
    }
    public void populate(ArrayList<Property> bT) {
        //Populates Board full of only buyable properties
        Property p1 = new Property("Pos1", PropertyColourType.BROWN , 80);
        Property p2 = new Property("Pos2", PropertyColourType.BROWN , 100);
        Property p3 = new Property("Pos3", PropertyColourType.STATION , 200);
        Property p4 = new Property("Pos4", PropertyColourType.BLUE , 120);
        Property p5 = new Property("Pos5", PropertyColourType.BLUE , 120);
        Property p6 = new Property("Pos6", PropertyColourType.BLUE , 150);
        Property p7 = new Property("Pos7", PropertyColourType.PURPLE , 180);
        Property p8 = new Property("Pos8", PropertyColourType.UTIL , 125);
        Property p9 = new Property("Pos9", PropertyColourType.PURPLE , 180);
        Property p10 = new Property("Pos10", PropertyColourType.PURPLE , 210);
        Property p11 = new Property("Pos11", PropertyColourType.STATION , 200);
        Property p12 = new Property("Pos12", PropertyColourType.ORANGE , 240);
        Property p13 = new Property("Pos13", PropertyColourType.ORANGE , 240);
        Property p14 = new Property("Pos14", PropertyColourType.ORANGE , 270);
        Property p15 = new Property("Pos15", PropertyColourType.RED , 300);
        Property p16 = new Property("Pos16", PropertyColourType.RED , 300);
        Property p17 = new Property("Pos17", PropertyColourType.RED , 330);
        Property p18 = new Property("Pos18", PropertyColourType.STATION , 200);
        Property p19 = new Property("Pos19", PropertyColourType.YELLOW , 360);
        Property p20 = new Property("Pos20", PropertyColourType.YELLOW , 360);
        Property p21 = new Property("Pos21", PropertyColourType.YELLOW , 390);
        Property p22 = new Property("Pos22", PropertyColourType.GREEN , 420);
        Property p23 = new Property("Pos23", PropertyColourType.UTIL , 125);
        Property p24 = new Property("Pos24", PropertyColourType.GREEN , 420);
        Property p25 = new Property("Pos25", PropertyColourType.GREEN , 450);
        Property p26 = new Property("Pos26", PropertyColourType.STATION , 200);
        Property p27 = new Property("Pos27", PropertyColourType.DEEPBLUE , 480);
        Property p28 = new Property("Pos28", PropertyColourType.DEEPBLUE , 500);
        bT.add(p1);
        bT.add(p2);
        bT.add(p3);
        bT.add(p4);
        bT.add(p5);
        bT.add(p6);
        bT.add(p7);
        bT.add(p8);
        bT.add(p9);
        bT.add(p10);
        bT.add(p11);
        bT.add(p12);
        bT.add(p13);
        bT.add(p14);
        bT.add(p15);
        bT.add(p16);
        bT.add(p17);
        bT.add(p18);
        bT.add(p19);
        bT.add(p20);
        bT.add(p21);
        bT.add(p22);
        bT.add(p23);
        bT.add(p24);
        bT.add(p25);
        bT.add(p26);
        bT.add(p27);
        bT.add(p28);   
    }
    
    public int roll() {
        //Simulates dice roll.
        Random rand = new Random();
        int dice1 = rand.nextInt(6);
        dice1 +=1;
        int dice2 = rand.nextInt(6);
        dice2 +=1;
        return dice1+dice2;
    }
    
    public void addTwoPlayers(Player p1, Player p2) {
        //Adds the two players to the list.
        playerList.add(p1);
        playerList.add(p2);
    }
    
    public void simFirstxMoves(int x, Player p1, Player p2) {
        for (int i=0; i < x;i++) {
            int p1roll = roll();
            p1.upDatePos(p1roll);
            System.out.println("Player " + p1.getPlayerID() + " rolled: " + p1roll);
            int y = p1.getPos() +  1;
            System.out.println("Player " + p1.getPlayerID() + " current position: " + y);
            Property p = getBoardTiles().get(p1.getPos());
            System.out.println("Player " + p1.getPlayerID() + "'s roll landed them on: " + p.getName());
            p1.buyProp(p);
            
            int p2roll = roll();
            p2.upDatePos(p2roll);
            System.out.println("Player " + p2.getPlayerID() + " rolled: " + p2roll);
            int z = p2.getPos() +  1;
            System.out.println("Player " + p2.getPlayerID() + " current position: " + z);
            Property px = getBoardTiles().get(p2.getPos());
            System.out.println("Player " + p2.getPlayerID() + "'s roll landed them on: " + px.getName());
            p2.buyProp(px);
        }
    }
    
    public void playerTurn(Player p) {
        int proll = roll();
        p.upDatePos(proll);
        System.out.println("Player " + p.getPlayerID() + " rolled: " + proll);
        int y = p.getPos() +  1;
        System.out.println("Player " + p.getPlayerID() + " current position: " + y);
        Property px = getBoardTiles().get(p.getPos());
        System.out.println("Player " + p.getPlayerID() + "'s roll landed them on: " + px.getName());
        shouldBuyProp(p, px);

    }
    
    public void shouldBuyProp(Player p, Property prop) {
        double buyChance = 0;
        PropertyColourType colourOfProp = prop.getColour();
        //Depending on Colour
        switch(colourOfProp) {
            //Not wanted, low value calc
            case BROWN: 
                buyChance += (Math.random() * (0.5 - 0.01) + 0.01);
                break;
            //Again not really wanted, low value calc
            case BLUE:
                buyChance += (Math.random() * (0.5 - 0.01) + 0.01);
                break;
            //Slightly more valuable, but still lower end of table
            case PURPLE:
                buyChance += (Math.random() * (0.6 - 0.01) + 0.01);
                break;
            //Quite valuable
            case ORANGE:
                buyChance += (Math.random() * (0.5 - 0.1) + 0.1);
                break;
            //Very Valuable
            case RED:
                buyChance += (Math.random() * (1 - 0.5) + 0.5);
                break;
            //Very Valuable
            case YELLOW:
                buyChance += (Math.random() * (1 - 0.6) + 0.6);
                break;
            //Very Valuable
            case GREEN:
                buyChance += (Math.random() * (1 - 0.7) + 0.7);
                break;
            //Quite valuable
            case DEEPBLUE:
                buyChance += (Math.random() * (0.4 - 0.1) + 0.1);
                break;
            // No chance
            case UTIL:
                buyChance += (Math.random() * (0.1 - 0.01) + 0.01);
                break;
            // No chance
            case STATION:
                buyChance += (Math.random() * (0.1 - 0.01) + 0.01);
                break;
        }
        //Depending on amount of current colour is held by the player.
        int amount = p.getColAmount(colourOfProp);
        if (amount > 1) {
            buyChance += (Math.random() * (1 - 0.4) + 0.4);
        }
        //None of these really wanted, but completes a set
        else if (amount == 1 && ((prop.getColour() == PropertyColourType.DEEPBLUE) || (prop.getColour() == PropertyColourType.BROWN)) || (prop.getColour() == PropertyColourType.UTIL)) {
            buyChance +=(Math.random() * (0.5 - 0.3) + 0.3);
        }
        //Depending on the amount of colour left available on the board. can stop other players getting monopoly
        int x = 0;
        for (Property property: getBoardTiles()) {
            if (property.getOwned() == TRUE) {
                if (property.getColour() == colourOfProp) {
                    x++;
                }
            }   
        }
        switch(x) {
            //None available to be purchased.
            case 0:
                buyChance = 0;
                break;
            case 1:
                buyChance += (Math.random() * (1 - 0.5) + 0.6);
                break;
            case 2:
                buyChance += (Math.random() * (1 - 0.1) + 0.1);
                break;
            //Still lots availble
            case 3:
                buyChance += (Math.random() * (1 - 0.05) + 0.05);
                break;
            //Station
            case 4:
                buyChance += (Math.random() * (1 - 0.01) + 0.01);
                break; 
            default:
                buyChance += (Math.random() * (1 - 0.01) + 0.01);
                
        }
        //No point having more than 1, as will go through as long as >= 1.00
        if (buyChance > 1) {
            buyChance = 1.00;
        }
        //Random 0 - 1 gen
        double min = 0.01;
        double max = 1.00;
        double random_double = Math.random() * (max - min) + min;
        System.out.println("Random gen: " + random_double);
        System.out.println("Buy Chance: " + buyChance);
    
        if (random_double <= buyChance) {
            p.buyProp(prop);
            }
        else {
            System.out.println("Player " + p.getPlayerID() + " has not bought the property!\n");
        }
        }

    
          
    
}
