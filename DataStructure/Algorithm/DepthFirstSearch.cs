using System.Collections.Generic;
using System.Linq;
using DataStructure.Graph;

namespace DataStructure.Algorithm
{
    public sealed class DepthFirstSearch : ISearch
    {
        private readonly IGraph _graph;
        private readonly bool[] _marked;
        private int _count;

        public DepthFirstSearch(IGraph graph, int s)
        {
            _marked = new bool[graph.CountVertices()];
            _graph = graph;
            DfsIterative(s);
            //DfsRecursive(s);
        }

        private void DfsRecursive(int s){
            // Recursive version
            _marked[s] = true;
            _count++;
            foreach (var v in _graph.GetAdjacent(s).Where(v => !_marked[v]))
            {
                DfsRecursive(v);
            }
        }

        private void DfsIterative(int start)
        {
            var stack = new Stack<int>(_graph.CountVertices());
            stack.Push(start);
            _marked[start] = true;
            _count++;

            while (stack.Count > 0)
            {
                var s = stack.Pop();
                foreach (var v in _graph.GetAdjacent(s).Where(v => !_marked[v]))
                {
                    stack.Push(v);
                    _marked[v] = true;
                    _count++;
                }
            }
        }

        public bool IsMarked(int v)
        {
            return _marked[v];
        }

        public int Count()
        {
            return _count;
        }
    }
}
