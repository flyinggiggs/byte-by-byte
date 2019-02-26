using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace byte_by_byte
{
    public class Node<T>
    {
        public T value;
        public List<Node<T>> Children = new List<Node<T>>();

        public Node(T value)
        {
            this.value = value;
        }

    }
    public class DFS
    {
        public static void StartDFS()
        {
            var node5 = new Node<int>(5);
            var node3 = new Node<int>(3);
            var node7 = new Node<int>(7);
            var node8 = new Node<int>(8);
            var node2 = new Node<int>(2);
            var node1 = new Node<int>(1);
            var node4 = new Node<int>(4);

            node5.Children.Add(node3);
            node5.Children.Add(node7);
            node5.Children.Add(node8);
            node7.Children.Add(node4);
            node3.Children.Add(node2);
            node2.Children.Add(node1);

            Console.WriteLine("Result: " + StartDFS<int>(node5, 1));
            Console.WriteLine("Build order: " + String.Join(",", TopologicalSort<int>(node5, 1).Select(n => n.value)));

        }

        public static bool StartDFS<T>(Node<T> startNode, T target)
        {
            var dfsStack = new Stack<Node<T>>();
            dfsStack.Push(startNode);
            var visitedMap = new HashSet<T>();
            visitedMap.Add(startNode.value);

            while(dfsStack.Count != 0)
            {
                var currentNode = dfsStack.Pop();

                if (currentNode.value.Equals(target))
                    return true;

                // If any child exists of the current node, enqueue them
                foreach(var child in currentNode.Children)
                {
                    if(!visitedMap.Contains(child.value))
                        dfsStack.Push(child);
                }
            }

            return false;
        }

        /// <summary>
        /// Note: This does not work now. Need to fix it.
        /// </summary>
        /// <returns>The sort.</returns>
        /// <param name="startNode">Start node.</param>
        /// <param name="target">Target.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static List<Node<T>> TopologicalSort<T>(Node<T> startNode, T target)
        {
            var dfsStack = new Stack<Node<T>>();
            dfsStack.Push(startNode);

            var visitedMap = new HashSet<T>();
            visitedMap.Add(startNode.value);

            var topologicalSortList = new List<Node<T>>();
            topologicalSortList.Add(startNode);

            while (dfsStack.Count != 0)
            {
                var currentNode = dfsStack.Pop();
                topologicalSortList.Remove(currentNode);

                if (currentNode.value.Equals(target))
                    return topologicalSortList;

                // If any child exists of the current node, enqueue them
                foreach (var child in currentNode.Children)
                {
                    if (!visitedMap.Contains(child.value))
                    {
                        dfsStack.Push(child);
                        topologicalSortList.Add(child);
                    }
                }
            }

            return topologicalSortList;
        }
    }

}
