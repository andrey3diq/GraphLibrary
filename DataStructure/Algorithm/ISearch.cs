namespace DataStructure.Algorithm
{
    /// <summary>
    /// Search connected vertices
    /// </summary>
    public interface ISearch
    {
        /// <summary>
        /// Determines whether the specified vertex is marked
        /// </summary>
        /// <param name="v">Vertex v</param>
        /// <returns></returns>
        bool IsMarked(int v);

        /// <summary>
        /// Counts marked vertices
        /// </summary>
        /// <returns></returns>
        int Count();
    }
}
