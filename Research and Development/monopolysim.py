def monopoly(turnsPerGame=100,numberOfGames=100000):
    #Needed for dice along with shuffling chance & chest.
    import random
    from random import shuffle
    #100 Turns per game, for 100,000 Games. Leads to 10 million Individual turns.
    turns_per_game = turnsPerGame
    total_games = numberOfGames
    #Will store the number of times each tile is landed on.
    numberOfLandsPerTile = []
    #Initializes the Array of size 40 (0-39), one for each tile on the board.
    while len(numberOfLandsPerTile) < 40:
        numberOfLandsPerTile.append(0)
    # For two six sided dice, 36 possible results (6^2), random will choose one of these per turn.
    diceValues = [2,3,4,5,6,7,3,4,5,6,7,8,4,5,6,7,8,9,5,6,7,8,9,10,6,7,8,9,10,11,7,8,9,10,11,12]
    #Number of games completed, increments by one after each finished game.
    gamesCompleted = 0
    #As long as 10000 games havent been played.
    while gamesCompleted < total_games:
        #The different cards Community Chest, include go to Go (0) & Jail (10)
        com_chest = [0,40,40,40,40,10,40,40,40,40,40,40,40,40,40,40]
        chest = [i for i in com_chest]
        #Shuffles the array so .pop() generates 'random' output
        shuffle(chest)
        #The different cards Chance, include go to Go (0), Jail (10), B - go back three spaces, U - nearest util, S - nearest railroad, and all non 40's to a space.
        master_chance = [0,24,11,'U','S',40,40,'B',10,40,40,5,39,40,40,40]
        chance = [i for i in master_chance]
        shuffle(chance)
        #Double counter
        doubleCounter = 0
        #Start position, number of turns in current game set to 0.
        position = 0
        turns = 0
        #As long as 100 turns have not been completed.
        while turns < turns_per_game:
            #generates a random number between 0 - 35 for the diceValues array.
            diceroll = int(36*random.random())
            #If one of the double values. (I.e. double 1, double 2 etc.)
            if diceroll in [0,7,14,21,28,35]:
                doubleCounter += 1
            else:
                #If not a double reset double counter to 0 as we only care if they are in a row
                doubleCounter = 0
            #If player has rolled three doubles in a row - jail    
            if doubleCounter >= 3:
                position = 10
            else:
                #Updates player position to match roll. Modulo used to allow for rollover back to 0 after last space.
                position = (position + diceValues[diceroll])%40
                #If player lands on chance
                if position in [7,22,33]:
                    chance_card = chance.pop(0)
                    #If no new cards in chance pile, refresh chance pile.
                    if len(chance) == 0:
                        chance = [i for i in master_chance]
                        shuffle(chance)
                    #If chance card is not a payment / fine card.
                    if chance_card != 40:
                        #If its a number value, moved to that location, i.e. 0 to Go.
                        if isinstance(chance_card,int):
                            position = chance_card
                        #Nearest utility
                        elif chance_card == 'U':
                            while position not in [12,28]:
                                position = (position + 1)%40
                        #Nearest Station/Railroad
                        elif chance_card == 'S':
                            while position not in [5,15,25,35]:
                                position = (position + 1)%40
                        #Back three spaces card
                        elif chance_card == 'B':
                            position = position - 3
                #If lands on community chest            
                elif position in [2,17]:
                    chest_card = chest.pop(0)
                    #If deck is empty, restack and shuffle.
                    if len(chest) == 0:
                        chest = [i for i in com_chest]
                        shuffle(chest)
                    #sets position to location on chest i.e. 10 is Jail, 0 is Go
                    if chest_card != 40:
                        position = chest_card
                #If player lands on GoToJail, send to Jail before turn ends.        
                if position == 30: # Go to jail
                    position = 10
                    
            #depending on postion, adds 1 to current position, as player has ended a turn on that tile.       
            numberOfLandsPerTile.insert(position,(numberOfLandsPerTile.pop(position)+1))
            #Number of turns incremented.
            turns += 1
        #If 100 turns completed, a game is complete.
        gamesCompleted += 1
    
    #Returns the total amount of times a player lands on each tile over the x amount of games * x amount of turns per game.
    return numberOfLandsPerTile
m = monopoly()
print(m)

