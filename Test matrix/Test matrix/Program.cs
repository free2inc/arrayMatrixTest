using System;
using System.Collections.Generic;

namespace Test_matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            /// 1.A 
            /// 

            //Random rand = new Random();

            int n,m;
            Console.WriteLine("Enter matrix sizes");

            do
            {
                Console.Write("N: ");
            }
            while (!int.TryParse(Console.ReadLine(), out n));

            do
            {
                Console.Write("M: ");
            }
            while (!int.TryParse(Console.ReadLine(), out m));


            //int n = 4, m = 4;

            int[,] matrix = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {    
                    do
                    {
                        Console.Write($"Matrix {i}x{j}: ");
                    }
                    while (!int.TryParse(Console.ReadLine(), out matrix[i, j]));


                    //matrix[i, j] = rand.Next(0, 10);
                }
            }
            Console.WriteLine();

            Console.WriteLine("Initial matrix:");
            ArrayPrint(matrix);



            ///A.2

            matrix = ArraySort(matrix);

            Console.WriteLine("\nSorted matrix");
            ArrayPrint(matrix);


            ///A.3
            Console.WriteLine();
            Console.WriteLine($"Odd numbers indexes sum: {OddIndexSums(matrix)}");




            ///A.4
            Console.WriteLine();
            FindDublicateNumbers(matrix);


        }


        static void ArrayPrint(int[,] arr)
        {
            int rows = arr.GetUpperBound(0) + 1;
            int columns = arr.Length / rows;


            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{arr[i, j]}\t");
                }
                Console.WriteLine();
            }
        }

        static int[,] ArraySort(int[,] arr)
        {
            int rows = arr.GetUpperBound(0) + 1;
            int columns = arr.Length / rows;


            int[] oneDimensionArray = new int[arr.Length];
            int tempIndex = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    oneDimensionArray[tempIndex] = arr[i, j];
                    if (tempIndex <= arr.Length) tempIndex++;
                }
            }

            tempIndex = 0;

            Array.Sort(oneDimensionArray);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    arr[i, j] = oneDimensionArray[tempIndex];
                    if (tempIndex <= arr.Length) tempIndex++;
                }
            }

            return arr;

        }

        static int OddIndexSums(int[,] arr)
        {
            int sum = 0;
            int rows = arr.GetUpperBound(0) + 1;
            int columns = arr.Length / rows;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (j % 2 != 0) sum += arr[i, j];
                }
            }

            return sum;
        }


        static void FindDublicateNumbers(int[,] arr)
        {
            int rows = arr.GetUpperBound(0) + 1;
            int columns = arr.Length / rows;


            int[] oneDimensionArray = new int[arr.Length];
            int tempIndex = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    oneDimensionArray[tempIndex] = arr[i, j];
                    if (tempIndex <= arr.Length) tempIndex++;
                }
            }



            Console.WriteLine("item in oneDArray: ");
            foreach (var item in oneDimensionArray)
            {
                Console.Write($"{item} ");
            }

            //search dublicates
            var indexes = new List<int>();

            Console.WriteLine("\n");
            Console.WriteLine("index: ");

            for (int i = 0; i < oneDimensionArray.Length; i++)
            {
                for (int j = i + 1; j < oneDimensionArray.Length; j++)
                {
                    if (oneDimensionArray[i] == oneDimensionArray[j] && !indexes.Contains(j))
                    {
                        indexes.Add(j);
                        Console.WriteLine(j);
                    }
                }


            }


            var dublicateIndexes = new List<int[]>() { };

            tempIndex = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (indexes.Contains(tempIndex))
                        dublicateIndexes.Add(new int[] { i, j });

                    if (tempIndex <= arr.Length) tempIndex++;
                }
            }



            Console.WriteLine("Print dublicates:");
            foreach (var item in dublicateIndexes)
            {

                Console.Write($"{item[0]},{item[1]}");

                Console.WriteLine();
            }
        }





    }
}
