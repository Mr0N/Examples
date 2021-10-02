// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

int[] array = Enumerable.Range(0, 50000000).ToArray();
Stopwatch stopwatch = new Stopwatch();
stopwatch.Start();
int[] dublicate = new int[array.Length];
var options = new ParallelOptions() { MaxDegreeOfParallelism = 3 };
int index = 0;
Parallel.ForEach(array,options, (a,x) =>
{
    dublicate[index++] = a * 2;
});
stopwatch.Stop();
Console.WriteLine("One:{0}", stopwatch.ElapsedMilliseconds);
stopwatch.Reset();
stopwatch.Start();
var result = array.Chunk(array.Length / 3).Select(a => Task.Run(() => a.Select(a => a * 2)));
Task.WaitAll(result.ToArray());
var save = result.SelectMany(a => a.Result).ToArray();
stopwatch.Stop();
Console.WriteLine("Two:{0}",stopwatch.ElapsedMilliseconds);
Console.ReadKey();
