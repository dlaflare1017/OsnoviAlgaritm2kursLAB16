// Program.cs
using System;
using MyMatrixLib;

class Program
{
    static void Main()
    {
        // читаем размеры (положительные)
        int n = MatrixUtils.ReadInt("Введите n (строки): ",
            v => v > 0, "n должно быть положительным.");
        int m = MatrixUtils.ReadInt("Введите m (столбцы): ",
            v => v > 0, "m должно быть положительным.");

        // читаем матрицу
        int[,] a = MatrixUtils.ReadIntMatrix(n, m);

        // ищем столбец с минимальной суммой
        var (bestJ, bestSum) = MatrixUtils.FindColumnWithMinSum(a);

        // вывод результата
        Console.WriteLine($"\nСтолбец с минимальной суммой: #{bestJ + 1}");
        Console.WriteLine($"Сумма элементов этого столбца: {bestSum}");
        Console.WriteLine("Вектор-столбец:");
        MatrixUtils.PrintColumn(a, bestJ);
    }
}
