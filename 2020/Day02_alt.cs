﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode._2020
{
    class Day02_alt
    {

        public static void Run(string[] lines)
        {
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
