using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    class Day05
    {

        public static void Run(string[] lines)
        {
            List<int> seats = lines.Select(x => Convert.ToInt32(x.Substring(0, 7).Replace('F', '0').Replace('B', '1'), 2) * 8 + Convert.ToInt32(x.Substring(7, 3).Replace('L', '0').Replace('R', '1'), 2)).ToList();
            
            seats.Sort();

            Console.WriteLine("Day 5:");
            Console.WriteLine("\tPart A: {0}", seats.Max());

            for(int i = 1; i < seats.Count - 1; i++)
            {
                if (!(seats[i - 1] == (seats[i] - 1) && seats[i + 1] == (seats[i] + 1)))
                {
                    Console.WriteLine("\tPart B: {0}", seats[i] + 1);
                    break;
                }
            }
        }
    }
}
