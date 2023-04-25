namespace BootCamp.Chapter.Items
{
    public class Shoulderpiece : Item
    {
        public bool isLeft { get; private set; }

        Shoulderpiece(string name, decimal price, float weight, bool isLeft) : base(name, price, weight)
        {
            this.isLeft = isLeft;
        }
    }
}
