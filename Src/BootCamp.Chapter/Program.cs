using System;

namespace BootCamp.Chapter
{
    class Program
    {
        static void Main(string[] args)
        {
            IGridClearer clearer = new GridClearer2d();
            bool[,] bools = new bool[2, 2];
            bools[0, 0] = false;
            bools[0, 1] = false;
            bools[1, 0] = false;
            bools[1, 1] = false;
            ToggleableGrid2D grid = new ToggleableGrid2D(bools, clearer);
            Console.WriteLine("begining of grid");
            grid.Toggle(1, 1);
            Console.WriteLine("end of grid");
            Console.Read();

            int[][] table = new int[2][]; // 2 rows.
            table[0] = new int[2]; // row 0.
            table[1] = new int[2]; // row 2.


        }
    }
}
