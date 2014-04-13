using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class CellElement : UserControl
    {
        private int x, y;
        private Cell currentCell;
        private ViewState currentViewState;
        internal event CellClickedHandler cellClicked;
        internal event EndGameHandler gameEnd;
        internal event OpenedCellHandler gameStart;
        internal event FlagHandler flagEdit;
        internal event PlaceTheBombsHandler firstClick;
        private bool checkedCell;

        public bool Checked
        {
            get { return checkedCell; }
            set { checkedCell = value; }
        }

        internal ViewState CurrentViewState
        {
            get { return currentViewState; }
            set 
            { 
                currentViewState = value;
                this.changePicture();
            }
        }

        public Cell CurrentCell
        {
            get { return currentCell; }
            set { currentCell = value; }
        }

        public CellElement(int x, int y)
        {
            InitializeComponent();
            currentCell = new Cell();
            Location = new Point(x, y);
            this.x = x;
            this.y = y;
            this.BackColor = Color.DarkGray;
            this.checkedCell = false;
        }

        private void сellElementMouseClick(object sender, MouseEventArgs e)
        {
            if (!Global.gameOver)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (this.currentViewState == ViewState.Closed)
                    {
                        this.CurrentViewState = ViewState.Opened;
                        if (this.currentCell.currentCellState == CellState.Bomb)
                        {
                            this.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.bomb));
                            gameEnd();
                        }
                        else
                        {
                            if (firstClick != null)
                            {
                                firstClick(this.currentCell.x, this.currentCell.y);
                            }

                            if (cellClicked != null)
                            {
                                cellClicked(this.currentCell.X, this.currentCell.Y);
                            }
                            if (gameStart != null)
                            {
                                gameStart();
                            }
                        }
                        this.Invalidate();
                    }
                }
                else if (e.Button == MouseButtons.Right)
                {
                    if (this.currentViewState != ViewState.Opened)
                    {
                        if (this.currentViewState == ViewState.Closed)
                        {
                            this.CurrentViewState = ViewState.Flagged;
                        }
                        else
                        {
                            this.CurrentViewState = ViewState.Closed;
                            flagEdit(false);
                        }
                    }
                }
            }
        }

        private void changePictureToBombCount()
        {
            switch (this.currentCell.bombsAround)
            {
                case 0:
                    this.BackColor = Color.LightGray;
                    break;
                case 1:
                    this.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.b1));
                    break;
                case 2:
                    this.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.b2));
                    break;
                case 3:
                    this.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.b3));
                    break;
                case 4:
                    this.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.b4));
                    break;
                case 5:
                    this.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.b5));
                    break;
                case 6:
                    this.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.b6));
                    break;
                case 7:
                    this.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.b7));
                    break;
                case 8:
                    this.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.b8));
                    break;
            }
        }

        private void changePicture()
        {
            if (currentViewState == ViewState.Closed)
            {
                this.BackgroundImage = null;
                this.BackColor = Color.DarkGray;
            }
            if (currentViewState == ViewState.Flagged)
            {
                this.BackgroundImage = Properties.Resources.flag;
                flagEdit(true);
            }
            if (currentViewState == ViewState.Opened)
            {

                changePictureToBombCount();
            }
            this.Invalidate();
        }
    }
}
