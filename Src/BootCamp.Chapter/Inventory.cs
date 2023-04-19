using System;
using System.Collections.Generic;

namespace BootCamp.Chapter
{
    public class Inventory
    {
        public List<Item> Items { get ; }

        public Inventory()
        {
            Items = new List<Item>();
        }

        public List<Item> GetItems(string name)
        {
            var items = new List<Item>();
            foreach (var item in Items)
            {
                if (item.Name == name)
                {
                    items.Add(item); 
                }
            }

            return items;
        }

        public void AddItem(Item item)
        {
            Items.Add(item);
        }

        /// <summary>
        /// Removes item matching criteria by item.
        /// Does nothing if no such item exists
        /// </summary>
        public void RemoveItem(Item item)
        {
                Items.Remove(item); 
        }
    }
}
