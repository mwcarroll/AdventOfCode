using System;
using System.Diagnostics;

namespace AdventOfCode
{
    public class Benchmark : IDisposable 
    {
        private readonly Stopwatch _timer = new Stopwatch();
        private readonly string _benchmarkName;

        public Benchmark(string benchmarkName)
        {
            this._benchmarkName = benchmarkName;
            _timer.Start();
        }

        public void Dispose() 
        {
            _timer.Stop();
            Console.WriteLine($"{_benchmarkName} {_timer.Elapsed}");
        }
    }
}