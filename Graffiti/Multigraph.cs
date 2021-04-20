using System;
using System.Collections.Generic;

namespace Graffiti
{
    class Multigraph
    {
        List<Edge> Edges = new List<Edge>();//Список дуг
        DoublyLinkedList Vertexes = new DoublyLinkedList();//Список смежности
        public int EdgeCount => Edges.Count;//кол-во дуг

        //Добавить дугу
        //Формальные параметры:from-от какой вершины ,to- в какую, weight- вес
        //Входные данные: дуга
        //Выходные данные: список
        public void AddEdge(int from, int to, int weight = 0)
        {
            var edge = new Edge(from, to, weight);
            Edges.Add(edge);
        }

        public Multigraph(int n)
        {
            for (int i = 1; i < n + 1; i++)
            {
                AddVertex(i);
            }
        }

        //Вывод
        //Формальные параметры:пусто
        //Входные данные: список
        //Выходные данные: список смежности
        public void Print()
        {
            DoublyLinkedList dll = new DoublyLinkedList();
            int m = 0;

            for (int i = 1; i < Vertexes.Count + 1; i++)
            {
                (dll, m) = GetVertexList(i);
                Console.Write($"{i}: {m}-количество исходящих ребер, ");
                dll.Print();
                dll.Clear();
            }

            Console.WriteLine();
        }

        //Получить список смежности
        //Формальные параметры: номер вершины
        //Входные данные: список
        //Выходные данные: список смежности
        public (DoublyLinkedList, int) GetVertexList(int vertex)
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
            return (result, n);
        }

        //Получить список смежности
        //Формальные параметры:пусто
        //Входные данные: список
        //Выходные данные: список смежности
        public List<int> GetVertexList2(int vertex)
        {
            var result = new List<int>();
            foreach (var edge in Edges)
            {
                if (edge.From == vertex)
                    result.Add(edge.To);
                

            }
            return result;
        }

        //Добавить вершину
        //Формальные параметры:номер вершины
        //Входные данные: вершина
        //Выходные данные: список вершин
        public void AddVertex(int i)
        {
            Vertexes.Add(i);
        }

        //Удалить вершину
        //Формальные параметры:номер вершины
        //Входные данные: вершина
        //Выходные данные: список вершин, список дуг
        public void RemoveVertex(int k)
        {

            Edges.RemoveAll(i => i.From == k || i.To == k);
            Vertexes.Remove(k);
        }

        //Удалить дугу
        //Формальные параметры:from-от какой вершины ,to- в какую, weight- вес
        //Входные данные: дуга
        //Выходные данные: список дуг
        public void RemoveEdge(int from, int to, int weight)
        {
            Edges.RemoveAll(i => i.From == from && i.To == to && i.Weight == weight);

        }

        //Деструктор
        //Формальные параметры:пусто
        //Входные данные: 
        //Выходные данные: пустой список дуг и список смежности
        public void Clear()
        {
            Edges.Clear();
            Vertexes.Clear();
        }

        //Не рекурсивный обход в глубину
        //Формальные параметры: vertex- номер вершины
        //Входные данные: вершина
        //Выходные данные: список смежности
        public void DFS(int vertex)
        {
            bool[] passed = new bool[Vertexes.Count + 1];
            Stack<int> st=new Stack<int>();
            st.Push(vertex);
            Console.WriteLine("DFS: ");
            while (st.Count != 0)
            {
                int v = st.Peek();
                st.Pop();
                if (!passed[v])
                {
                    //Отметили, что прошли
                    passed[v] = true;
                    Console.Write(v+" ");
                    //Вершины, в которые есть путь
                    //Как добавить в стек?
                    List<int>vs = GetVertexList2(v);
                    foreach (var i in vs)
                        st.Push(i);
                }
            }


        }
    }
}
