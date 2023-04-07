// Напишите программу вычисления функции Аккермана с помощью рекурсии. 
// Даны два неотрицательных числа m и n.
// m = 2, n = 3 -> A(m,n) = 9
// m = 3, n = 2 -> A(m,n) = 29

using System;

namespace L9_E68
{
    class Program
    {
        static void Main()
        {
            PrintCaption();
            int m = GetFirstNumber();
            int n = GetSecondNumber();
            int result = AckermannFunction(m, n);
            PrintResult(m, n, result);
        }
        static void PrintCaption()
        {
            Console.Clear();
            Console.WriteLine("Вычисления функции Аккермана с помощью рекурсии\n");
        }
        static int GetFirstNumber()
        {
            Console.Write("Введите первое неотрицательное целое число (M): ");
            return int.Parse(Console.ReadLine());
        }
        static int GetSecondNumber()
        {
            Console.Write("Введите второе неотрицательное целое число (N): ");
            return int.Parse(Console.ReadLine());
        }
        static int AckermannFunction(int m, int n)
        {
            if(m == 0)
                return n + 1;
            if(m > 0 && n == 0)
                return AckermannFunction(m - 1, 1);
            return AckermannFunction(m - 1,
                AckermannFunction(m, n - 1));
        }
        static void PrintResult(int m, int n, int result)
        {
            Console.WriteLine($"\nm = {m}, " +
                $"n = {n} -> A(m,n) -> {result}");
        }
    }
}