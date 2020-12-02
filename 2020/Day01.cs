using System;
using System.IO;

namespace AdventOfCode
{
    class Day01
    {
        static int? PairProduct(int[] arr, int sum)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] + arr[j] == sum)
                    {
                        return arr[i] * arr[j];
                    }
                }
            }

            return null;
        }

        static int? TrioProduct(int[] arr, int sum)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    for (int k = j + 1; k < arr.Length; k++)
                    {
                        if (arr[i] + arr[j] + arr[k] == sum)
                        {
                            return arr[i] * arr[j] * arr[k];
                        }
                    }
                }
            }

            return null;
        }

        static void Main(string[] args)
        {
            int[] lines = Array.ConvertAll(File.ReadAllLines(@"input.txt"), int.Parse);

            Console.WriteLine("Part A: {0}", PairProduct(lines, 2020));
            Console.WriteLine("Part B: {0}", TrioProduct(lines, 2020));
        }
    }
}
