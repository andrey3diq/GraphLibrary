using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet;
using DataStructure.Algorithm;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Algorithm
{
    [TestClass]
    public class SearchConnectedVerticesTest
    {
        [TestMethod]
        public void DepthFisrtSearchInTinyGraph()
        {
            var graph = GraphLoader.LoadTiny();

            var search = new DepthFirstSearch(graph, 0);
            Assert.AreEqual(7, search.Count());
            Assert.AreEqual(false, search.IsMarked(9));
            Assert.AreEqual(true, search.IsMarked(0));
            Assert.AreEqual(true, search.IsMarked(6));
        }

        [TestMethod]
        public void DepthFisrtSearchInMediumGraph()
        {
            var graph = GraphLoader.LoadMedium();

            var search = new DepthFirstSearch(graph, 0);
            Assert.AreEqual(250, search.Count());
            for (int i = 0; i < graph.CountVertices(); i++)
            {
                Assert.AreEqual(true, search.IsMarked(i));
            }
        }

        [TestMethod]
        public void DFSBenchmarkMediumTest()
        {
            var graph = GraphLoader.LoadMedium();

            var benchmark = new Benchmark().Run(
                () => new DepthFirstSearch(graph, 0)
                );

            Assert.IsTrue(benchmark.Result.MedianMilliseconds < 1);
        }

        [TestMethod]
        public void DFSBenchmarkLargeTest()
        {
            var graph = GraphLoader.LoadLarge();

            var benchmark = new Benchmark().Run(
                () => new DepthFirstSearch(graph, 0)
                );

            Assert.IsTrue(benchmark.Result.MedianMilliseconds < 700);
        }
    }
}
