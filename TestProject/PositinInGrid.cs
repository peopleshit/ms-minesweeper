﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper
{
    public class PositionInGrid
    {
        int x;

        public int X
        {
            get { return x; }
            set { x = value; }
        }
        int y;

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public PositionInGrid(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

    }
}
