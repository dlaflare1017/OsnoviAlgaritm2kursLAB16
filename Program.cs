// Program.cs
using System;

int ReadInt(string prompt)
{
    while (true)
    {
        Console.Write(prompt);
        if (int.TryParse(Console.ReadLine(), out var v)) return v;
        Console.WriteLine("Введите целое число.");
    }
}

int n = ReadInt("Введите n (строки): ");
int m = ReadInt("Введите m (столбцы): ");

int[,] a = new int[n, m];

Console.WriteLine("Введите матрицу по строкам (ровно m целых чисел в строке, через пробел):");
for (int i = 0; i < n; i++)
{
    while (true)
    {
        Console.Write($"Строка {i + 1}: ");
        var parts = (Console.ReadLine() ?? "")
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        if (parts.Length != m)
        {
            Console.WriteLine($"Нужно ровно {m} чисел. Повторите ввод строки.");
            continue;
        }

        bool ok = true;
        for (int j = 0; j < m; j++)
        {
            if (!int.TryParse(parts[j], out a[i, j])) { ok = false; break; }
        }
        if (ok) break;
        Console.WriteLine("Ошибка: вводите целые числа.");
    }
}

// ищем столбец с минимальной суммой
long bestSum = long.MaxValue;
int bestJ = 0;

for (int j = 0; j < m; j++)
{
    long s = 0;
    for (int i = 0; i < n; i++) s += a[i, j];
    if (s < bestSum) { bestSum = s; bestJ = j; }
}

// вывод результата
Console.WriteLine($"\nСтолбец с минимальной суммой: #{bestJ + 1}");
Console.WriteLine($"Сумма элементов этого столбца: {bestSum}");
Console.WriteLine("Вектор-столбец:");
for (int i = 0; i < n; i++)
    Console.WriteLine(a[i, bestJ]);
