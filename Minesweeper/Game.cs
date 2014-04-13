using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Minesweeper
{
    delegate void CellClickedHandler(int x, int y);
    delegate void OpenedCellHandler();
    delegate void PlaceTheBombsHandler(int x, int y);
    delegate void EndGameHandler();
    delegate void FlagHandler(bool increment);
    delegate void NewGameHandler();

    public class Game
    {
        Random rand;
        GameDifficulty currentDifficulty;
        CellElement[,] grid;
        bool first;
        bool lost;
        private int amountOfFlags;

        public int AmountOfFlags
        {
            get { return amountOfFlags; }
        }

        public CellElement[,] Grid
        {
            get { return grid; }
            set { grid = value; }
        }

        public Game(GameDifficulty d)
        {
            rand = new Random();
            Global.gameOver = false;
            currentDifficulty = d;
            grid = new CellElement[currentDifficulty.sideX, currentDifficulty.sideY];
            lost = true;
            first = true;
            amountOfFlags = currentDifficulty.Bombs;
            for (int i = 0; i < currentDifficulty.sideX; i++)
            {
                for (int j = 0; j < currentDifficulty.sideY; j++)
                {
                    grid[i, j] = new CellElement(Global.startingX + i * Global.constMultiplier, Global.startingY + j * Global.constMultiplier);
                    grid[i, j].cellClicked += new CellClickedHandler(openCell);
                    grid[i, j].gameEnd += new EndGameHandler(gameOver);
                    grid[i, j].gameStart += new OpenedCellHandler(cellHasBeenOpened);
                    grid[i, j].flagEdit += new FlagHandler(changeFlagValue);
                    grid[i, j].firstClick += new PlaceTheBombsHandler(firstClick);
                    grid[i, j].CurrentCell.X = i;
                    grid[i, j].CurrentCell.Y = j;
                }
            }
        }

        private bool checkPositionIfExists(int x, int y)
        {
            bool result = false;

            if (x >= 0 && x < currentDifficulty.sideX && y >= 0 && y < currentDifficulty.sideY)
            {
                result = true;
            }
            return result;
        }

        private bool checkIfBombIsAtCoordinates(int x, int y)
        {
            bool result = false;
            if (checkPositionIfExists(x, y))
            {
                if (grid[x,y].CurrentCell.currentCellState == CellState.Bomb)
                    result = true;
            }
            return result;
        }

        private void placeTheBombs(int x, int y)
        {
            //Fisher–Yates shuffle.
            int count = 0;
            Cell[] array = new Cell[currentDifficulty.sideX * currentDifficulty.sideY - 1];
            for (int i = 0; i < currentDifficulty.sideX; i++)
            {
                for (int j = 0; j < currentDifficulty.sideY; j++)
                {
                    if (i != x || j != y)
                    {
                        array[count] = new Cell(i, j);
                        count++;
                    }
                }
            }
            int k;
            Cell temp;
            for (int i = count - 1; i >= 0; i--)
            {
                k = rand.Next(0, i + 1);
                temp = array[k];
                array[k] = array[i];
                array[i] = temp;
            }

            for (int i = 0; i < currentDifficulty.Bombs ; i++)
            {
                grid[array[i].X, array[i].Y].CurrentCell.currentCellState = CellState.Bomb;
            }
        }

        private void countBombs()
        {
            int bombsCount = 0;
            for (int i = 0; i < currentDifficulty.sideX; i++)
            {
                for (int j = 0; j < currentDifficulty.sideY; j++)
                {
                    if (grid[i,j].CurrentCell.currentCellState!=CellState.Bomb)
                    {
                        bombsCount = 0;
                        if (checkIfBombIsAtCoordinates(i - 1, j - 1))
                        {
                            bombsCount++;
                        }

                        if (checkIfBombIsAtCoordinates(i, j - 1))
                        {
                            bombsCount++;
                        }

                        if (checkIfBombIsAtCoordinates(i + 1, j - 1))
                        {
                            bombsCount++;
                        }

                        if (checkIfBombIsAtCoordinates(i - 1, j))
                        {
                            bombsCount++;
                        }

                        if (checkIfBombIsAtCoordinates(i + 1, j))
                        {
                            bombsCount++;
                        }

                        if (checkIfBombIsAtCoordinates(i - 1, j + 1))
                        {
                            bombsCount++;
                        }

                        if (checkIfBombIsAtCoordinates(i, j + 1))
                        {
                            bombsCount++;
                        }

                        if (checkIfBombIsAtCoordinates(i + 1, j + 1))
                        {
                            bombsCount++;
                        }

                        grid[i, j].CurrentCell.BombsAround = bombsCount;
                    }
                }
            }
        }

        private void openCell(int x, int y)
        {
            if (checkPositionIfExists(x, y))
            {
                if (grid[x, y].CurrentCell.currentCellState == CellState.Safe)
                {
                    if (!grid[x, y].Checked)
                    {
                        grid[x, y].Checked = true;

                        if (grid[x, y].CurrentCell.bombsAround != 0)
                        {
                            grid[x, y].CurrentViewState = ViewState.Opened;
                            return;
                        }
                        else
                        {
                            openCell(x - 1, y - 1);
                            openCell(x, y - 1);
                            openCell(x + 1, y - 1);
                            openCell(x - 1, y);
                            openCell(x + 1, y);
                            openCell(x - 1, y + 1);
                            openCell(x, y + 1);
                            openCell(x + 1, y + 1);

                            if (grid[x, y].CurrentViewState == ViewState.Closed)
                            {
                                grid[x, y].CurrentViewState = ViewState.Opened;
                            }
                        }
                    }
                }
            }
            return;
        }

        public void gameOver()
        {
            if (lost)
            {
                foreach (CellElement cell in grid)
                {
                    if (cell.CurrentViewState == ViewState.Closed)
                    {
                        if (cell.CurrentCell.currentCellState == CellState.Bomb)
                        {
                            cell.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.bomb));
                        }
                        cell.CurrentViewState = ViewState.Opened;
                    }
                    if (cell.CurrentViewState == ViewState.Flagged)
                    {
                        if (cell.CurrentCell.currentCellState != CellState.Bomb)
                        {
                            cell.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.noflag));
                        }
                    }

                }
                RW.Records[RW.Difficulty, 2]++;
            }
            else
            {
                if (RW.Records[RW.Difficulty,0] > MainForm.time || RW.Records[RW.Difficulty,0] == 0)
                {
                    RW.Records[RW.Difficulty,0] = MainForm.time;
                }
                RW.Records[RW.Difficulty, 1]++;
                foreach (CellElement cell in grid)
                {
                    if (cell.CurrentCell.currentCellState == CellState.Bomb && cell.CurrentViewState == ViewState.Closed)
                    {
                        cell.CurrentViewState = ViewState.Flagged;
                    }
                }
            }
            Global.gameOver = true;
            MainForm.timer.Stop();
            RW.Write();
            MainForm.endGameStats(lost);
        }

        public void cellHasBeenOpened()
        {
            if (!first)
            {
                bool allSafeAreOpened = true;
                foreach (CellElement cell in grid)
                {
                    if (cell.CurrentCell.currentCellState == CellState.Safe)
                    {
                        if (cell.CurrentViewState != ViewState.Opened)
                        {
                            allSafeAreOpened = false;
                            break;
                        }
                    }
                }
                if (allSafeAreOpened)
                {
                    lost = false;
                    gameOver();
                }
            }
            else
            {
                MainForm.timer.Start();
                MainForm.flagsRemaining.Start();
                first = false;
            }
        }

        public void changeFlagValue(bool increment)
        {
            if (increment)
            {
                amountOfFlags--;
            }
            else
            {
                amountOfFlags++;
            }
        }

        private void firstClick(int x, int y)
        {
            foreach (CellElement cell in grid)
            {
                cell.firstClick -= new PlaceTheBombsHandler(firstClick);
            }
            placeTheBombs(x, y);
            countBombs();
        }
    }
}
/*
 * Custom logic: bombs - 10-99;
 *               width - 9-30;
 *               height - 9-16.
 *               
 * Maximum bombs for combinations: (9 + i) x (9 + j) = 20 + 9 * j + 9 * i;
*/