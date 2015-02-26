using System;
using System.Linq;
                /*Problem 4. Binary search
                
                    Write a program, that reads from the console an array of N integers and an integer K, 
                       sorts the array and using the method Array.BinSearch() finds the largest number in the array which is ≤ K.
                
                */
class BinarySearch
{
    static void Main()
    {
        Console.Write("Array lenght: ");
        int arrLenght = int.Parse(Console.ReadLine());
        Console.Write("K: ");
        int k = int.Parse(Console.ReadLine());

        int[] arrayOfN = new int[arrLenght];

        //Filling the array with random numbers.
        Random randGen = new Random();
        Console.Write("Array elements:");
        for (int row = 0; row < arrLenght; row++)
        {
            arrayOfN[row] = randGen.Next(1, 10);
            Console.Write(arrayOfN[row]);
        }
        Console.WriteLine();

        //Sorting and printing the sorted array.
        Array.Sort(arrayOfN);
        Console.Write("Sorted array: ");
        for (int row = 0; row < arrLenght; row++)
        {
            Console.Write(arrayOfN[row]);
        }
        Console.WriteLine();

        //Finding the largest digit <= to k.
        int index = 0;
        for (int row = 1; row < arrayOfN.Length; row++)
        {
            if (arrayOfN[row] > arrayOfN[row - 1] && arrayOfN[row] <= k)
	        {
                index = Array.BinarySearch(arrayOfN, arrayOfN[row]);
	        }
        }
        ShowWhere(arrayOfN, index);
    }

    private static void ShowWhere<T>(T[] array, int index)
    {
        if (index < 0)
        {
            index = ~index;
            Console.WriteLine("Not found.");
        }
        else
        {
            Console.WriteLine("Found at index {0}.", index);
        }
    }
}

