using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    class Day04
    { 
        public static void Run(string[] lines)
        {
            List<string> passports = string.Join("\n", lines).Split("\n\n").ToList();

            Regex reBirthYear = new Regex(@"byr:(19[2-9][0-9]|200[0-2])");
            Regex reIssueYear = new Regex(@"iyr:(201[0-9]|2020)");
            Regex reExpireYear = new Regex(@"eyr:(202[0-9]|2030)");
            Regex reHeight = new Regex(@"hgt:((1[5-8][0-9]|19[0-3])cm|((59|6[0-9]|7[0-6]))in)");
            Regex reHairColor = new Regex(@"hcl:#([0-9a-f]{6})\b");
            Regex reEyeColor = new Regex(@"ecl:(amb|blu|brn|gry|grn|hzl|oth)");
            Regex rePassportID = new Regex(@"pid:([0-9]{9})\b");

            Console.WriteLine("Day 4:");
            Console.WriteLine("\tPart A: {0}", passports.Count(x => new[] { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" }.All(x.Contains)));
            Console.WriteLine("\tPart B: {0}", passports.Count(x =>
                    reBirthYear.IsMatch(x) &&
                    reIssueYear.IsMatch(x) &&
                    reExpireYear.IsMatch(x) &&
                    reHeight.IsMatch(x) &&
                    reHairColor.IsMatch(x) &&
                    reEyeColor.IsMatch(x) &&
                    rePassportID.IsMatch(x)
               ));
        }
    }
}
