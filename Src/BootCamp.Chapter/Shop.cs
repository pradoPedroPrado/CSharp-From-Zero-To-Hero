namespace BootCamp.Chapter
{
    public class Shop
    {
        private decimal _money;
        public decimal GetMoney()
        {
            return _money;
        }

        private Inventory _inventory;

        public Shop()
        {
            _inventory = new Inventory();
            _money = 0;

        }

        public Shop(decimal money)
        {
            _money = money;
            _inventory = new Inventory();

        }

        public Item[] GetItems()
        {
            return _inventory.GetItems();
        }

        /// <summary>
        /// Adds item to the stock.
        /// If item of same name exists, does nothing.
        /// </summary>
        public void Add(Item item)
        {
            Item[] items = _inventory.GetItems();
            foreach (var itemInInventory in items)
            {
                if (itemInInventory.GetName() == item.GetName()) return;
            }
            _inventory.AddItem(item);
        }

        /// <summary>
        /// Removes item from the stock.
        /// If item doesn't exist, does nothing.
        /// </summary>
        /// <param name="name"></param>
        public void Remove(string name)
        {   
            Item item = new Item(name,0,0);
            _inventory.RemoveItem(item);
        }

        /// <summary>
        /// Player can sell items to a shop.
        /// All items can be sold.
        /// Shop looses money.
        /// </summary>
        /// <returns>Price of an item.</returns>
        public decimal Buy(Item item)
        {
            _money -= item.GetPrice();
            return item.GetPrice();
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
            Item[] items = _inventory.GetItems();
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].GetName() == item)
                {
                    itemToSell = items[i];
                    break;
                }
            }
            if (itemToSell == null) return null;
            else
            {
                _money += itemToSell.GetPrice();
                return itemToSell;
            }
        }
    }
}