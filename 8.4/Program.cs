using System;
using System.IO;

namespace TRSPK8._4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] graph;
            int[,] knownPairs;
            int n, m;
            using (StreamReader sr = new StreamReader("INPUT.TXT"))
            {
                int high, low;
                string[] input = sr.ReadLine().Split();
                n = int.Parse(input[0]);
                m = int.Parse(input[1]);
                graph = new int[n, n];
                knownPairs = new int[2, m];
                for (int i = 0; i < m; i++)
                {
                    input = sr.ReadLine().Split();
                    high = int.Parse(input[0]);
                    low = int.Parse(input[1]);
                    graph[high - 1, low - 1] = 1;
                    knownPairs[0, i] = high - 1;
                    knownPairs[1, i] = low - 1;
                }
            }

            using (StreamWriter sw = new StreamWriter("OUTPUT.TXT"))
            {
                for (int i = 0; i < knownPairs.GetLength(1); i++)
                {
                    if (graph[knownPairs[0, i], knownPairs[1, i]] == 1)
                        if (IsCyclic(ref graph, knownPairs[0, i], knownPairs[1, i]))
                        {
                            sw.WriteLine("No");
                            return;
                        }
                }
                sw.WriteLine("Yes");
            }
            return;
        }
        static bool IsCyclic(ref int[,] graph, int high, int low)
        {
            graph[high, low]++;
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                if (graph[low, i] == 2)
                    return true;
                if (graph[low, i] == 1)
                    if (IsCyclic(ref graph, low, i))
                        return true;
            }
            graph[high, low]++;
            return false;
        }
    }
}
