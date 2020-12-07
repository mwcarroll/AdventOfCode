using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    class Bag
    {
        public string Name;
        public List<(string Name, int Quantity)> Items;

        public Bag()
        {
            this.Items = new List<(string Name, int Quantity)>();
        }
    }
    class Day07
    {
        private static Bag Parse(string line)
        {
            string[] words = line.Split(" ");

            Bag bag = new Bag() { Name = "{words[0]} {words[1]}" };

            if (words.Length > 7)
            {
                for (int j = 4; j < words.Length; j += 4)
                {
                    var count = int.Parse(words[j]);
                    bag.Items.Add(($"{words[j + 1]} {words[j + 2]}", count));
                }
            }

            return bag;
        }

        private static bool Has(string start, string key, Dictionary<string, Bag> bags)
        {
            var bag = bags[start];

            foreach ((string Name, _) in bag.Items)
            {
                if (Name == key)
                    return true;

                if (Has(Name, key, bags))
                    return true;
            }

            return false;
        }

        private static int CountBags(string start, Dictionary<string, Bag> bags)
        {
            Bag bag = bags[start];

            return 1 + bag.Items.Select(b => b.Quantity * CountBags(b.Name, bags)).Sum();
        }

        public static void Run(string[] lines)
        {
            Dictionary<string, Bag> bags = lines.ToList().Select(a => Parse(a)).GroupBy(b => b.Name, b => b).ToDictionary(c => c.Key, c => c.ElementAt(0));

            Console.WriteLine("Day 7:");
            Console.WriteLine("\tPart A: {0}", bags.Select(a => a.Key).Where(b => Has(b, "shiny gold", bags)).Count());
            Console.WriteLine("\tPart B: {0}", (CountBags("shiny gold", bags) - 1));
        }
    }
}
