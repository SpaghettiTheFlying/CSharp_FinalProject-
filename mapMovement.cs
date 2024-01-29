using System;
using System.ComponentModel;
using System.Threading.Channels;

public class Map
{
    #region VARS
    public int mapBorders;

    private Game _game;

    private bool settingMap = true;

    private string playerInput;

    private bool hasLetter;

    private bool hasNecklace = false;


    public int _playerX;
    public int _playerY;


    private List<Item> items = new List<Item>();

    #region Get-Set
    public bool GetHasNecklace
    {
        get { return hasNecklace; }
    }
    public bool GetHasLetter
    {
        get { return hasLetter; }
    }
    public int GetPlayerX
    {
        get { return _playerX; }
    }
    public int GetPlayerY
    {
        get { return _playerY; }
    }

    #endregion

    #endregion

    #region Map Selection
    public void CreateMap() //Main function for map selection
    {
        Console.WriteLine("And I want you to select any map size between those:\n[1]5x5\n[2]7x7\n[3]9x9");

        StartMapSelection();

    }
    private void StartMapSelection()
    {
        while (settingMap)
        {
            GetInput();
            ProcessInput();

            if (!settingMap) break;

        }
    } //Loop
    private void GetInput()
    {
        playerInput = Console.ReadLine();
    }
    private void ProcessInput() //Lets you select a map size
    {
        switch (playerInput)

        {
            case "1":
                mapBorders = 5;
                Console.WriteLine("5x5 map created.");
                settingMap = false;
                break;
            case "2":
                mapBorders = 7;
                Console.WriteLine("7x7 map created.");
                settingMap = false;
                break;
            case "3":
                mapBorders = 9;
                Console.WriteLine("9x9 map created.");
                settingMap = false;
                break;
            default:
                Console.WriteLine("Please try to select from between thoose 3 options.");
                break;
        }

    }
    #endregion

    #region Movement
    public void MoverPlayer(int changeOnX, int changeOnY) //Changes current location values
    {
        int minX = -(mapBorders / 2);
        int maxX = mapBorders / 2;
        int minY = -(mapBorders / 2);
        int maxY = mapBorders / 2;

        // Update the player's position if the move is possible
        int newPlayerX = Math.Max(minX, Math.Min(maxX, _playerX + changeOnX));
        int newPlayerY = Math.Max(minY, Math.Min(maxY, _playerY + changeOnY));

        if (newPlayerX == _playerX && newPlayerY == _playerY) //Checks if player can go wanted location
        {
            Console.WriteLine("Nope, you cannot go that way. Current position didn't changed.");
        }
        else
        {
            // Update the player's position based on the changed values
            _playerX = newPlayerX;
            _playerY = newPlayerY;


        }
    }


    #endregion

    #region Events On Places

    public void CastEvent()
    {
        switch (GetPlayerX, GetPlayerY)
        {
            case (2, -2):
                RiddleEvent();
                break;
            case (4, 4):
                Console.WriteLine("You found a 'Golden Necklace'");
                Item.Necklace goldNecklace = new Item.Necklace { ItemName = "Golden Necklace" };
                TakeItem(goldNecklace);
                hasNecklace = true;
                break;
            case (1, 2):
                if (!hasLetter) 
                {

                Console.WriteLine("You found a letter!");
                Item.Letter letter1 = new Item.Letter("Letter I.", "");
                TakeItem(letter1);
                hasLetter = true;
                
                }
                break;
             default: break;
        }
    }
    public void SetGameInstance(Game game)
    {
        _game = game;
    }
    public void TakeItem(Item item)
    {
        items.Add(item);
        item.IsTaken = true;
    }

    #region EVENTS
    public void RiddleEvent()
    {
        Console.WriteLine("You encounter the Riddler!");

        // Display riddle and options
        Console.WriteLine("I have keys but open no locks. I have space but no room. You can enter, but you can't go inside. What am I?");
        Console.WriteLine("[a] A door");
        Console.WriteLine("[b] A keyboard");
        Console.WriteLine("[c] A computer");
        Console.WriteLine("[d] A book");
        Console.WriteLine("[e] An elevator");
        if (hasNecklace)
        {
            Console.WriteLine("[f] (Give 'Golden Necklace' to Riddler.)");
        }

        string playerAnswer = Console.ReadLine();

        // Check the answer
        if (playerAnswer == "b")
        {
            Console.WriteLine("Correct! You won!");
            EndGame();

        }
        else if(playerAnswer == null || playerAnswer == "") 
        {
            Console.WriteLine("Riddler got bored and gone, left you with your thoughts. You started a family and a decent life. But never found the answer. You died, peacefully.");
            EndGame();
        }
        else if (playerAnswer == "f" && hasNecklace == true)
        {
            Console.WriteLine("You gave 'Golden Necklace' to Riddler. She loved it. You won!");
        }
        else
        {
            Console.WriteLine("Wrong answer! The Riddler vanishes. Place collapses. You died.");
            EndGame();
        }
    }

    public void ExecuteTraps() 
    { 
            
        int[,] deathPoints =  { { -1, 1 }, { -2, -2 }, { 0, 2 }, { 3, -2 }, { 3, 2 }, { 3, 3 }, { 2, 3 }, { 1, -4 }, { -2, 4 }, { 3, 4 } };
       
        for (int i = 0; i < 10;  i++) //Going through x coords
        {

            if (deathPoints[i, 0] == _playerX && deathPoints[i, 1] == _playerY)
            {
                giveRandomDeath();
            }
            else
            {

            }

        }       
    }
    
    public void giveRandomDeath()
    {
        Random randomDeath = new Random();

        string[] DeathCauses = {    "A Dwayne Johnson fell to your head. You died." ,
                                "You have see a gigantic assignment. You had a hearth attack. You died.",
                                "You stepped into a button. An arrow got stuck right next to your head.\n" +
                                "While you are trying to understand what is happened, dozens of arrows started to rain onto you.\n" +
                                "You died."};

        int deathIndex = randomDeath.Next(DeathCauses.Length);

        Console.WriteLine(DeathCauses[deathIndex]);

        Environment.Exit(0);
    }

    public void EndGame()
    {
        Environment.Exit(0);
    }

    #endregion

    #endregion
}