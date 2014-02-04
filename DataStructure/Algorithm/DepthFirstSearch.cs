using System.Collections.Generic;
using System.Linq;
using DataStructure.Graph;

namespace DataStructure.Algorithm
{
    /// <summary>
    /// Implements Depth First Search algorithm
    /// Marks all vertices connected with source vertex
    /// </summary>
    public sealed class DepthFirstSearch : ISearch
    {
        private readonly IGraph _graph;
        private readonly bool[] _marked;
        private int _count;

        /// <summary>
        /// Initializes a new instance of the <see cref="DepthFirstSearch"/> class
        /// Searchs all connected with s vertices and marks them
        /// </summary>
        /// <param name="graph">The graph</param>
        /// <param name="s">The source vertex</param>
        public DepthFirstSearch(IGraph graph, int s)
        {
            _marked = new bool[graph.CountVertices()];
            _graph = graph;
            DfsIterative(s);
        }

        /// <summary>
        /// Recursive version - slow but simple
        /// </summary>
        /// <param name="s"></param>
        private void DfsRecursive(int s)
        {
            _marked[s] = true;
            _count++;
            foreach (var v in _graph.GetAdjacent(s).Where(v => !_marked[v]))
            {
                DfsRecursive(v);
            }
        }

        /// <summary>
        /// Iterative DFS - much faster than recursive
        /// Doesn't require large Thread stack size
        /// </summary>
        /// <param name="start"></param>
        private void DfsIterative(int start)
        {
            var stack = new Stack<int>(_graph.CountVertices());
            Mark(stack, start);

            while (stack.Count > 0)
            {
                var s = stack.Pop();
                foreach (var v in _graph.GetAdjacent(s).Where(v => !_marked[v]))
                {
                    Mark(stack, v);
                }
            }
        }

        private void Mark(Stack<int> stack, int vertex)
        {
            stack.Push(vertex);
            _marked[vertex] = true;
            _count++;
        }


        /// <summary>
        /// Iterative DFS - slower version
        /// </summary>
        /// <param name="start"></param>
        private void DfsIterativeSlow(int start)
        {
            var stack = new Stack<int>(_graph.CountVertices());
            stack.Push(start);

            while (stack.Count > 0)
            {
                var s = stack.Pop();
                if (_marked[s]) continue;

                _marked[s] = true;
                _count++;
                foreach (var v in _graph.GetAdjacent(s))
                {
                    stack.Push(v);
                }
            }
        }

        /// <summary>
        /// Determines whether the specified vertex is marked
        /// </summary>
        /// <param name="v">Vertex v</param>
        /// <returns></returns>
        public bool IsMarked(int v)
        {
            return _marked[v];
        }

        /// <summary>
        /// Counts marked vertices
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return _count;
        }
    }
}
