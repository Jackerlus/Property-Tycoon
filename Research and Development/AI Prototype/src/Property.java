/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author Bayley
 */
public class Property {
    private int value;
    private PropertyColourType colour;
    private String name;
    private Boolean owned;

    public Property(String name, PropertyColourType colour, int value) {
        this.value = value;
        this.colour = colour;
        this.name = name;
        this.owned = false;
    }

    public int getValue() {
        return value;
    }

    public void setValue(int value) {
        this.value = value;
    }

    public PropertyColourType getColour() {
        return colour;
    }

    public void setColour(PropertyColourType colour) {
        this.colour = colour;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public Boolean getOwned() {
        return owned;
    }

    public void setOwned(Boolean owned) {
        this.owned = owned;
    }
    
    
    
    
    
    
    
}
