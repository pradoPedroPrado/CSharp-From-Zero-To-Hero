using System;
using System.Collections.Generic;

namespace BootCamp.Chapter
{
    public class Inventory
    {
        private List<Item> _items;
        public Inventory()
        {
            _items = new List<Item>();
        }

        public Item[] GetItems(string name)
        {
            Item[] items = new Item[0];
            for (int i = 0; i < _items.Length; i++)
            {
                if (name == _items[i].Name)
                {
                    Item[] itemsTemp = items;
                    items = new Item[items.Length + 1];
                    for (int j = 0; j < itemsTemp.Length; j++)
                    {
                        items[j] = itemsTemp[j];
                    }
                    items[^1] = _items[i];
                }
            }

            return items;
        }

        public void AddItem(Item item)
        {
            Item[] newItems;

            if (_items == null)
            {
                newItems = new Item[1];
                newItems[0] = item;
                _items = newItems;
                return;
            }

            newItems = new Item[_items.Length + 1];

            for (int i = 0; i < newItems.Length - 1; i++)
            {
                newItems[i] = _items[i];
            }

            newItems[newItems.Length - 1] = item;
            _items = newItems;

        }

        /// <summary>
        /// Removes item matching criteria by item.
        /// Does nothing if no such item exists
        /// </summary>
        public void RemoveItem(Item item)
        {
            string name = item.Name;
            int index = -1;
            for (int i = 0; i < _items.Length; i++)
            {
                if(name == _items[i].Name)
                {
                    index = i; break;
                }
            }
            if (index == -1) return;
            var newItems = new Item[_items.Length - 1];

            for (int i = 0; i < index; i++)
            {
                newItems[i] = _items[i];
            }
            for (int i = index; i < newItems.Length; i++)
            {
                newItems[i] = _items[i + 1];
            }
            _items = newItems;
        }
    }
}
