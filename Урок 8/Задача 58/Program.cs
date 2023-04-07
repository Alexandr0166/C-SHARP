// Задайте две матрицы. Напишите программу, 
// которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

using System;
using System.Linq;

namespace L8_E58
{
    class Program
    {
        static void Main()
        {
            PrintCaption();
            int[] arraysSize = GetArraysSize();
            int[,] matrix1 = GetMatrix1(arraysSize);
            int[,] matrix2 = GetMatrix2(arraysSize);
            int[,] outputMatrix = MultiplyMatrices(matrix1, matrix2);
            PrintResult(matrix1,
                        matrix2,
                        outputMatrix);
        }
        static void PrintCaption()
        {
            Console.Clear();
            Console.WriteLine("Произведение двух матриц\n");
        }
        static int[] GetArraysSize()
        {
            int[] sizes;
            int C1 = -1;
            int R2 = -2;
            Console.Write("Введите через побел размерность " +
                "матриц R1xC1 и R2xC2 (R1 C1 R2 C2): ");
            do
            {
                sizes = Console.ReadLine()
                          .Split(" ")
                          .Select(x => int.Parse(x))
                          .ToArray();
                C1 = sizes[1];
                R2 = sizes[2];
                if (C1 != R2)
                    Console.Write("\nЧтобы умножить матрицы, " +
                        "C1 должно равняться R2\nВведите (R1 C1 R2 C2): ");
            }
            while (C1 != R2);
            return sizes;
        }
        static int[,] GetMatrix1(int[] arraysSize)
        {
            int[,] array = new int[arraysSize[0], arraysSize[1]];
            for (int row = 0; row < array.GetLength(0); row++)
            {
                for (int column = 0; column < array.GetLength(1); column++)
                {
                    array[row, column] = new Random().Next(1, 10);
                }
            }
            return array;
        }
        static int[,] GetMatrix2(int[] arraysSize)
        {
            int[,] array = new int[arraysSize[1], arraysSize[0]];
            for (int row = 0; row < array.GetLength(0); row++)
            {
                for (int column = 0; column < array.GetLength(1); column++)
                {
                    array[row, column] = new Random().Next(1, 10);
                }
            }
            return array;
        }
        static int[,] MultiplyMatrices(int[,] m1, int[,] m2)
        {
            int[,] result = new int[m1.GetLength(0), m2.GetLength(1)];
            
            for (int row = 0; row < m1.GetLength(0); row++)
            {
                for (int column = 0; column < m2.GetLength(1); column++)
                {
                    for (int i = 0; i < m1.GetLength(1); i++)
                    {
                        result[row, column] += m1[row, i] * m2[i, column];
                    }
                }
            }
            return result;
        }
        static void PrintResult(int[,] matrix1,
                                int[,] matrix2,
                                int[,] outputMatrix)
        {
            // Calculate area to print matrix1 and matrix2
            // side by side.
            int printHeight = matrix1.GetLength(0);
            int printWidth1 = matrix1.GetLength(1);
            int printWidth2 = matrix2.GetLength(1);
            string printWidthGap = " |  ";

            if(matrix1.GetLength(0) < matrix1.GetLength(1))
            {
                printHeight = matrix1.GetLength(1);
                printWidth2 = matrix2.GetLength(1);
            }
            /*Console.WriteLine($"printHeight = {printHeight}, " +
                              $"printWidth1 = {printWidth1}, " +
                              $"printWidth2 = {printWidth2}");*/
            
            for (int row = 0; row < printHeight; row++)
            {
                // Print matrix1 row.
                for (int column = 0; column < printWidth1; column++)
                {
                    if(row < matrix1.GetLength(0))
                        Console.Write($"{matrix1[row, column]} ");
                    else
                        Console.Write("  ");
                }
                // Print gap.
                Console.Write($"{printWidthGap}");
                // Print matrix2 row.
                for (int column = 0; column < printWidth2; column++)
                {
                    if(row < matrix2.GetLength(0))
                        Console.Write($"{matrix2[row, column]} ");
                    else
                        Console.Write("   ");
                }
                Console.WriteLine();
            }
            // Print outputMatrix.
            Console.WriteLine("\nРезультат умножения матриц:\n");
            for (int row = 0; row < outputMatrix.GetLength(0); row++)
            {
                for (int column = 0; column < outputMatrix.GetLength(1); column++)
                {
                    Console.Write($"{outputMatrix[row, column]} ");
                }
                Console.WriteLine();
            }
        }
    }
}