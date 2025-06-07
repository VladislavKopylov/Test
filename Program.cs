using System;
using System.Linq;
public static class Kata
{
    public static long DivideAndMultipy(long[] numbers)
    {
        const long MOD = 1_000_000_007;

        long totalDivisions = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            while (numbers[i] % 2 == 0)
            {
                numbers[i] /= 2;
                totalDivisions++;
            }
        }
        long max = numbers.Max();
        long multiplier = 1;
        for (int i = 0; i < totalDivisions; i++)
        {
            multiplier = (multiplier * 2) % MOD;
        }
        long sum = numbers.Sum() - max + (max * multiplier % MOD);
        Console.WriteLine("Toxicity")
        return sum % MOD;
    }
}
