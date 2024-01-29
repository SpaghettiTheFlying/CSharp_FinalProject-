using System;
using CSharp_FinalProject;
public class Game
{
    #region VARS
    private string _playerName;
    private string playerInput;

    private bool hasLetter;

    private Map _selectedMap;
    private Item itemGame;

    #endregion
    public void GameStart(Game gameInstanceRef)
    {
        GetName();

        SelectedMap();

        GameLoop();

    }

    #region kinda constructor?
    public void SelectedMap()
    {
        _selectedMap = new Map();
        _selectedMap.CreateMap();
    }

    
   
    #endregion

    #region Inputs and Responds

    private void GetName()
    {

        Console.WriteLine("Welcome to my game which I lost my insanity while coding it.");
        Console.WriteLine("What was your name? (Just to be kind, I'm not really interested.)");
        _playerName = Console.ReadLine();

        if (_playerName == "")
        {
            Console.WriteLine("Haha! You tried to find a bug. Your name is Bug then.");
            _playerName = "Bug";
        }
        else
        {
            Console.WriteLine($"Sure. Hi {_playerName} then.");
        }

    }

    private void GameLoop()
    {
        while (true) 
        { 
            GetInput();
            ProcessInput();

            _selectedMap.CastEvent();
            _selectedMap.ExecuteTraps();
        }
    }
    
    private void GetInput()
    {
        playerInput = Console.ReadLine();
    }
    private void ProcessInput()
    {
        switch (playerInput) 
        {
            case "w":
                //-1 X
                MovePlayer(-1, 0);
                break;
            case "e":
                //+1 X
                MovePlayer(+1, 0);
                break;
            case "n":
                //+1 Y
                MovePlayer(0, +1);
                break;
            case "s":
                //-1 Y
                MovePlayer(0, -1);
                break;
            case "examine":
                //examine the clue or found object
                break;
            case "letter":
                if (_selectedMap.GetHasLetter)
                {
                    Item.Letter letter1 = new Item.Letter("Letter I.", "...ot ch-o-e C \nThere is blood on the letter. Couldn't read properly.");
                    letter1.ReadableNotes();
                }
                else { Console.WriteLine("You don't have any letter."); }
                break;
            case "exit":
                Environment.Exit(0);
                break;
            case "help":
                Console.WriteLine("w: go west\n" +
                "e: go east\n" +
                "n: go north\n" +
                "s: go south\n" +
                "examine: to examine environment or items\n" +
                "exit: to close game\n" +
                "letter: read letter");
                break;
            default:
                Console.WriteLine("Invalid command. :/");
                break;

        }
    }
    #endregion

    #region movement helper? idk
    public void MovePlayer(int changeOnX, int changeOnY)
    {
        
        _selectedMap.MoverPlayer(changeOnX, changeOnY);

        Console.WriteLine($"Current Location: ({_selectedMap.GetPlayerX}, {_selectedMap.GetPlayerY})");


    }
    #endregion
}