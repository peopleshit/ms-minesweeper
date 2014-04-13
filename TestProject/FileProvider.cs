using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TestProject
{
    class FileProvider : IDataProvider
    {
        public Cell[] readGrid()
        {
            if (!Directory.Exists(Environment.SpecialFolder.System + ""))
            {
                createPath();
            }
            if (!File.Exists(Environment.SpecialFolder.System + @"\testarray.txt"))
            {
                createGrid();
            }
            Cell[] array = new Cell[81];
            FileStream fs = new FileStream(Environment.SpecialFolder.System + @"\testarray.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            int num;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (int.TryParse(sr.ReadLine(), out num))
                    {
                        array[i * 9 + j] = new Cell(i, j);
                        if (num == 1)
                        {
                            array[i * 9 + j].currentCellState = CellState.Bomb;
                        }
                        else if (num == 0)
                        {
                            array[i * 9 + j].currentCellState = CellState.Safe;
                        }
                        else
                        {
                            throw new Exception("Wrong number in file");
                        }
                    }
                    else
                    {
                        throw new Exception("Couldn' t parse line in num, line");
                    }
                }
            }
            sr.Close();
            fs.Close();
            return array;
        }

        private void createGrid()
        {
            FileStream fs = new FileStream(Environment.SpecialFolder.System + @"\testarray.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            for (int i = 0; i < 81; i++)
            {
                sw.WriteLine("0");
            }
            sw.Close();
            fs.Close();
        }

        private void createPath()
        {
            Directory.CreateDirectory(Environment.SpecialFolder.System + "");
            createGrid();
        }
    }
}
