using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestProject
{
    public class Game
    {
        Cell[] grid;
        int bombs;
        int x;
        int y;
        int[,] database = new int[10, 10];

        public Game(int x, int y, int bombs, bool fromFile)
        {
            this.x = x;
            this.y = y;
            this.bombs = bombs;
            if (fromFile)
            {
                FileProvider i = new FileProvider();
                this.grid = i.readGrid();
            }
            else
            {
                TestDataProvider i = new TestDataProvider();
                this.grid = i.readGrid();
            }
        }

        public int countBombs(int i)
        {
            int bombsCount = 0;

                if (grid[i].currentCellState == CellState.Safe)
                {
                    foreach (Cell c in grid)
                    {
                        if ((c.x == grid[i].x - 1) && (c.y == grid[i].y - 1))
                        {
                            if (c.currentCellState == CellState.Bomb)
                            {
                                bombsCount++;
                                continue;
                            }
                        }
                        if ((c.x == grid[i].x) && (c.y == grid[i].y - 1))
                        {
                            if (c.currentCellState == CellState.Bomb)
                            {
                                bombsCount++;
                                continue;
                            }
                        }
                        if ((c.x == grid[i].x + 1) && c.y == (grid[i].y - 1))
                        {
                            if (c.currentCellState == CellState.Bomb)
                            {
                                bombsCount++;
                                continue;
                            }
                        }
                        if ((c.x == grid[i].x - 1) && (c.y == grid[i].y))
                        {
                            if (c.currentCellState == CellState.Bomb)
                            {
                                bombsCount++;
                                continue;
                            }
                        }
                        if ((c.x == grid[i].x + 1) && (c.y == grid[i].y))
                        {
                            if (c.currentCellState == CellState.Bomb)
                            {
                                bombsCount++;
                                continue;
                            }
                        }
                        if ((c.x == grid[i].x - 1) && (c.y == grid[i].y + 1))
                        {
                            if (c.currentCellState == CellState.Bomb)
                            {
                                bombsCount++;
                                continue;
                            }
                        }
                        if ((c.x == grid[i].x) && (c.y == grid[i].y + 1))
                        {
                            if (c.currentCellState == CellState.Bomb)
                            {
                                bombsCount++;
                                continue;
                            }
                        }
                        if ((c.x == grid[i].x + 1) && (c.y == grid[i].y+1))
                        {
                            if (c.currentCellState == CellState.Bomb)
                            {
                                bombsCount++;
                                continue;
                            }
                        }
                    }
                }
            return bombsCount;
        }

        private void placeTheBombs()
        {
            TestDataProvider testDataProvider = new TestDataProvider();
            Cell[] array = testDataProvider.readGrid();
            Random rand = new Random();
            //Fisher–Yates shuffle.
            for (int z = 0; z < 10; z++)
            {
                int k;
                Cell temp;
                for (int i = 80; i >= 0; i--)
                {
                    k = rand.Next(0, i + 1);
                    temp = array[k];
                    array[k] = array[i];
                    array[i] = temp;
                }

                for (int i = 0; i < 10; i++)
                {
                    array[i].currentCellState = CellState.Bomb;
                    int num = array[i].X * 9 + array[i].Y;
                    database[z, i] = num;
                }
            }
        }

        public int testRandom()
        {
            int matches = 0;

            placeTheBombs();

            for (int i = 0; i < 9; i++)
            {
                for (int j = i + 1; j < 10; j++)
                {
                    for (int k = 0; k < 10; k++)
                    {
                        for (int m = 0; m < 10; m++)
                        {
                            if (database[i, k] == database[j, m])
                            {
                                matches++;
                            }
                        }
                    }
                }
            }
            return matches;
        }
    }

}
