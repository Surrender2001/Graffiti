using System;
using System.IO;

namespace Graffiti
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\msi\Desktop\Graffiti\graph.txt";

            try
            {
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                {
                    string line;
                    int n;
                    n = int.Parse(sr.ReadLine());
                    Console.WriteLine(n);


                    //добавил граф с вершинами(Success)
                    var multiGraph = new Multigraph(n);



                    //надо реализовать дуги (Success)
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] words = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        //сделать проверку на одиночные вершины
                        for (int i = 1; i < words.Length; i += 2)
                        {
                            multiGraph.AddEdge(int.Parse(words[0]),
                                int.Parse(words[i]),
                                int.Parse(words[i + 1]));
                        }
                    }

                    multiGraph.Print();

                    Console.WriteLine();
                    //Добавление вершины (Success)
                    multiGraph.AddVertex(++n);
                    multiGraph.Print();
                    //Добавление дуги (Success)
                    multiGraph.AddEdge(6, 5, 8);
                    multiGraph.Print();

                    //Удаление вершины (Success)
                    multiGraph.RemoveVertex(2);
                    multiGraph.Print();


                    //Удаление дуги



                    //Деструктор (Success)
                    multiGraph.Clear();
                    multiGraph.Print();

                    //Console.WriteLine("Список смежности:");
                    //m = 0;
                    //for (int i = 1; i < n + 1; i++)
                    //{
                    //    (dll, m) = multiGraph.GetVertexList(i);
                    //    Console.Write($"{i}: {m}-количество исходящих ребер, ");
                    //    dll.Print();
                    //    dll.Clear();
                    //}



                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }



        }
    }
}
