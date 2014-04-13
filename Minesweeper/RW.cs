using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Minesweeper
{
    static class RW
    {
        static int[,] records = new int[3, 3];
        static int difficulty;

        public static int[,] Records
        {
            get { return records; }
            set { records = value; }
        }

        public static int Difficulty
        {
            get { return difficulty; }
            set { difficulty = value; }
        }

        public static void Write()
        {
            checkIfExists();
            FileStream fs = new FileStream(Environment.SpecialFolder.System + @"\statistics.dat", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(difficulty);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    sw.WriteLine(records[i, j]);
                }
            }
            sw.Close();
            fs.Close();
        }

        public static void Read()
        {
            checkIfExists();
            FileStream fs = new FileStream(Environment.SpecialFolder.System + @"\statistics.dat", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            try
            {
                difficulty = int.Parse(sr.ReadLine());
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        records[i, j] = int.Parse(sr.ReadLine());
                    }
                }
                sr.Close();
                fs.Close();
            }
            catch
            {
                sr.Close();
                fs.Close();
                defaultFile();
            }
        }

        private static void checkIfExists()
        {
            if(!Directory.Exists(Environment.SpecialFolder.System+""))
            {
                Directory.CreateDirectory(Environment.SpecialFolder.System + "");
                defaultFile();
            }
            if (!File.Exists(Environment.SpecialFolder.System + @"\statistics.dat"))
            {
                defaultFile();
            }
        }

        public static void defaultFile()
        {
            FileStream fs = new FileStream(Environment.SpecialFolder.System + @"\statistics.dat", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            for (int i = 0; i < 10; i++)
            {
                sw.WriteLine(0);
            }

            sw.Close();
            fs.Close();
        }

        public static void getDifficulty()
        {
            FileStream fs = new FileStream(Environment.SpecialFolder.System + @"\statistics.dat", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            try
            {
                difficulty = int.Parse(sr.ReadLine());
                sr.Close();
                fs.Close();
            }
            catch
            {
                sr.Close();
                fs.Close();
                defaultFile();
            }
        }
    }
}
