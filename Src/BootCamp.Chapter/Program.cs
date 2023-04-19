namespace BootCamp.Chapter
{
    class Program
    {
        static void Main(string[] args)
        {
         Shop laPosada = new Shop();

            var sword = new Item("swordota", 400, 2);
            laPosada.Add(sword);
            var cachiporra = new Item("cachiporra", 200, 3);
            laPosada.Add(cachiporra);
            var sword2 = new Item("swordota", 400, 2);
            laPosada.Add(sword2);


        }
    }
}
