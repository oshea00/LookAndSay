using BenchmarkDotNet.Running;
using System;

namespace sayit.bench
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Benchmark>();
        }
    }
}
