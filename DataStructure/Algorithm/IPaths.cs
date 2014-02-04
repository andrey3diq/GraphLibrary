using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Algorithm
{
    /// <summary>
    /// Find paths
    /// </summary>
    interface IPaths
    {
        /// <summary>
        /// Determines whether source vertex has path to the specified v
        /// </summary>
        /// <param name="v">Vertex v</param>
        /// <returns></returns>
        bool HasPathTo(int v);
        /// <summary>
        /// Path from source vertex to v
        /// </summary>
        /// <param name="v">Vertex v</param>
        /// <returns></returns>
        IEnumerable<int> PathTo(int v);
    }
}
