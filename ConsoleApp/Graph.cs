using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Graph
    {
        int vertices;
        List<int>[] adj;

        public Graph(int numOfVertices)
        {
            vertices = numOfVertices;
            adj = new List<int>[numOfVertices];

            for (int i = 0; i < numOfVertices; i++)
            {
                adj[i] = new List<int>();
            }
        }
        public void AddEdge(int v, int w)
        {
            adj[v].Add(w);
            // non directed: adj[w].Add(v);
        }
        public void BFS(int startNode)
        {
            var visited = new bool[vertices];

            var queue = new Queue<int>();
            visited[startNode] = true;
            queue.Enqueue(startNode);

            while (queue.Count != 0)
            {
                startNode = queue.Dequeue();
                Console.WriteLine($"next: {startNode}");

                foreach (int neighbour in adj[startNode])
                {
                    if (!visited[neighbour])
                    {
                        visited[neighbour] = true;
                        queue.Enqueue(neighbour);
                    }
                }

            }
        }
        public void DFS(int startNode)
        {
            var visited = new bool[vertices];

            var stack = new Stack<int>();
            visited[startNode] = true;
            stack.Push(startNode);

            while (stack.Count != 0)
            {
                startNode = stack.Pop();
                Console.WriteLine($"next: {startNode}");

                foreach (int neighbour in adj[startNode])
                {
                    if (!visited[neighbour])
                    {
                        visited[neighbour] = true;
                        stack.Push(neighbour);
                    }
                }
            }
        }
        public void PrintAdjacencyMatrix()
        {
            for (int i = 0; i < vertices; i++)
            {
                Console.Write(i + ":[");
                string s = "";
                foreach (var k in adj[i])
                {
                    s = s + (k + ",");
                }
                s = s.Substring(0, s.Length - 1);
                s = s + "]";
                Console.Write(s);
                Console.WriteLine();
            }
        }

    }
}
