using System;
using DataStructure.Graph;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace UnitTest
{
    [TestClass]
    public class UndirectedGraphTest
    {
        [TestMethod]
        public void TinyGraph()
        {
            var graph = GraphLoader.LoadTiny();

            Assert.AreEqual(13, graph.CountVertices());
            Assert.AreEqual(13, graph.CountEdges());
            Assert.AreEqual(3, graph.GetDegree(5));
            Assert.AreEqual(4, graph.GetMaxDegree());
            Assert.AreEqual(2, graph.GetAvgDegree());
            Assert.AreEqual(0, graph.GetNumberOfSelfLoops());
        }

        [TestMethod]
        public void MediumGraph()
        {
            var graph = GraphLoader.LoadMedium();

            Assert.AreEqual(250, graph.CountVertices());
            Assert.AreEqual(1273, graph.CountEdges());
            Assert.AreEqual(10, graph.GetDegree(5));
            Assert.AreEqual(21, graph.GetMaxDegree());
            Assert.AreEqual(10, graph.GetAvgDegree());
            Assert.AreEqual(0, graph.GetNumberOfSelfLoops());
        }

        [TestMethod]
        public void SelfLoops()
        {
            var graph = new UndirectedGraph(2);
            graph.AddEdge(0, 0);
            graph.AddEdge(1, 1);
            graph.AddEdge(0, 1);

            Assert.AreEqual(2, graph.CountVertices());
            Assert.AreEqual(3, graph.CountEdges());
            Assert.AreEqual(3, graph.GetMaxDegree());
            Assert.AreEqual(2, graph.GetNumberOfSelfLoops());
        }

    }
}
