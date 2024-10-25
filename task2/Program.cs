using System;

class Program
{
    static void Main()
    {
        long N = 203060593;
        long phiN = 203030388;

        long p = 0, q = 0;

        for (long i = 2; i * i <= N; i++)
        {
            if (N % i == 0)
            {
                p = i;
                q = N / i;
                break;
            }
        }

        if (IsPrime(p) && IsPrime(q))
        {
            // Проверяем, что (p-1) * (q-1) == phiN
            if ((p - 1) * (q - 1) == phiN)
            {
                Console.WriteLine($"p = {p}, q = {q}");
            }
            else
            {
                Console.WriteLine("Ошибка: (p-1) * (q-1) не равно phiN.");
            }
        }
        else
        {
            Console.WriteLine("Ошибка: p и q не являются простыми числами.");
        }
    }

    static bool IsPrime(long number)
    {
        if (number <= 1) return false;
        if (number == 2) return true;
        if (number % 2 == 0) return false;

        for (long i = 3; i * i <= number; i += 2)
        {
            if (number % i == 0) return false;
        }

        return true;
    }
}