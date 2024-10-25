using System;

class Program
{
    static void Main()
    {
        long N = 99873791;
        long p = 0, q = 0;

        // Ищем простые числа p и q, такие что N = p * q и |p - q| <= 500
        for (long i = 2; i * i <= N; i++)
        {
            if (N % i == 0)
            {
                p = i;
                q = N / i;
                if (Math.Abs(p - q) <= 500)
                {
                    break;
                }
            }
        }

        if (p == 0 || q == 0)
        {
            Console.WriteLine("Не удалось найти подходящие простые числа.");
            return;
        }

        Console.WriteLine($"Простые множители: p = {p}, q = {q}");

        // Функция Эйлера ϕ(N)=(p−1)⋅(q−1).
        long phiN = (p - 1) * (q - 1);
        Console.WriteLine($"Количество натуральных чисел, меньших N и взаимно простых с N: {phiN}");
    }
}