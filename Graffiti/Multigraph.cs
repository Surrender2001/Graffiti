using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graffiti
{
    class Multigraph
    {
        List<Edge> Edges = new List<Edge>();
        DoublyLinkedList Vertexes = new DoublyLinkedList();
        public int EdgeCount => Edges.Count;

        public void AddEdge(int from, int to, int weight=0)
        {
            var edge = new Edge(from, to, weight);
            Edges.Add(edge);
        }

        public Multigraph(int n)
        {
            for (int i = 1; i < n+1; i++)
            {
                AddVertex(i);
            }
        }
        
        public void Print()
        {
            DoublyLinkedList dll = new DoublyLinkedList();
            int m = 0;

            for (int i = 1; i < Vertexes.Count+1; i++)
            {
                (dll, m) = GetVertexList(i);
                Console.Write($"{i}: {m}-количество исходящих ребер, ");
                dll.Print();
                dll.Clear();
            }

            Console.WriteLine();
        }

        public (DoublyLinkedList,int) GetVertexList(int vertex)
        {
            var result = new DoublyLinkedList();
            int n = 0;
            foreach (var edge in Edges)
            {
                if (edge.From == vertex)
                {
                    result.Add(edge.To);
                    n++;
                }

            }
            return (result,n);
        }

        public void AddVertex(int i)
        {
            Vertexes.Add(i);
        }

        public void RemoveVertex(int k)
        {

            Edges.RemoveAll(i => i.From == k || i.To == k);
            Vertexes.Remove(k);
        }

        public void Clear()
        {
            Edges.Clear();
            Vertexes.Clear();
        }
    }
}
