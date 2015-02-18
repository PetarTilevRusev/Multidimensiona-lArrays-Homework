using System;
                /*Problem 1. Fill the matrix
              
                  Write a program that fills and prints a matrix of size (n, n) as shown below:
              
                  Example for n=4:
                              a)                  b)	                c)	                d)	
                              1 	5 	9 	13      1 	8 	9 	16      7 	11 	14 	16      1 	12 	11 	10
                              2 	6 	10 	14      2 	7 	10 	15      4 	8 	12 	15      2 	13 	16 	9
                              3 	7 	11 	15      3 	6 	11 	14      2 	5 	9 	13      3 	14 	15 	8
                              4 	8 	12 	16      4 	5 	12 	13      1 	3 	6 	10      4 	5 	6 	7             
                */

namespace FillTheMatrix
{
    class FillTheMatrix
    {
        public static int matrixParameters = int.Parse(Console.ReadLine());
        public static int[,] matrix = new int[matrixParameters, matrixParameters];

        static void Main()
        {
            SolutionByExampleA();
            SolutionByExampleB();
            SolutionByExampleC();
            SolutionByExampleD();
        }

        static void SolutionByExampleA()
        {
            int counter = 1;
            // Filling the matrix
            for (int col = 0; col < matrixParameters; col++)
            {
                for (int row = 0; row < matrixParameters; row++)
                {
                    matrix[row, col] = counter;
                    counter++;
                }

            }

            // Printing the matrix
            Console.WriteLine("Solution a): ");
            for (int row = 0; row < matrixParameters; row++)
            {
                for (int col = 0; col < matrixParameters; col++)
                {
                    Console.Write("{0,-4}", matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        static void SolutionByExampleB()
        {
            int counter = 1;
            // Filling the matrix
            for (int col = 0; col < matrixParameters; col++)
            {
                if (col % 2 == 1)
                {
                    for (int row = matrixParameters - 1; row >= 0; row--)
                    {
                        matrix[row, col] = counter;
                        counter++;
                    }
                }
                else
                {
                    for (int row = 0; row < matrixParameters; row++)
                    {
                        matrix[row, col] = counter;
                        counter++;
                    }
                }
                

            }

            // Printing the matrix
            Console.WriteLine("Solution b): ");
            for (int row = 0; row < matrixParameters; row++)
            {
                for (int col = 0; col < matrixParameters; col++)
                {
                    Console.Write("{0,-4}", matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        static void SolutionByExampleC()
        {

        }

        static void SolutionByExampleD()
        {
            int positionX = matrixParameters / 2; // The middle of the matrix   
            int positionY = matrixParameters % 2 == 0 ? (matrixParameters / 2) - 1 : (matrixParameters / 2);  


            int direction = 0; // The initial direction   
            int stepsCount = 1; // Perform 1 step in current direction   
            int stepPosition = 0; // 0 steps already performed   
            int stepChange = 0; // Steps count changes after 2 steps  


            for (int i = matrixParameters * matrixParameters; i >= 1; i--)
            {    
                // Fill the current cell with the current value    
                matrix[positionY, positionX] = i;

                // Check for direction / step changes    
                if (stepPosition < stepsCount)    
                {     
                    stepPosition++;    
                }    
                else    
                {     
                    stepPosition = 1;     
                    if (stepChange == 1)     
                    {      
                        stepsCount++;     
                    }     

                    stepChange = (stepChange + 1) % 2;     
                    direction = (direction + 1) % 4;    
                }  

                // Move to the next cell in the current direction    
                switch (direction)
                {
                    case 0:
                        positionY++;
                        break;
                    case 1:
                        positionX--;
                        break;
                    case 2:
                        positionY--;
                        break;
                    case 3:
                        positionX++;
                        break;
                }
            }

            //Printing the matrix
            Console.WriteLine("Solution d): ");
            for (int i = 0; i < matrixParameters; i++)
            {
                for (int j = 0; j < matrixParameters; j++)
                {
                    Console.Write("{0,-4}", matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
