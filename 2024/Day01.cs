using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        private static int PartTwo_Alt(IEnumerable<string> lines)
        {
            List<Tuple<int, int, int>> countList = new List<Tuple<int, int, int>>();

            foreach (string line in lines)
            {
                string[] splitLine = line.Split("   ");

                int left = int.Parse(splitLine[0]);
                int right = int.Parse(splitLine[1]);

                Tuple<int, int, int> rowLeft = countList.FirstOrDefault(x => x.Item1.Equals(left));
                Tuple<int, int, int> rowRight = countList.FirstOrDefault(x => x.Item1.Equals(right));

                if (rowLeft != null && rowRight != null && Equals(rowLeft, rowRight))
                {
                    countList.Remove(rowLeft);
                    countList.Add(new Tuple<int, int, int>(rowLeft.Item1, rowLeft.Item2 + 1, rowLeft.Item3 + 1));
                }
                else
                {
                    if (rowLeft != null)
                    {
                        countList.Remove(rowLeft);
                        countList.Add(new Tuple<int, int, int>(rowLeft.Item1, rowLeft.Item2 + 1, rowLeft.Item3));
                    }
                    else
                    {
                        countList.Add(new Tuple<int, int, int>(left, 1, 0));
                    }

                    if (rowRight != null)
                    {
                        countList.Remove(rowRight);
                        countList.Add(new Tuple<int, int, int>(rowRight.Item1, rowRight.Item2, rowRight.Item3 + 1));
                    }
                    else
                    {
                        countList.Add(new Tuple<int, int, int>(right, 0, 1));
                    }
                }
            }

            return countList.Where(t => t.Item2 != 0).Sum(t => t.Item1 * t.Item3);
        }
        
        public static void Run(IEnumerable<string> lines)
        {
            int p1;
            int p2;
            int p2Alt;
            
            using (Benchmark _ = new Benchmark("Part One (Execution Time)"))
            {
                p1 = PartOne(lines);
            }
            
            Console.WriteLine($"Part One (Answer): {p1}");
            
            using (Benchmark _ = new Benchmark("Part Two (Execution Time)"))
            {
                p2 = PartTwo(lines);
            }
            
            Console.WriteLine($"Part Two (Answer): {p2}");
            
            using (Benchmark _ = new Benchmark("Part Two Alt (Execution Time)"))
            {
                p2Alt = PartTwo_Alt(lines);
            }

            Console.WriteLine($"Part Two Alt (Answer): {p2Alt}");
        }
    }
}