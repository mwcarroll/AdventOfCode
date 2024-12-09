using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2024
{
    public static class Day01
    {
        private static int PartOne(IEnumerable<string> lines)
        {
            List<int> leftList = new List<int>();
            List<int> rightList = new List<int>();
            
            foreach (string line in lines)
            {
                string[] splitLine = line.Split("   ");

                int left = int.Parse(splitLine[0]);
                int right = int.Parse(splitLine[1]);

                leftList.Add(left);
                rightList.Add(right);
            }
            
            leftList.Sort();
            rightList.Sort();

            return leftList.Select((x, i) => Math.Abs(x- rightList[i])).Sum();
        }

        private static int PartTwo(IEnumerable<string> lines)
        {
            List<int> leftList = new List<int>();
            List<int> rightList = new List<int>();
            
            foreach (string line in lines)
            {
                string[] splitLine = line.Split("   ");

                int left = int.Parse(splitLine[0]);
                int right = int.Parse(splitLine[1]);

                leftList.Add(left);
                rightList.Add(right);
            }

            Dictionary<int, int> listCounts = leftList.ToDictionary(left => left, left => 0);

            foreach (int right in rightList.Where(right => listCounts.ContainsKey(right)))
            {
                listCounts[right]++;
            }
            
            return listCounts.Sum(t => t.Key * t.Value);
        }
        
        public static void Run(IEnumerable<string> lines)
        {
            Console.WriteLine($"Part One: {PartOne(lines)}");
            Console.WriteLine($"Part Two: {PartTwo(lines)}");
        }
    }
}