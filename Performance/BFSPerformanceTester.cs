using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedArchitect_CoChi.Performance
{
    public class BFSPerformanceTester
    {
        private const int maxSize = (int)(1e5 + 7); // 100000 + 7

        public static void TestBFSWithBoolArray()
        {
            Console.WriteLine("Testing BFS with bool[] visited:");

            Parallel.For(1000, maxSize + 1, size =>
            {
                if (size % 1000 == 0)
                {
                    Graph g = new Graph(size);
                    for (int i = 1; i < size; i++)
                    {
                        g.AddEdge(i, i + 1);
                    }

                    bool[] visited = new bool[size];
                    var stopwatch = Stopwatch.StartNew();

                    g.BFS(0, visited);

                    stopwatch.Stop();

                    Console.WriteLine($"Size: {size}, Execution Time: {stopwatch.ElapsedMilliseconds} ms");
                }
            });
        }

        public static void TestBFSWithHashSet()
        {
            Console.WriteLine("Testing BFS with HashSet<int> visited:");

            Parallel.For(1000, maxSize + 1, size =>
            {
                if (size % 1000 == 0)
                {
                    ConnectedComponentGraph g = new ConnectedComponentGraph(size);
                    for (int i = 1; i < size; i++)
                    {
                        g.AddEdge(i, i + 1);
                    }

                    HashSet<int> visited = new HashSet<int>();
                    var stopwatch = Stopwatch.StartNew();

                    g.BFS(0, visited);

                    stopwatch.Stop();

                    Console.WriteLine($"Size: {size}, Execution Time: {stopwatch.ElapsedMilliseconds} ms");
                }
            });
        }

        public static void CompareBFSPerformance()
        {
            Console.WriteLine("\nComparing BFS performance:");

            Stopwatch stopwatch = new Stopwatch();

            // Test BFS with bool[] visited
            stopwatch.Start();
            TestBFSWithBoolArray();
            stopwatch.Stop();
            long boolArrayTime = stopwatch.ElapsedMilliseconds;

            // Test BFS with HashSet<int> visited
            stopwatch.Restart();
            TestBFSWithHashSet();
            stopwatch.Stop();
            long hashSetTime = stopwatch.ElapsedMilliseconds;

            // Compare performance
            if (boolArrayTime < hashSetTime)
            {
                Console.WriteLine("BFS with bool[] visited is faster.");
            }
            else if (boolArrayTime > hashSetTime)
            {
                Console.WriteLine("BFS with HashSet<int> visited is faster.");
            }
            else
            {
                Console.WriteLine("Both BFS implementations have similar performance.");
            }
        }

    }
}
