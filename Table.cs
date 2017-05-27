using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalPart
{
    public class Table
    {
        public int count;
        public int[][] matrix;
        public int[][] copyMatrix;
        public int[][] finalPath;
        int[] testMas = { 3, 9, 7, 4, 8, 5, 7, 10, 6, 11 };

        public Table(int count = 5)
        {
            this.count = count;
            matrix = new int[count][];
            copyMatrix = new int[count][];
            finalPath = new int[count][];
            for (int i = 0; i < count; i++)
            {
                matrix[i] = new int[count];
                copyMatrix[i] = new int[count];
            }
            for (int i = 0; i < count; i++)
            {
                matrix[i][i] = 9999;
            }
        }

        public void ShowTable()
        {
            for(int i = 0; i < count; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < count; j++)
                {
                    if(matrix[i][j] < 10)
                    {
                        Console.Write("     {0}", matrix[i][j]);
                    }
                    else if(matrix[i][j] < 100)
                    {
                        Console.Write("    {0}", matrix[i][j]);
                    }
                    else if (matrix[i][j] < 1000)
                    {
                        Console.Write("   {0}", matrix[i][j]);
                    }
                    else if (matrix[i][j] < 10000)
                    {
                        Console.Write("  {0}", matrix[i][j]);
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n================================================");
        }

        public void ShowCopyTable()
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < count; j++)
                {
                    if (copyMatrix[i][j] < 10)
                    {
                        Console.Write("     {0}", copyMatrix[i][j]);
                    }
                    else if (copyMatrix[i][j] < 100)
                    {
                        Console.Write("    {0}", copyMatrix[i][j]);
                    }
                    else if (copyMatrix[i][j] < 1000)
                    {
                        Console.Write("   {0}", copyMatrix[i][j]);
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n================================================");
        }

        public void TestFilling()
        {
            int n = 0;
            for (int i = 0; i < count - 1; i++)
            {
                for (int j = i + 1; j < count; j++)
                {
                    matrix[i][j] = testMas[n];
                    matrix[j][i] = testMas[n];
                    n++;
                }
            }

            Array.Copy(matrix, copyMatrix, count);
        }

        public void Reduce()
        {
            int[] minRowMas = new int[count];
            int[] minColMas = new int[count];
            int minN, minI, minJ;

            for (int i = 0; i < count; i++)
            {
                minN = 9999;
                minI = 0;
                minJ = 0;
                for (int j = 0; j < count; j++)
                {
                    if(minN > matrix[i][j])
                    {
                        minN = matrix[i][j];
                        minI = i;
                        minJ = j;
                    }
                }
                if(minN < 3000)
                {
                    for (int j = 0; j < count; j++)
                    {
                        matrix[i][j] -= minN;
                    }
                }
            }

            

            for (int i = 0; i < count; i++)
            {
                minN = 9999;
                minI = 0;
                minJ = 0;
                for (int j = 0; j < count; j++)
                {
                    if (minN > matrix[j][i])
                    {
                        minN = matrix[j][i];
                        minI = i;
                        minJ = j;
                    }
                }
                if (minN < 3000)
                {
                    if (minN < 3000)
                    {
                        for (int j = 0; j < count; j++)
                        {
                            matrix[j][i] -= minN;
                        }
                    }
                }
            }
        }
        
        public void NeighboringNodes()
        {

        }
    }
}
