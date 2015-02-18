using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
                                /*Problem 3. Sequence n matrix
                                
                                    We are given a matrix of strings of size N x M. Sequences in the matrix we define as 
                                       sets of several neighbour elements located on the same line, column or diagonal.
                                             Write a program that finds the longest sequence of equal strings in the matrix.
                                
                                            Example:
                                           | matrix 	                    |   result 		   |   |  matrix 	     |  result  |
                                           |________________________________|__________________|   |_________________|__________|
                                           |  ha 	    fifi 	ho 	    hi  |   ha, ha, ha     |   |   s 	qq 	s    |  s, s, s |
                                           |  fo 	    ha 	    hi 	    xx  |                  |   |   pp 	pp 	s    |          |
                                           | xxx 	    ho 	    ha 	    xx	|                  |   |   pp 	qq 	s    |          |
                                            
                                            
                                            
                                            	
                                */

namespace SequenceNMatrix
{
    
    class SequenceNMatrix
    {

        public static int numberOfRows;
        public static int numberOfCols;
        public static string[,] matrix;

        //Value holders
        public static int bestSequence = 1;
        public static int bestRow = 0;
        public static int bestCol = 0;



        static void Main()
        {
            FillingTheMatrix();
            CalculatingTheBiggestSequence();
            PrintingTheMatrix();
        }

        
        static void FillingTheMatrix()
        {
            Console.Write("Number of rows: ");
            numberOfRows = int.Parse(Console.ReadLine());
            Console.Write("Number of cols: ");
            numberOfCols = int.Parse(Console.ReadLine());

            matrix = new string[numberOfRows, numberOfCols];

            for (int row = 0; row < numberOfRows; row++)
            {
                for (int col = 0; col < numberOfCols; col++)
                {
                    matrix[row, col] = Console.ReadLine();
                }
            }
        }

        private static void CalculatingTheBiggestSequence()
        {
            //Temporal value holders
            int tempRowSequence = 1;
            int tempColSequence = 1;
            int tempDiagonalSequence = 1;
            
            //For loops for checking the allelements in the array
            for (int row = 0; row < numberOfRows - 1; row++)
            {
                for (int col = 0; col < numberOfCols - 1; col++)
                {
                    //Checking is the current row elements is equal to the next row element
                    if (matrix[row, col] == matrix[row, col + 1])
                    {
                        tempRowSequence++;

                        //Checking is this sequence the biggest
                        if (tempRowSequence > tempColSequence &&
                            tempRowSequence > tempDiagonalSequence)
                        {
                            bestSequence = tempRowSequence;
                            bestRow = row;
                            bestCol = col;
                        }
                    }

                    //Checking is the current column elements is equal to the next column element
                    if (matrix[row,col] == matrix[row + 1, col])
                    {
                        tempColSequence++;

                        //Checking is this sequence the biggest
                        if (tempColSequence > tempRowSequence &&
                            tempColSequence > tempDiagonalSequence)
                        {
                            bestSequence = tempColSequence;
                            bestRow = row;
                            bestCol = col;
                        }
                    }

                    //Checking is the current elements is equal to the next element by diagonal
                    if (matrix[row,col] == matrix[row + 1, col + 1])
                    {
                        tempDiagonalSequence++;

                        //Checking is this sequence the biggest
                        if (tempDiagonalSequence > tempRowSequence &&
                            tempDiagonalSequence > tempColSequence)
                        {
                            bestSequence = tempDiagonalSequence;
                            bestRow = row;
                            bestCol = col;
                        }
                    }
                }
            }
        }

        static void PrintingTheMatrix()
        {
            Console.WriteLine("Matrix representation:");
            for (int row = 0; row < numberOfRows; row++)
            {
                for (int col = 0; col < numberOfCols; col++)
                {
                    Console.Write("{0,-5}", matrix[row, col]);
                }
                Console.WriteLine();
            }

            Console.WriteLine("Result:");
            for (int i = 0; i < bestSequence; i++)
            {
                Console.Write("{0,-10}", matrix[bestRow,bestCol]);
            }
            Console.WriteLine();
        }

    }
}
