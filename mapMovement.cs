using System;
using System.ComponentModel;
using System.Threading.Channels;

public class Map
{
    #region VARS
    public int mapBorders; 
    
    private bool settingMap = true;
    
    private string playerInput;

    public int _playerX;
    public int _playerY;

    #endregion
    public void CreateMap() //Main function
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
    public int GetPlayerX
    {
        get  { return _playerX; }
    }
    public int GetPlayerY
    {
        get { return _playerY; }
    }
}


