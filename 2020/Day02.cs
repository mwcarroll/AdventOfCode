using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    class Password
    {
        public string full;
        public string password;
        public Tuple<int, int> rangeOrPosition;
        public char charToFind;

        public Password(string line, Regex regex)
        {
            MatchCollection matches = regex.Matches(line);

            foreach (Match match in matches)
            {
                if (match.Success)
                {
                    full = match.Groups[0].Value;
                    password = match.Groups[4].Value;
                    rangeOrPosition = new Tuple<int, int>(int.Parse(match.Groups[1].Value), int.Parse(match.Groups[2].Value));
                    charToFind = match.Groups[3].Value.ToCharArray()[0];
                }
            }
        }

        public bool IsValidA()
        {
            string test = Regex.Replace(password, "[^" + charToFind + "]", "");

            return test.Length >= rangeOrPosition.Item1 && test.Length <= rangeOrPosition.Item2;
        }

        public bool IsValidB()
        {
            char[] pwdArr = password.ToCharArray();

            return pwdArr[rangeOrPosition.Item1 - 1] == charToFind ^ pwdArr[rangeOrPosition.Item2 - 1] == charToFind;
        }
    }
    class Day02
    {

        public static void Run(string[] args)
        {
            string[] lines = File.ReadAllLines(@"data\day02.txt");
            Regex regex = new Regex(@"([0-9]*)-([0-9]*) (.): (.*)");

            Console.WriteLine("Day 2:");
            Console.WriteLine("\tPart A: {0}", lines.Where(x => new Password(x, regex).IsValidA()).Count());
            Console.WriteLine("\tPart B: {0}", lines.Where(x => new Password(x, regex).IsValidB()).Count());
        }
    }
}
