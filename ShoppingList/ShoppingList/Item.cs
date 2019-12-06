using System;

namespace ShoppingList
{
    public class Item
    {
        public string Name { get; set; }
        public bool CheckedOff { get; set; }

        public Item(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            CheckedOff = false;
        }
    }
}