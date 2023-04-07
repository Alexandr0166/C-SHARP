// Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07

using System;

namespace L8_E62
{
    class Program
    {
        static void Main()
        {
            PrintCaption();
            int dimension = GetDimension();
            string[,] matrix = GetSpiralFilledMatrix(dimension);
            PrintResult(matrix);
        }
        static void PrintCaption()
        {
            Console.Clear();
            Console.WriteLine("Спирально заполненный массив\n");
        }
        static int GetDimension()
        {
            Console.Write("Введите размер квадратного массива: ");
            return int.Parse(Console.ReadLine());
        }
        static string[,] GetSpiralFilledMatrix(int dimension)
        {
            string[,] matrix = new string[dimension, dimension];
            int counter = 0;
            int row = 0;
            int column = -1;
            while(true)
            {
                if(!FillRight(ref matrix,
                        ref row,
                        ref column,
                        ref counter))
                    break;
                if(!FillDown(ref matrix,
                        ref row,
                        ref column,
                        ref counter))
                    break;
                if(!FillLeft(ref matrix,
                        ref row,
                        ref column,
                        ref counter))
                    break;
                if(!FillUp(ref matrix,
                        ref row,
                        ref column,
                        ref counter))
                    break;
            }
            return matrix;
        }
        /// <summary>
        /// Заполнение ячеек слева направо.
        /// </summary>
        static bool FillRight(ref string[,] matrix,
                                ref int row,
                                ref int column,
                                ref int counter)
        {
            int currentColumn = column;
            int currentRow = row;
            // Двигаемся вправо до правого края матрицы
            // либо до ближайшей справа непустой ячейки.
            for (int c = ++column; c < matrix.GetLength(1); c++)
            {
                if(matrix[row, c] == null)
                {
                    counter++;
                    currentColumn = c;
                    if(counter < 10)
                        matrix[row, c] = "0" + counter.ToString();
                    else
                        matrix[row, c] = counter.ToString();
                }
            }
            // Можно ли двигаться вниз?
            if(matrix[++currentRow, currentColumn] == null)
                {
                column = currentColumn;
                return true;
                }
            else
                return false;
        }
        
        /// <summary>
        /// Заполнение ячеек сверху вниз.
        /// </summary>
        static bool FillDown(ref string[,] matrix,
                                ref int row,
                                ref int column,
                                ref int counter)
        {
            int currentColumn = column;
            int currentRow = row;
            // Двигаемся вниз до нижнего края матрицы
            // либо до ближайшей снизу непустой ячейки.
            for (int r = ++row; r < matrix.GetLength(0); r++)
            {
                if(matrix[r, column] == null)
                {
                    counter++;
                    currentRow = r;
                    if(counter < 10)
                        matrix[r, column] = "0" + counter.ToString();
                    else
                        matrix[r, column] = counter.ToString();
                }
            }
            // Можно ли двигаться влево?
            if(matrix[currentRow, --currentColumn] == null)
            {
                row = currentRow;
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Заполнение ячеек справа налево.
        /// </summary>
        static bool FillLeft(ref string[,] matrix,
                                ref int row,
                                ref int column,
                                ref int counter)
        {
            int currentColumn = column;
            int currentRow = row;
            // Двигаемся влево до левого края матрицы
            // либо до ближайшей слева непустой ячейки.
            for (int c = --column; c >= 0; c--)
            {
                if(matrix[row, c] == null)
                {
                    counter++;
                    currentColumn = c;
                    if(counter < 10)
                        matrix[row, c] = "0" + counter.ToString();
                    else
                        matrix[row, c] = counter.ToString();
                }
            }
            // Можно ли двигаться вверх?
            if(matrix[--currentRow, currentColumn] == null)
            {
                column = currentColumn;
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// Заполнение ячеек снизу вверх.
        /// </summary>
        static bool FillUp(ref string[,] matrix,
                                ref int row,
                                ref int column,
                                ref int counter)
        {
            int currentColumn = column;
            int currentRow = row;
            // Двигаемся вверх до верхнего края матрицы
            // либо до ближайшей сверху непустой ячейки.
            for (int r = --row; r >= 0; r--)
            {
                if(matrix[r, column] == null)
                {
                    counter++;
                    currentRow = r;
                    if(counter < 10)
                        matrix[r, column] = "0" + counter.ToString();
                    else
                        matrix[r, column] = counter.ToString();
                }
            }
            // Можно ли двигаться вправо?
            if(matrix[currentRow, ++currentColumn] == null)
            {
                row = currentRow;
                return true;
            }
            else
                return false;
        }
        static void PrintResult(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    Console.Write($"{matrix[row, column]} ");
                }
                Console.WriteLine();
            }
        }
    }
}