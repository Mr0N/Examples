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
        [IterationSetup]
        public void Setup()
        {
             array = Enumerable.Range(0, 50000000).ToArray();
            result = array.Chunk(array.Length / 3).Select(a => Task.Run(() => a.Select(a => a * 2)));
             dublicate = new int[array.Length];
             options = new ParallelOptions() { MaxDegreeOfParallelism = 3 };
            index = 0;
        }
        int[] array;
        IEnumerable<Task<IEnumerable<int>>> result;
        ParallelOptions options;
        [Benchmark]
        public void TaskLinq()
        {
            Task.WaitAll(result.ToArray());
            var save = result.SelectMany(a => a.Result).ToArray();
        }
        int[] dublicate;
        int index;
        [Benchmark]
        public void Paraller()
        {
            Parallel.ForEach(array, options, (a, x) =>
            {
                dublicate[index++] = a * 2;
            });
        }
    }
}
