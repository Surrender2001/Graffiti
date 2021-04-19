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

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }



        }
    }
}
