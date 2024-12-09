using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2024
{
    internal enum Sign
    {
        Positive,
        Negative
    }
    
    public static class Day02
    {
        private static bool LineSafe(List<int> lineNumbers)
        {
            bool lineSafe = true;

            HashSet<Sign> differenceSigns = new HashSet<Sign>();
                
            for (int i = 1; i < lineNumbers.Count; i++)
            {
                int difference = lineNumbers[i - 1] - lineNumbers[i];
                int differenceAbs = Math.Abs(difference);

                differenceSigns.Add(difference.Equals(differenceAbs) ? Sign.Positive : Sign.Negative);
                    
                if (differenceAbs == 0 || differenceAbs > 3 || differenceSigns.Count > 1)
                {
                    lineSafe = false;
                    break;
                }
            }

            return lineSafe;
        }

        private static bool LineSafeWithDamper(List<int> lineNumbers, int index = 0)
        {
            if (index >= lineNumbers.Count) return false;
        
            List<int> copy = new List<int>(lineNumbers);
            copy.RemoveAt(index);

            return LineSafe(copy) || LineSafeWithDamper(lineNumbers, index + 1);
        }
        
        private static int PartOne(IEnumerable<string> lines)
        {
            return lines.Select(line => line.Split(" ").Select(int.Parse).ToList()).Count(x => LineSafe(x));
        }

        private static int PartTwo(IEnumerable<string> lines)
        {
            return lines.Select(line => line.Split(" ").Select(int.Parse).ToList()).Count(x => LineSafeWithDamper(x));
        }
        
        public static void Run(IEnumerable<string> lines)
        {
            int p1;
            int p2;
            
            using (Benchmark _ = new Benchmark("Part One (Execution Time):"))
            {
                p1 = PartOne(lines);
            }
            
            Console.WriteLine($"Part One (Answer): {p1}");

            using (Benchmark _ = new Benchmark("Part Two (Execution Time):"))
            {
                p2 = PartTwo(lines);
            }
            
            Console.WriteLine($"Part Two (Answer): {p2}");
        }
    }
}