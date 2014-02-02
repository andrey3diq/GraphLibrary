using System.Collections.Generic;

namespace DataStructure.Graph
{
    /// <summary>
    /// A graph
    /// </summary>
    public interface IGraph
    {
        /// <summary>
        /// Returns the number of vertices
        /// </summary>
        /// <returns>Number of vertices</returns>
        int CountVertices();
        /// <summary>
        /// Returns the number of edges
        /// </summary>
        /// <returns>Number of edges</returns>
        int CountEdges();
        /// <summary>
        /// Adds edge v-w
        /// </summary>
        /// <param name="v">vertex v</param>
        /// <param name="w">vertex w</param>
        void AddEdge(int v, int w);
        /// <summary>
        /// Returns vertices adjacent to v
        /// </summary>
        /// <param name="v">Vertex v</param>
        /// <returns>Vertices adjacent to v</returns>
        IEnumerable<int> GetAdjacent(int v);
    }
}
