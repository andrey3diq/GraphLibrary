using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructure.Graph;

namespace UnitTest
{
    static class GraphLoader
    {
        public static IGraph LoadTiny()
        {
            using (var stream = new StreamReader("tinyG.txt"))
            {
                return new UndirectedGraph(stream);
            }
        }

        public static IGraph LoadMedium()
        {
            using (var stream = new StreamReader("mediumG.txt"))
            {
                return new UndirectedGraph(stream);
            }
        }
        public static IGraph LoadLarge()
        {
            using (var stream = new StreamReader("largeG.txt"))
            {
                return new UndirectedGraph(stream);
            }
        }
    }
}
