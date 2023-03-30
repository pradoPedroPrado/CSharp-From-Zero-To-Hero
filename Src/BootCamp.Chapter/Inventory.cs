using System;

namespace BootCamp.Chapter
{
    public class Inventory
    {
        private Item[] _items;
        public Item[] GetItems()
        {
            return _items;
        }

        public Inventory()
        {
            _items = new Item[0];
        }

        public Item[] GetItems(string name)
        {
            return new Item[0];
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
            string name = item.GetName();
            int index = -1;
            for (int i = 0; i < _items.Length; i++)
            {
                if(name == _items[i].GetName())
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
