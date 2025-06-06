using System;
using System.Linq;
using System.Collections.Generic;
public static class Program
{
    public static int Main()
    {
        int[] numbers = { 3, 4 };
        var nums = numbers.Select(n => n).ToList();
        if (nums.Count == 1) return (int)numbers[0];
        System.Console.WriteLine(int.Max(Typical(nums), NotTypical(nums)));
        return int.Max(Typical(nums), NotTypical(nums));
    }
    public static int Typical(List<int> nums)
    {
        var aj = nums.Max();
        var numsskip = new List<int>(nums);
        numsskip.Remove(aj);
        var AIarray = numsskip.Where(n => n % 2 == 0).ToList();
        for (int i = 0; i < AIarray.Count; i++)
        {
            int el = AIarray[i];
            while (el % 2 == 0)
            {
                nums[nums.IndexOf(aj)] = aj * 2;
                nums[nums.IndexOf(el)] = el / 2;
                el /= 2;
                aj *= 2;
            }
            AIarray.Remove(el);
        }
        return nums.Sum();
    }
    public static int NotTypical(List<int> nums)
{
    var el = GetNum(nums);
    var numsskip = new List<int>(nums);
    numsskip.Remove(el);
    int aj = numsskip.Where(n => n % 2 != 0).OrderByDescending(n => n).FirstOrDefault();
    if (aj == 0) aj = numsskip.Max();
    numsskip.Add(el);
    var AIarray = numsskip.Where(n => n % 2 == 0).ToList();
    for (int i = 0; i < AIarray.Count; i++)
    {
        int ele = AIarray[i];
        while (ele % 2 == 0)
        {
            int ajIndex = nums.IndexOf(aj);
            int eleIndex = nums.IndexOf(ele);
            if (ajIndex == -1 || eleIndex == -1) break; // Проверка на наличие элементов

            nums[ajIndex] = aj * 2;
            nums[eleIndex] = ele / 2;
            ele /= 2;
            aj *= 2;
        }
    }
    return nums.Sum();
}
    static int CountDivisionsByTwo(int number)
    {
        if (number == 0) return 0;
        int count = 0;
        while (number % 2 == 0)
        {
            number /= 2;
            count++;
        }
        return count;
    }
    static int GetNum(List<int> nums)
    {

        return nums.Select(n => CountDivisionsByTwo(n)).Max();
    }
}        