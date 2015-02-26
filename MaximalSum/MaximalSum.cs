using System;
               /*Problem 2. Maximal sum
               
                   Write a program that reads a rectangular matrix of size N x M and finds in it the square 3 x 3 that has maximal sum of its elements.
               */

namespace MaximalSum
{
    class MaximalSum
    {

        public static int n;
        public static int m;
        public static int[,] matrix;
        //Value holders
        public static int bestSum = int.MinValue;
        public static int bestRow = 0;
        public static int bestCol = 0;


        static void Main()
        {

            FillingTheMatrix();
            CalculatingTheMaximalSum();
            PrintingTheResult();

        }


        static void FillingTheMatrix()
        {
            Console.WriteLine("WARNING: N and M shuld be bigger or equal to 3"); // By task "... it the square 3 x 3 that has maximal sum of its elements."
            Console.Write("N: ");
            n = int.Parse(Console.ReadLine());
            Console.Write("M: ");
            m = int.Parse(Console.ReadLine());

            matrix = new int[n, m];


            if (n < 3 || m < 3)
            {
                Console.WriteLine("You have entered a invalid \"N\" or \"M\" values");
                return;
            }

            Random randomGenerator = new Random();
            // Filling the matrix with random numbers
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < m; col++)
                {
                    matrix[row, col] = randomGenerator.Next(30);
                    Console.Write("{0,-5}", matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        static void CalculatingTheMaximalSum()
        {
            for (int row = 0; row < n - 2; row++)
            {
                for (int col = 0; col < m - 2; col++)
                {
                    int sum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] +
                              matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
                              matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                    if (sum > bestSum)
                    {
                        bestSum = sum;
                        bestRow = row;
                        bestCol = col;
                    }
                }

            }
        }

        static void PrintingTheResult()
        {
            Console.WriteLine("The best sequence");
            Console.WriteLine("{0,-5} {1,-5} {2,-5}", matrix[bestRow, bestCol],
                                                      matrix[bestRow, bestCol + 1],
                                                      matrix[bestRow, bestCol + 2]);

            Console.WriteLine("{0,-5} {1,-5} {2,-5}", matrix[bestRow + 1, bestCol],
                                                      matrix[bestRow + 1, bestCol + 1],
                                                      matrix[bestRow + 1, bestCol + 2]);

            Console.WriteLine("{0,-5} {1,-5} {2,-5}", matrix[bestRow + 2, bestCol],
                                                      matrix[bestRow + 2, bestCol + 1],
                                                      matrix[bestRow + 2, bestCol + 2]);
            Console.Write("\nThe sum of the elements is: {0}", bestSum);
            Console.WriteLine();
        }

    }

}

