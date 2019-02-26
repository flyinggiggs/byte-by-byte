using System;
using System.Collections.Generic;
using System.Linq;

namespace byte_by_byte
{
    public class Q16
    {
        public static void StartQ16()
        {
            var node1 = new Node<int>(1);
            var node3 = new Node<int>(3);
            var node2 = new Node<int>(2);
            var node4 = new Node<int>(4);
            var node5 = new Node<int>(5);

            node1.Children.Add(node2);
            node1.Children.Add(node3);
            node2.Children.Add(node5);
            node5.Children.Add(node4);
            node4.Children.Add(node1);
            node4.Children.Add(node3);

            Console.Write("Result: "+ string.Join(",", FindShortestPath(node1, 3).Select(s => s.value)));

        }

        public static List<Node<int>> FindShortestPath(Node<int> startNode, int destination)
        {
            var result = new List<Node<int>>();
            var bfsQueue = new Queue<Node<int>>();
            var parentsMap = new Dictionary<int, Node<int>>();
            Node<int> lastNode = null;

            parentsMap[startNode.value] = null;
            bfsQueue.Enqueue(startNode);

            while (bfsQueue.Count != 0)
            {
                var currentNode = bfsQueue.Dequeue();

                if (currentNode.value == destination)
                {
                    lastNode = currentNode;
                    break;
                }

                foreach (var childNode in currentNode.Children)
                {
                    if (!parentsMap.ContainsKey(childNode.value))
                    {
                        parentsMap[childNode.value] = currentNode;
                        bfsQueue.Enqueue(childNode);
                    }
                }
            }

            if (lastNode == null)
                return result;

            result.Add(lastNode);

            while (lastNode != null )
            {
                if (parentsMap[lastNode.value] == null)
                    break;

                result.Add(parentsMap[lastNode.value]);
                lastNode = parentsMap[lastNode.value];
            }

            return result;
        }
    }


}
