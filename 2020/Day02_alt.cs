using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode_Alternate
{
    class Day02_alt
    {

        public static void Run(string[] args)
        {
            string[] lines = File.ReadAllLines(@"data\day02.txt");

            IEnumerable<string[]> passwords = lines.ToList().Select(x =>
            {
                return Regex.Split(x.Trim(), @" |-|: ");
            });

            Console.WriteLine("Day 2:");
            Console.WriteLine("\tPart A: {0}", passwords.Where(x => x[3].Count(y => y == x[2].ToCharArray()[0]) >= int.Parse(x[0]) && x[3].Count(y => y == x[2].ToCharArray()[0]) <= int.Parse(x[1])).Count());
            Console.WriteLine("\tPart B: {0}", passwords.Where(x => x[3][int.Parse(x[0]) - 1] == x[2].ToCharArray()[0] ^ x[3][int.Parse(x[1]) - 1] == x[2].ToCharArray()[0]).Count());
        }
    }
}
