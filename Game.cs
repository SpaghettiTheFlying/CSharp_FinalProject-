using System;
using CSharp_FinalProject;
public class Game
{
    private string _playerName;
    private string playerInput; 
    public void GameStart(Game gameInstanceRef)
    {
        GetName();

        SelectedMap();

        GameLoop();

    }

    public void SelectedMap()
    {
        Map _selectedMap = new Map();
        _selectedMap._CreateMap();
    }



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
            GetImput();
            ProcessImput();
        }
    }
    
    private void GetImput()
    {
        playerInput = Console.ReadLine();
    }
    private void ProcessImput()
    {
        switch (playerInput) 
        {
            case "w":
                //-1 X
                break;
            case "e":
                //+1 X
                break;
            case "n":
                //+1 Y
                break;
            case "s":
                //-1 Y
                break;
            case "examine":
                //examine the clue or found object
                break;
            
            default:
                Console.WriteLine("Invalid command. :/");
                break;

        }
    }
    #endregion

}