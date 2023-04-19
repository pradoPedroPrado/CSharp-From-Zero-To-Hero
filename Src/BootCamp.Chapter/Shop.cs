namespace BootCamp.Chapter
{
    public class Shop
    {
        public decimal Money { get ; set ; }
        public Inventory Inventory { get ; set; }

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

        public Item[] GetItems()
        {
            return Inventory.Items();
        }

        /// <summary>
        /// Adds item to the stock.
        /// If item of same name exists, does nothing.
        /// </summary>
        public void Add(Item item)
        {
            Item[] items = Inventory.Items();
            foreach (var itemInInventory in items)
            {
                if (itemInInventory.Name == item.Name) return;
            }
            Inventory.AddItem(item);
        }

        /// <summary>
        /// Removes item from the stock.
        /// If item doesn't exist, does nothing.
        /// </summary>
        /// <param name="name"></param>
        public void Remove(string name)
        {   
            Item item = new Item(name,0,0);
            Inventory.RemoveItem(item);
        }

        /// <summary>
        /// Player can sell items to a shop.
        /// All items can be sold.
        /// Shop looses money.
        /// </summary>
        /// <returns>Price of an item.</returns>
        public decimal Buy(Item item)
        {
            Money -= item.Price;
            return item.Price;
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
            Item itemToSell = null;
            Item[] items = Inventory.Items();
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].Name == item)
                {
                    itemToSell = items[i];
                    break;
                }
            }
            if (itemToSell == null) return null;
            else
            {
                Money += itemToSell.Price;
                return itemToSell;
            }
        }
    }
}