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
    public partial class Settings : Form
    {
        internal event NewGameHandler difficultyLevelChanged;

        public Settings()
        {
            InitializeComponent();
            int level = RW.Difficulty;
            if (level == 0)
            {
                radioButtonEasy.Checked = true;
            }
            else if (level == 1)
            {
                radioButtonMedium.Checked = true;
            }
            else
            {
                radioButtonHard.Checked = true;
            }
        }

        private void buttonCloseClick(object sender, EventArgs e)
        {
            if (radioButtonEasy.Checked)
            {
                RW.Difficulty = 0;
            }
            else if (radioButtonMedium.Checked)
            {
                RW.Difficulty = 1;
            }
            else if (radioButtonHard.Checked)
            {
                RW.Difficulty = 2;
            }

            RW.Write();

            if (difficultyLevelChanged != null)
            {
                difficultyLevelChanged();
            }
            this.Close();
        }

        private void buttonResetProgressClick(object sender, EventArgs e)
        {
            RW.Difficulty = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    RW.Records[i, j] = 0;
                }
            }
            RW.defaultFile();
        }
    }
}
