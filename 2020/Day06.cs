using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    class Day06
    {
        public static void Run(string[] lines)
        {
            List<string> forms = string.Join("\n", lines).Split("\n\n").ToList();

            Console.WriteLine("Day 6:");
            Console.WriteLine("\tPart A: {0}", forms.Select(x => x.Replace("\n", "").ToCharArray().Distinct().Count()).Sum());
            Console.WriteLine("\tPart B: {0}", forms.Select(x => x.Split("\n").Select(l => l.ToCharArray().Distinct())).Select(g => g.Aggregate((prev, next) => prev.Intersect(next).ToList()).Count()).Sum());
        }
    }
}
