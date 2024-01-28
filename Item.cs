using System;

public class Item
{
    public List<Item> Items;


    public bool IsTaken { get; set; }
    public string ItemName { get; set; }

    public class Letter : Item
    {
        public void ReadableNotes(string Description)
        {
            Console.WriteLine($"Letter says:\n{Description}");
        }

    }

    Letter letter1 = new Letter()
    {
        IsTaken = false,
        ItemName = "Letter I."
    };

    
    public class Necklace : Item
    {

    }
    
    Necklace goldNecklace = new Necklace()
    {
        IsTaken = false,
        ItemName = "Golden Necklace"
    };

    public void TakeItem(Item item)
    {
        if(item.IsTaken)
        {
            return;
        }
        
        Items.Add(item);
        item.IsTaken = true;

    }

}
