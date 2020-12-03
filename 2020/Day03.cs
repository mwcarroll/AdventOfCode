using System;
using System.Linq;
using System.Drawing;

namespace AdventOfCode
{
    class Day03
    {
        private static int TreeCount(char tree, string[] lines, Point slope)
        {
            int maxLength = lines.OrderByDescending(s => s.Length).First().Length;
            int output = 0;

            int itX = slope.X;
            int itY = slope.Y;

            while(itY < lines.Length)
            {
                if (lines[itY][itX] == tree) output++;

                itX = (itX + slope.X) % maxLength;
                itY += slope.Y;
            }

            return output;
        }

        private static double TreeCountProduct(char tree, string[] lines, Point[] points)
        {
            return points.Select(x => TreeCount(tree, lines, x)).Aggregate(1.0, (a, b) => a *b);
        }

        public static void Run(string[] lines)
        {
            Console.WriteLine("Day 3:");
            Console.WriteLine("\tPart A: {0}", TreeCount('#', lines, new Point(3, 1)));
            Console.WriteLine("\tPart B: {0}", TreeCountProduct('#', lines, new Point[] {
                    new Point(1, 1),
                    new Point(3, 1),
                    new Point(5, 1),
                    new Point(7, 1),
                    new Point(1, 2)
                }));
        }
    }
}
