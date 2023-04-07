// Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
// Напишите программу, которая будет построчно выводить массив, 
// добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)

using System;
using System.Linq;

namespace L8_E60
{
    class Program
    {
        static void Main()
        {
            PrintCaption();
            int[] arraySize = GetArraySize();
            int[,,] array = GetRandomItemsArray(arraySize);
            PrintArrayWithIndexes(array);
        }
        static void PrintCaption()
        {
            Console.Clear();
            Console.WriteLine("Вывод элементов 3-мерного массива с " +
                "индексами\n");
        }
        static int[] GetArraySize()
        {
            Console.Write("Введите размер 3-мерного массива (A B C): ");
            return Console.ReadLine()
                .Split(" ")
                .Select(x => int.Parse(x))
                .ToArray();
        }
        static int[,,] GetRandomItemsArray(int[] arraySize)
        {
            int[,,] array = new int[arraySize[0], arraySize[1], arraySize[2]];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    for (int k = 0; k < array.GetLength(2); k++)
                    {
                        array[i, j, k] = new Random().Next(1, 10);
                    }
                }
            }
            return array;
        }
        static void PrintArrayWithIndexes(int[,,] array)
        {
            Console.WriteLine($"\nМассив размером {array.GetLength(0)} x " +
                $"{array.GetLength(1)} x {array.GetLength(2)}:\n");
            
            for (int k = 0; k < array.GetLength(2); k++)
            {
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        Console.Write($"{array[i, j, k]}({i},{j},{k}) ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine(); 
            }
        }
    }
}