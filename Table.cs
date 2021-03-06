﻿using System;
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
        public int[][] correctedPath;
        public int[][] firstToEach;
        int[] testMas = { 3, 9, 7, 4, 8, 5, 7, 10, 6, 11 };

        public Table(int count = 5)
        {
            this.count = count;
            matrix = new int[count][];
            copyMatrix = new int[count][];
            finalPath = new int[count][];
            correctedPath = new int[count][];
            firstToEach = new int[count - 1][];
            for (int i = 0; i < count; i++)
            {
                matrix[i] = new int[count];
                copyMatrix[i] = new int[count];
                correctedPath[i] = new int[3];
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
            MakeCopyMatrix();
        }

        public void MakeCopyMatrix()
        {
            for(int i = 0; i < count; i++)
            {
                Array.Copy(matrix[i], copyMatrix[i], count);
            }
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
                if(minN < 9000)
                {
                    for (int j = 0; j < count; j++)
                    {
                        if (matrix[j][i] < 9000)
                        {
                            matrix[i][j] -= minN;
                        }
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
                if (minN < 9000)
                {
                    for (int j = 0; j < count; j++)
                    {
                        if(matrix[j][i] < 9000)
                        {
                            matrix[j][i] -= minN;
                        }
                    }
                }
            }

            //int[] lol = NeighboringNodes();
            //Console.WriteLine("d{0}{1} = {2}", lol[0], lol[1], lol[2]);
        }
        
        public int[] NeighboringNodes()
        {
            int[] h = { 0, 0, 0 };
            int d;
            
            for(int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    if(matrix[i][j] == 0)
                    {
                        matrix[i][j] = 9999;

                        int minRow = matrix[i].Min();

                        int minCol = 9999;
                        for (int k = 0; k < count; k++)
                        {
                            if(matrix[k][j] < minCol)
                            {
                                minCol = matrix[k][j];
                            }
                        }
                        d = minRow + minCol;
                        if( d > h[2] )
                        {
                            h[0] = i;
                            h[1] = j;
                            h[2] = d;
                        }
                        //Console.WriteLine("d{0}{1} = {2}", i+1, j+1, d);
                        
                        matrix[i][j] = 0;
                    }
                }
            }

            matrix[h[1]][h[0]] = 9999;

            for(int i = 0; i < count; i++)
            {
                matrix[h[0]][i] = 9999;
                matrix[i][h[1]] = 9999;
            }
            
            //Console.WriteLine("h{0}{1} = {2}", h[0], h[1], h[2]);
            return new int[]{ h[0]+1, h[1]+1, copyMatrix[h[0]][h[1]] };
        }

        public bool NullExists()
        {
            for(int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    if(matrix[i][j] == 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool NumbersExists()
        {
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    if (matrix[i][j] != 9999)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        
        public void ShowPath(int[][] path)
        {
            Console.WriteLine();
            for (int i = 0; i < path.Length; i++)
            {
                Console.Write("d-");
                for (int j = 0; j < path[i].Length - 1; j++)
                {
                    Console.Write(path[i][j]);
                }
                Console.WriteLine(" = {0}", path[i][path[i].Length - 1]);
                
                //Console.WriteLine("d{0}{1} = {2}", path[i][0], path[i][1], path[i][2]);
            }
            Console.WriteLine("\n================================================");
        }

        public void CorrectThePath()
        {
            int n = 1;
            for(int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    if (finalPath[j][0] == n)
                    {
                        Array.Copy(finalPath[j], correctedPath[i], 3);
                        n = finalPath[j][1];
                        break;
                    }
                }
            }
        }

        public void FindPath()
        {
            TestFilling();
            ShowTable();
            
            int i = 0;
            while(NumbersExists())
            {
                if (!NullExists())
                {
                    Reduce();
                }
                
                finalPath[i] = NeighboringNodes();
                
                //Console.WriteLine("d{0}{1} = {2}", finalPath[i][0], finalPath[i][1], finalPath[i][2]);

                i++;
            }
            
            CorrectThePath();
            ShowPath(correctedPath);

            FindFirstToEach();
            ShowPath(firstToEach);
        }

        public void FindFirstToEach()
        {
            int upSum = 0;
            int downSum = 0;
            for (int i = 0; i < count - 1; i++)
            {
                upSum = 0;
                downSum = 0;
                for(int j = 0; j < i + 1; j++)
                {
                    upSum += correctedPath[j][2];
                }
                for (int j = correctedPath.Length - 1; j > i; j--)
                {
                    downSum += correctedPath[j][2];
                }

                if ( upSum <= downSum )
                {
                    firstToEach[i] = new int[i + 3];
                    for (int j = 0; j < i + 2; j++)
                    {
                        firstToEach[i][j] = correctedPath[j][0];
                    }
                    firstToEach[i][firstToEach[i].Length - 1] = upSum;
                }
                else
                {
                    firstToEach[i] = new int[correctedPath.Length + 1 - i];
                    int k = correctedPath.Length - 1;
                    for (int j = 0; j < correctedPath.Length - i; j++)
                    {
                        firstToEach[i][j] = correctedPath[k][1];
                        k--;
                    }
                    firstToEach[i][firstToEach[i].Length - 1] = downSum;
                }


                
            }




        }

    }
}
