using System.IO;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines(@"data\day03.txt");

            Day03.Run(args);
        }
    }
}
