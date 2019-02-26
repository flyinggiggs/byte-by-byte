using System;
using System.Collections.Generic;
using System.Linq;

namespace byte_by_byte
{
    class Program
    {
        static void Main(string[] args)
        {
            PracticeDFS();
            Q15();
            Q16.StartQ16();
            Console.ReadLine();
        }

        static void PracticeDFS()
        {
            DFS.StartDFS();
        }

        static void Q15()
        {
            var input = new int[][]
            {
            new int[] { },
            new int[] { 0 },
            new int[] { 0 },
            new int[] { 1, 2 },
            new int[] { 3 },
            };

            var result = BuildOrder(input);
            Console.Write("Order: " + String.Join(",", result));

        }



        static List<int> BuildOrder(int[][] input)
        {
            var tempMarks = new HashSet<int>();
            var permMarks = new HashSet<int>();
            var result = new List<int>();

            for (int i = 0; i < input.GetLength(0); i++)
            {
                Visit(i, input, tempMarks, permMarks, result);
            }

            return result;
        }

        private static void Visit(int node, int[][] input, HashSet<int> tempMarks, HashSet<int> permMarks, List<int> result)
        {
            if (tempMarks.Contains(node))
                throw new Exception("Found a cycle.");

            if (!permMarks.Contains(node))
            {
                tempMarks.Add(node);

                foreach (int i in input[node])
                {
                    Visit(i, input, tempMarks, permMarks, result);
                }

                tempMarks.Remove(node);
                permMarks.Add(node);
                result.Add(node);
            }

        }
    }
}
