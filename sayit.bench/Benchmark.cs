using BenchmarkDotNet.Attributes;
using LookAndSee.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace sayit.bench
{
    [MemoryDiagnoser]
    public class Benchmark
    {
        [Benchmark(Baseline = true)]
        public void SayWithStrings()
        {
            LookAndSay.Say(1, 30);
        }

        [Benchmark]
        public void SayWithSpan()
        {
            LookAndSaySpan.Say(1, 30);
        }

        [Benchmark]
        public void Bryans()
        {
            var generator = new Generator();
            // Act
            var result = generator.Next(30);
            // Assert
        }
    }
}
