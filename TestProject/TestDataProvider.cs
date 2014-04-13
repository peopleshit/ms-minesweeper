using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestProject
{
    class TestDataProvider : IDataProvider
    {
        public Cell[] readGrid()
        {
            Cell[] array = new Cell[81];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    array[i * 9 + j] = new Cell(i, j);
                    array[i * 9 + j].currentCellState = CellState.Safe;
                }
            }
            return array;
        }
    }
}
