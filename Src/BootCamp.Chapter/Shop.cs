using System;
using System.Collections.Generic;

namespace BootCamp.Chapter
{
    public class Shop
    {
        public decimal Money { get; set; }
        public Inventory Inventory { get; set; }
        public List<Item> Items { get => Inventory.Items; }

        public Shop()
        {
            Inventory = new Inventory();
            Money = 0;

        }

        public Shop(decimal money)
        {
            Money = money;
            Inventory = new Inventory();

        }

        //public List<Item> GetItems()
        //{
        //    return Inventory.Items;
        //}

        /// <summary>
        /// Adds item to the stock.
        /// If item of same name exists, does nothing.
        /// </summary>
        public void Add(Item item)
        {
            item = item ?? throw new ArgumentNullException("Item can´t be null.");
            if (!Inventory.Items.Contains(item))
            {
                Inventory.Items.Add(item);
            }
        }

        /// <summary>
        /// Removes item from the stock.
        /// If item doesn't exist, does nothing.
        /// </summary>
        /// <param name="name"></param>
        public void Remove(string name)
        {
            name = name ?? throw new ArgumentNullException("Name can´t be null.");
            Item itemToRemove = Inventory.Items.Find(x => x.Name == name);
            Inventory.Items.Remove(itemToRemove);

        }

        /// <summary>
        /// Player can sell items to a shop.
        /// All items can be sold.
        /// Shop looses money.
        /// </summary>
        /// <returns>Price of an item.</returns>
        public decimal Buy(Item item)
        {
            if (item.Price <= Money)
            {
                Money -= item.Price;
                return item.Price;
            }
            else { return 0; }
        }

        /// <summary>
        /// Sell item from a shop.
        /// Shop increases it's money.
        /// No money is increased if item does not exist.
        /// </summary>
        /// <returns>
        /// Item sold.
        /// Null, if no item is sold.
        /// </returns>
        public Item Sell(string item)
        {
            if (string.IsNullOrEmpty(item)) { throw new ArgumentNullException("Null or empty item not permited."); }
            Item itemToSell = Inventory.Items.Find(x => x.Name == item);
            if (itemToSell != null)
            {
                Money += itemToSell.Price;
            }
            return itemToSell;
        }
    }
}