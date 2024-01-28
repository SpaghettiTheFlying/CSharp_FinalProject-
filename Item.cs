using System;

public class Item
{
    public List<Item> Items;


    public bool IsTaken { get; set; }
    public string ItemName { get; set; }

    public class Letter : Item
    {
        public string Description { get; set; }

        public Letter(string itemName, string description)
        {
            ItemName = itemName;
            Description = description;
        }

        public void ReadableNotes()
        {
            Console.WriteLine($"Letter says:\n{Description}");
        }
    }
    
    public class Necklace : Item
    {

    }

    public Item()
    {
        Items = new List<Item>();
    }



    public void TakeItem(Item item)
    {
        if(!item.IsTaken)
        {
            Console.WriteLine($"You found a {item.ItemName}");
            item.IsTaken = true;

            Items.Add(item);

        }

    }

}
