using System;
using System.Linq;

namespace DataStructure.Graph
{
    public static class GraphExtensions
    {
        /// <summary>
        /// Gets the vertes degree in graph
        /// </summary>
        /// <param name="graph">The graph</param>
        /// <param name="v">The vertex</param>
        /// <returns>Degree</returns>
        /// <exception cref="System.ArgumentNullException">graph</exception>
        public static int GetDegree(this IGraph graph, int v)
        {
            if (graph == null)
                throw new ArgumentNullException("graph");

            return graph.GetAdjacent(v).Count();
        }

        /// <summary>
        /// Gets the maximum graph degree
        /// </summary>
        /// <param name="graph">The graph</param>
        /// <returns>Maximum degree</returns>
        /// <exception cref="System.ArgumentNullException">graph</exception>
        public static int GetMaxDegree(this IGraph graph)
        {
            if (graph == null)
                throw new ArgumentNullException("graph");

            int max = 0;
            for (int i = 0; i < graph.CountVertices(); i++)
            {
                int degree = graph.GetDegree(i);
                if (degree > max)
                    max = degree;
            }

            return max;
        }

        /// <summary>
        /// Gets the average graph degree
        /// </summary>
        /// <param name="graph">The graph</param>
        /// <returns>Average degree</returns>
        public static int GetAvgDegree(this IGraph graph)
        {
            if (graph == null)
                throw new ArgumentNullException("graph");

            return 2 * graph.CountEdges() / graph.CountVertices();
        }


        /// <summary>
        /// Gets the number of self loops
        /// </summary>
        /// <param name="graph">The graph</param>
        /// <returns>Number of self loops</returns>
        public static int GetNumberOfSelfLoops(this IGraph graph)
        {
            if (graph == null)
                throw new ArgumentNullException("graph");

            int count = 0;
            for (int v = 0; v < graph.CountVertices(); v++)
            {
                count += graph.GetAdjacent(v).Count(w => v == w);
            }

            return count/2;
        }
    }
}
