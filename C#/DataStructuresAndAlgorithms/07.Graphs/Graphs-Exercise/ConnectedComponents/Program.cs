﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ConnectedComponents
{
    internal class Program
    {
        private static bool[] visited;
        private static List<int>[] graph;

        static void Main(string[] args)
        {
            graph = ReadGraph();
            FindConnectedComponents();
        }

        private static List<int>[] ReadGraph()
        {
            int n = int.Parse(Console.ReadLine());
            var graph = new List<int>[n];

            for (int i = 0; i < n; i++)
            {
                graph[i] = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();
            }

            return graph;
        }

        private static void FindConnectedComponents()
        {
            visited = new bool[graph.Length];

            for (int startNode = 0; startNode < graph.Length; startNode++)
            {
                if (!visited[startNode])
                {
                    Console.Write("Connected component:");
                    DFS(startNode);
                    Console.WriteLine();
                }
            }
        }

        private static void DFS(int vertex)
        {
            if (!visited[vertex])
            {
                visited[vertex] = true;
                foreach (var child in graph[vertex])
                {
                    DFS(child);
                }
                Console.Write(" " + vertex);
            }
        }
    }
}
