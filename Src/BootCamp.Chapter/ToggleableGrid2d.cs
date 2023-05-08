using System;

namespace BootCamp.Chapter
{
    public class ToggleableGrid2D : IToggleableGrid
    {
        private readonly IGridClearer _gridClearer;
        public bool[,] Grid { get; set; }

        public ToggleableGrid2D(bool[,] toggles, IGridClearer gridClearer)
        {
            _gridClearer = gridClearer;
            Grid = toggles;
        }

        public void Toggle(int x, int y)
        {
            Grid[x, y] = !Grid[x,y];
            for (int fy = 0; fy < Grid.GetLength(1); fy++)
            {
                for (int fx = 0; fx < Grid.GetLength(0); fx++)
                {
                    if (Grid[fx,fy] == false) {Console.Write(' ');}
                    else { Console.Write('■'); }
                }
                if (fy != Grid.GetLength(1) - 1) { Console.Write(Environment.NewLine);}                
            }
        }
    }
}