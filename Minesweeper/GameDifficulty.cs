using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper
{
    public class GameDifficulty
    {
        int x;
        int y;
        int bombs;

        public int sideX
        {
            get { return x; }
        }

        public int sideY
        {
            get { return y; }
        }

        public int Bombs
        {
            get { return bombs; }
        }

        public GameDifficulty(int c)
        {
            switch (c)
            {
                case 0:
                    x = 9;
                    y = 9;
                    bombs = 10;
                    break;
                case 1:
                    x = 16;
                    y = 16;
                    bombs = 40;
                    break;
                case 2:
                    x = 30;
                    y = 16;
                    bombs = 99;
                    break;
            }
        }
    }
}
