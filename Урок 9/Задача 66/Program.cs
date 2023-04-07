// Задайте значения M и N. Напишите программу, которая 
// найдёт сумму натуральных элементов в промежутке от M до N.
// M = 1; N = 15 -> 120
// M = 4; N = 8. -> 30

using System;

namespace L9_E66
{
    class Program
    {
        static void Main()
        {
            PrintCaption();
            int firstNumber = GetFirstNumber();
            int lastNumber = GetLastNumber();
            int sum = GetSum(firstNumber, lastNumber);
            PrintResult(firstNumber,
                        lastNumber,
                        sum);
        }
        static void PrintCaption()
        {
            Console.Clear();
            Console.WriteLine("Нахождение суммы натуральных чисел в промежутке от M до N\n");
        }
        static int GetFirstNumber()
        {
            Console.Write("Введите начальное число (M): ");
            return int.Parse(Console.ReadLine());
        }
        static int GetLastNumber()
        {
            Console.Write("Введите конечное число (N): ");
            return int.Parse(Console.ReadLine());
        }
        static int GetSum(int number, int lastNumber)
        {
            if (number == lastNumber + 1)
                return 0;
            return number + GetSum(++number, lastNumber);
        }
        static void PrintResult(int firstNumber,
                                int lastNumber,
                                int sum)
        {
            Console.WriteLine($"M = {firstNumber}; " +
                $"N = {lastNumber} -> {sum}");
        }
    }
}