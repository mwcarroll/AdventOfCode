using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventOfCode._2024
{
    public static class Day03
    {
        private static int PartOne(IEnumerable<string> lines)
        {
            int sum = 0;

            foreach (string line in lines)
            {
                int lineTotal = 0;
                
                MatchCollection matches = Regex.Matches(line, @"mul\((\d+),(\d+)\)");

                foreach (Match match in matches)
                {
                    int x = int.Parse(match.Groups[1].Value);
                    int y = int.Parse(match.Groups[2].Value);

                    lineTotal += x * y;
                }

                sum += lineTotal;
            }
            
            return sum;
        }

        private static int PartTwo(IEnumerable<string> lines)
        {
            int sum = 0;
            bool enabled = true;
            
            foreach (string line in lines)
            {
                int lineTotal = 0;

                MatchCollection matches = Regex.Matches(line, @"mul\((\d+),(\d+)\)|do\(\)|don't\(\)");

                foreach (Match match in matches)
                {
                    switch (match.Value)
                    {
                        case "do()":
                            enabled = true;
                            break;
                        case "don't()":
                            enabled = false;
                            break;
                        default:
                            if (enabled)
                            {
                                int x = int.Parse(match.Groups[1].Value);
                                int y = int.Parse(match.Groups[2].Value);

                                lineTotal += x * y;
                            }

                            break;
                    }
                }
                
                sum += lineTotal;
            }

            return sum;
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