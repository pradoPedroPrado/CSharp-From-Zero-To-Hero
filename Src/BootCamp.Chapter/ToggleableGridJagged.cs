using System;

namespace BootCamp.Chapter
{
    public class ToggleableGridJagged : IToggleableGrid
    {
        private readonly IGridClearer _gridClearer;
        bool[][] Grid { get; set; }
 

        public ToggleableGridJagged(bool[][] toggles, IGridClearer gridClearer)
        {
            _gridClearer = gridClearer;
            Grid = toggles;
        }

        public void Toggle(int x, int y)
        {
            Grid[x][y] = !Grid[x][y];
            for (int fy = 0; fy < Grid.Length; fy++)
            {
                for (int fx = 0; fx < Grid.Length; fx++)
                {
                    if (Grid[fx][fy] == false) { Console.Write(' '); }
                    else { Console.Write('■'); }
                }
                if (fy != Grid.Length - 1) { Console.Write(Environment.NewLine); }
            }

        }
    }
}