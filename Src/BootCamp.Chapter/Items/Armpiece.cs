namespace BootCamp.Chapter.Items
{
    public class Armpiece : Item
    {
        public bool isLeft {  get; private set; }

        Armpiece(string name, decimal price, float weight, bool isLeft) : base(name, price, weight)
        {
            this.isLeft = isLeft;
        }
    }
}
