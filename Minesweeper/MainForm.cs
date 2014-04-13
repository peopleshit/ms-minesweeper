using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class MainForm : Form
    {
        internal static Timer timer = new Timer();
        internal static Timer flagsRemaining = new Timer();
        public static int time = 0;
        Settings settings;
        Game currentGame;
        bool first;

        public MainForm()
        {
            first = true;
            InitializeComponent();
            timer.Tick += new System.EventHandler(timerTick);
            flagsRemaining.Tick += new EventHandler(flagsRemainingTick);
            timer.Interval = Global.timerInterval;
            flagsRemaining.Interval = Global.flagsTimerInterval;
            labelTime.Text = "0";
            labelBombs.Text = "";
            flagsRemaining.Start();
        }

        void flagsRemainingTick(object sender, EventArgs e)
        {
            labelBombs.Text = currentGame.AmountOfFlags.ToString();
        }

        private void MainFormLoad(object sender, EventArgs e)
        {
            newGame();
        }

        private void exitButtonClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newgameButtonClick(object sender, EventArgs e)
        {
            time = 0;
            timer.Stop();
            flagsRemaining.Stop();
            labelTime.Text = "0";
            newGame();
        }

        private void timerTick(object sender, EventArgs e)
        {
            time++;
            labelTime.Text = time.ToString();
        }

        private void statisticsButtonClick(object sender, EventArgs e)
        {
            MessageBox.Show("Рекорды для уровней:\nНовичок (9х9, 10 мин): " + RW.Records[0, 0] + " сек.\nЛюбитель (16х16, 40 мин): " + RW.Records[1, 0] + " сек.\nПрофессионал (16х30, 99 мин): " + RW.Records[2, 0] + " сек.", "Статистика");
        }

        private void settingsButtonClick(object sender, EventArgs e)
        {
            settings.Show();
        }

        private void newGame()
        {
            timer.Stop();
            time = 0;
            this.labelTime.Text = "0";
            settings = new Settings();

            if (!first)
            {
                foreach (CellElement cell in currentGame.Grid)
                {
                    this.Controls.Remove(cell);
                }
            }
            else
            {
                first = false;
            }

            RW.getDifficulty();
            GameDifficulty currentGameDifficulty = new GameDifficulty(RW.Difficulty);
            this.Height = Global.bottomPanel + (currentGameDifficulty.sideY + 1) * Global.constMultiplier + Global.startingY;
            this.Width = (currentGameDifficulty.sideX + 1) * Global.constMultiplier + Global.startingX;
            settings.difficultyLevelChanged += new NewGameHandler(newGame);
            this.labelBombs.Location = new Point(Global.bombsLocConst, currentGameDifficulty.sideY * Global.constMultiplier + Global.startingY + Global.locConst);
            this.labelTime.Location = new Point(Global.timeLocConst, currentGameDifficulty.sideY * Global.constMultiplier + Global.startingY + Global.locConst);
            currentGame = new Game(currentGameDifficulty);

            foreach (CellElement cell in currentGame.Grid)
            {
                this.Controls.Add(cell);
            }

            if (RW.Difficulty == 0)
                labelBombs.Text = "10";

            else if (RW.Difficulty == 1)
                labelBombs.Text = "40";

            else
                labelBombs.Text = "99";
        }

        public static void endGameStats(bool result)
        {
            double percent = ((double)RW.Records[RW.Difficulty, 1] / ((double)RW.Records[RW.Difficulty, 1] + (double)RW.Records[RW.Difficulty, 2]))*100;
            string str = percent.ToString("F1");

            if (result)
            {
                MessageBox.Show("Вы проиграли. :(\nРезультаты игры:\nВыиграно: " + RW.Records[RW.Difficulty, 1] + " игр.\nПроиграно: " + RW.Records[RW.Difficulty, 2] + " игр.\nПроцент выигрышей: " + str + "%.", "Итог");
            }
            else
            {
                MessageBox.Show("Вы выиграли! :)\nРезультаты игры:\nВыиграно: " + RW.Records[RW.Difficulty, 1] + " игр.\nПроиграно: " + RW.Records[RW.Difficulty, 2] + " игр.\nПроцент выигрышей: " + str + "%.", "Итог");
            }
        }
    }
}
