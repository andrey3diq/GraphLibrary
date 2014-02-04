using System;
using System.IO;
using System.Threading;
using BenchmarkDotNet;
using DataStructure.Algorithm;
using DataStructure.Graph;

namespace GraphClient
{
    class Program
    {
        static void Main(string[] args)
        {
            IGraph graph;
            const string graphFile = "tinyCG.txt";

            using (var stream = new StreamReader(graphFile))
            {
                graph = new UndirectedGraph(stream);
            }

            //Console.WriteLine(graph);
            Console.WriteLine("Degree for 5: " + graph.GetDegree(5));
            Console.WriteLine("Max degree: " + graph.GetMaxDegree());
            Console.WriteLine("Avg degree: " + graph.GetAvgDegree());
            Console.WriteLine("Self loops: " + graph.GetNumberOfSelfLoops());

            var search = new DepthFirstSearch(graph, 0);
            for (var v = 0; v < graph.CountVertices(); v++)
            {
                if (search.IsMarked(v))
                {
                    Console.Write(v + " ");
                }
            }
            Console.WriteLine();

            if (search.Count() != graph.CountVertices())
            {
                Console.Write("not ");
            }
            Console.WriteLine("connected");

            //var benchmark = new Benchmark().Run(
            //    () => search = new DepthFirstSearch(graph, 9)
            //    );

            //Console.WriteLine("Time elapsed: " + benchmark.Result.MedianMilliseconds + "ms");
            const int stackSize = 100 * 1024 * 1024;
            var thread = new Thread(BigRecursion, stackSize);
            thread.Start();
            
        }

        private static void BigRecursion()
        {
            IGraph graph;
            const string graphFile = "largeG.txt";

            using (var stream = new StreamReader(graphFile))
            {
                graph = new UndirectedGraph(stream);
            }

            ISearch search;
            var benchmark = new Benchmark().Run(
                () => search = new DepthFirstSearch(graph, 9)
                );

            Console.WriteLine("Time elapsed: " + benchmark.Result.MedianMilliseconds + "ms");


        }
    }
}
