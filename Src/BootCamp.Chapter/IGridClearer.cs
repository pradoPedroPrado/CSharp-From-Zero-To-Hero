using System;
using System.Collections.Generic;
using System.Text;

namespace BootCamp.Chapter
{
    public interface IGridClearer
    {
        void Clear();
    }

    public class GridClearer2d : IGridClearer
    {
        public void Clear()
        {
        }
    }

    public class GridClearerJagged : IGridClearer
    {
        public void Clear()
        {
        }
    }
}
