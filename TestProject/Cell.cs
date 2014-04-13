using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestProject
{
    enum CellState { Safe, Bomb };

    public class Cell
    {
        internal CellState currentCellState;
        internal int bombsAround, x, y;

        public Cell(int x, int y) 
        {
            currentCellState = CellState.Safe;
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
