using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper
{
    static class Global
    {
        public static bool gameOver;
        public static int constMultiplier = 16;
        public static int startingX = 4;
        public static int startingY = 27;
        public static int bottomPanel = 40;
        public static int timerInterval = 1000;
        public static int flagsTimerInterval = 10;
        public static int bombsLocConst = 87;
        public static int timeLocConst = 18;
        public static int locConst = 5;
    }
}