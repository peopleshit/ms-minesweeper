using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper
{
    public class Cell
    {
        internal CellState currentCellState;
        internal int bombsAround, x, y;

        public Cell() 
        {
            currentCellState = CellState.Safe;
        }

        public Cell(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int BombsAround
        {
            get { return bombsAround; }
            set 
            { 
                bombsAround = value; 
            }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }
    }
}
