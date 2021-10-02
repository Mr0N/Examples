using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyApplication
{
    [SimpleJob(RuntimeMoniker.Net60)]
    [RPlotExporter]
    public class Check
    { 
        public static void Run()
        {
            BenchmarkSwitcher.FromAssembly(typeof(Check).Assembly).Run();
        }
       
        public void Setup()
        {

        }
        [Benchmark]
        public void TaskLinq()
        {
            int[] array = Enumerable.Range(0, 50000000).ToArray();
            var result = array.Chunk(array.Length / 3).Select(a => Task.Run(() => a.Select(a => a * 2)));
            Task.WaitAll(result.ToArray());
            var save = result.SelectMany(a => a.Result).ToArray();
        }
        [Benchmark]
        public void Paraller()
        {
            int[] array = Enumerable.Range(0, 50000000).ToArray();
            int[] dublicate = new int[array.Length];
            var options = new ParallelOptions() { MaxDegreeOfParallelism = 3 };
            int index = 0;
            Parallel.ForEach(array, options, (a, x) =>
            {
                dublicate[index++] = a * 2;
            });
        }
    }
}
