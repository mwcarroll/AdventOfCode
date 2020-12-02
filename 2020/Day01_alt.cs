using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    class Day01
    {

        public static IEnumerable<Tuple<int, int>> PairProduct(int[] input)
        {
            foreach(var i in input)
            {
                foreach(var j in input)
                {
                    yield return Tuple.Create(i, j);
                }
            }
        }

        public static IEnumerable<Tuple<int, int, int>> TrioProduct(int[] input)
        {
            foreach(var i in PairProduct(input))
            {
                foreach (var j in input)
                {
                    yield return Tuple.Create(i.Item1, i.Item2, j);
                }
            }
        }

        static void Main(string[] args)
        {
            int[] lines = Array.ConvertAll(File.ReadAllLines(@"input.txt"), int.Parse);

            IEnumerable<Tuple<int, int>> pair = PairProduct(lines);
            IEnumerable<Tuple<int, int, int>> trio = TrioProduct(lines);

            var pairAnswer = pair.Where(x => x.Item1 + x.Item2 == 2020).FirstOrDefault();
            var trioAnswer = trio.Where(x => x.Item1 + x.Item2 + x.Item3 == 2020).FirstOrDefault();

            Console.WriteLine("Part A: {0}", pairAnswer.Item1 * pairAnswer.Item2);
            Console.WriteLine("Part B: {0}", trioAnswer.Item1 * trioAnswer.Item2 * trioAnswer.Item3);
            Console.ReadLine();
        }
    }
}
