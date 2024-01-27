using System;
using System.Threading.Channels;

public class Map
{
    public int mapBorders; 
    private bool settingMap = true;
    private string playerInput;

    public void _CreateMap()
    {
        Console.WriteLine("And I want you to select any map size between those:\n[1]5x5\n[2]7x7\n[3]10x10");

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
    }
    private void GetInput()
    {
        playerInput = Console.ReadLine();
    }
    private void ProcessInput()
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
                mapBorders = 10;
                Console.WriteLine("10x10 map created.");
                settingMap = false;
                break;
            default:
                Console.WriteLine("Please try to select from between thoose 3 options.");
                break;
        }
    }
}
