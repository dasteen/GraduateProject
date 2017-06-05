using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;

namespace FinalPart
{
    class Topology
    {

        public int count = MainWindow.table1.correctedPath.Length;
        public int[][] path;
        public int[][] matrixPath;
        public int radius = 20;
        public PointCollection coordinates = new PointCollection();

        public Topology()
        {
            path = new int[count][];
            Array.Copy(MainWindow.table1.correctedPath, path, count);
            matrixPath = new int[count][];
            Array.Copy(MainWindow.table1.copyMatrix, matrixPath, count);
        }

        public void ShowMas(int[][] mas)
        {
            for (int i = 0; i < mas.Length; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < mas[i].Length; j++)
                {
                    if (mas[i][j] < 10)
                    {
                        Console.Write("     {0}", mas[i][j]);
                    }
                    else if (mas[i][j] < 100)
                    {
                        Console.Write("    {0}", mas[i][j]);
                    }
                    else if (mas[i][j] < 1000)
                    {
                        Console.Write("   {0}", mas[i][j]);
                    }
                    else if (mas[i][j] < 10000)
                    {
                        Console.Write("  {0}", mas[i][j]);
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n================================================");
        }

        public void FindCoordinates()
        {
            int x, y;

            for (int i = 0; i < count; i++)
            {
                x = Convert.ToInt32(radius * Math.Cos(2 * i * Math.PI / count));
                y = Convert.ToInt32(radius * Math.Sin(2 * i * Math.PI / count));
                coordinates.Add(new Point(x, y));
            }

        }
    }
}
