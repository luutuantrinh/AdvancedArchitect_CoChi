using System;
using System.Diagnostics;

namespace AdvancedArchitect_CoChi.Performance
{
    public class PerformanceTest
    {
        const int maxSize = (int)(1e5 + 7); // 100000 + 7
        public static void MeasurePerformance()
        {
            // Test hiệu năng thông thường (non-parallel)

            //for (int size = 1000; size <= maxSize; size += 1000)
            //{
            //    var graph = new Graph(size);
            //    for (int i = 1; i < size; i++)
            //    {
            //        graph.AddEdge(i, i + 1);
            //    }

            //    var stopwatch = Stopwatch.StartNew();

            //    graph.CountConnectedComponents();

            //    stopwatch.Stop();

            //    Console.WriteLine($"Size: {size}, Execution Time: {stopwatch.ElapsedMilliseconds} ms");
            //}

            //Parallel Execution
            Parallel.For(1000, maxSize + 1, size =>
            {
                if (size % 1000 == 0)
                {
                    var graph = new Graph(size);
                    for (int i = 1; i < size; i++)
                    {
                        graph.AddEdge(i, i + 1);
                    }

                    var stopwatch = Stopwatch.StartNew();

                    graph.CountConnectedComponents();

                    stopwatch.Stop();

                    Console.WriteLine($"Size: {size}, Execution Time: {stopwatch.ElapsedMilliseconds} ms");
                }
            });

        }

    }
}
