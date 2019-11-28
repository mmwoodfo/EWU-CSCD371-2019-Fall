using System;

namespace ShoppingList
{
    public class Item
    {
        public string Name { get; set; }
        public int Amount { get; set; }

        public Item(string name, int amount)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Amount = amount;
        }
    }
}
