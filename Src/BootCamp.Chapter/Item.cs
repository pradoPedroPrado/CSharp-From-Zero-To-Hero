using System;

namespace BootCamp.Chapter
{
    public class Item
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public float Weight { get; private set; }

        public Item(string name, decimal price, float weight)
        {
            Name = name ?? throw new ArgumentNullException("Parameter name can not be null.");
            Price = price;
            Weight = weight;
        }
    }
}