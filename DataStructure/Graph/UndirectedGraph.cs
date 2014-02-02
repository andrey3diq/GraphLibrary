using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DataStructure.Collection;

namespace DataStructure.Graph
{
    public class UndirectedGraph : IGraph
    {
        private readonly int _verticesNumber;
        private int _edgesNumber;
        readonly Bag<int>[] _adjacencies;

        /// <summary>
        /// Creates a graph with verticesNumber vertices. Without edges
        /// </summary>
        /// <param name="verticesNumber">number of vertices</param>
        public UndirectedGraph(int verticesNumber)
        {
            if (verticesNumber < 0)
                throw new ArgumentOutOfRangeException("verticesNumber", verticesNumber, "cannot be negative");

            _verticesNumber = verticesNumber;
            _edgesNumber = 0;
            _adjacencies = new Bag<int>[verticesNumber];
            for (var i = 0; i < _adjacencies.Length; i++)
            {
                _adjacencies[i] = new Bag<int>();
            }
        }

        /// <summary>
        /// Creates a graph from stream
        /// </summary>
        /// <param name="stream">Stream to read graph data from</param>
        public UndirectedGraph(StreamReader stream)
            : this(Int32.Parse(stream.ReadLine()))
        {
            var edgesNumber = Int32.Parse(stream.ReadLine());
            if (edgesNumber < 0)
                throw new ArgumentOutOfRangeException("edgesNumber", _verticesNumber, "cannot be negative");

            for (var i = 0; i < edgesNumber; i++)
            {
                var edge = stream.ReadLine().Split(new[] { ' ', '\t' });
                if (edge.Length < 2)
                    throw new InvalidDataException("missing vertex");
                var v = Int32.Parse(edge[0]);
                var w = Int32.Parse(edge[1]);
                AddEdge(v, w);
            }
        }

        /// <summary>
        /// Returns the number of vertices
        /// </summary>
        /// <returns>
        /// Number of vertices
        /// </returns>
        public int CountVertices()
        {
            return _verticesNumber;
        }

        /// <summary>
        /// Returns the number of edges
        /// </summary>
        /// <returns>
        /// Number of edges
        /// </returns>
        public int CountEdges()
        {
            return _edgesNumber;
        }

        /// <summary>
        /// Adds edge v-w
        /// </summary>
        /// <param name="v">vertex v</param>
        /// <param name="w">vertex w</param>
        public void AddEdge(int v, int w)
        {
            if (v < 0 || v > _verticesNumber)
                throw new IndexOutOfRangeException();
            if (w < 0 || w > _verticesNumber)
                throw new IndexOutOfRangeException();

            _edgesNumber++;
            _adjacencies[v].Add(w);
            _adjacencies[w].Add(v);
        }

        /// <summary>
        /// Returns vertices adjacent to v
        /// </summary>
        /// <param name="v">Vertex v</param>
        /// <returns>
        /// Vertices adjacent to v
        /// </returns>
        public IEnumerable<int> GetAdjacent(int v)
        {
            if (v < 0 || v > _verticesNumber)
                throw new IndexOutOfRangeException();

            return _adjacencies[v];
        }

        public override string ToString()
        {
            var str = new StringBuilder();
            str.AppendFormat("{0} vertices, {1} edges:", _verticesNumber, _edgesNumber).AppendLine();
            for (var v = 0; v < _verticesNumber; v++)
            {
                str.AppendFormat("{0}: ", v);
                foreach (var w in _adjacencies[v])
                {
                    str.AppendFormat("{0} ", w);
                }
                str.AppendLine();
            }

            return str.ToString();
        }
    }
}
