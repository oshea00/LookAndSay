using BenchmarkDotNet.Attributes;
using LookAndSee.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Katas;

namespace sayit.bench
{
    [MemoryDiagnoser]
    public class Benchmark
    {
        //[Benchmark(Baseline = true)]
        //public void SayWithStrings()
        //{
        //    LookAndSay.Say(1, 30);
        //}

        [Benchmark(Baseline = true)]
        public void SayWithSpan()
        {
            LookAndSaySpan.Say(1, 60);
        }

        [Benchmark]
        public void Bryans()
        {
            var generator = new Generator();
            // Act
            var result = generator.Next(60);
            // Assert
        }

        [Benchmark]
        public void ChrisFS()
        {
            var g = new Katas.LookAndSayGenerator();
            g.GenerateLookAndSay("1", 60);
        }
    }
}
