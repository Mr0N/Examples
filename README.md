BenchmarkDotNet=v0.13.1, OS=Windows 10.0.18363.1556 (1909/November2019Update/19H2)
AMD Athlon(tm) X4 855 Quad Core Processor, 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.7.21379.14
  [Host]   : .NET 6.0.0 (6.0.21.37719), X64 RyuJIT  [AttachedDebugger]
  .NET 6.0 : .NET 6.0.0 (6.0.21.37719), X64 RyuJIT

Job=.NET 6.0  Runtime=.NET 6.0  InvocationCount=1
UnrollFactor=1

|   Method |    Mean |    Error |   StdDev |
|--------- |--------:|---------:|---------:|
| TaskLinq | 1.507 s | 0.0299 s | 0.0643 s |
| Paraller | 3.097 s | 0.0604 s | 0.0719 s |

// * Warnings *
Environment
  Summary -> Benchmark was executed with attached debugger
