using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Minesweeper
{
    enum CellState { Safe, Bomb };
    enum ViewState { Closed, Opened, Flagged };

    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            RW.Read();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
            RW.Write();
        }
    }
}
