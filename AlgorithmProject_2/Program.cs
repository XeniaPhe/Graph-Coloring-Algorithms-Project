using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/*
  Sadık Akgedik 150119052
  Mustafa Tunahan BAŞ 150119055
 */

namespace AlgorithmProject_2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Graph graph1 = ReadGraph(@"test1.txt");
            Graph graph2 = ReadGraph(@"test2.txt");
            Graph graph3 = ReadGraph(@"test3.txt");
            Graph graph4 = ReadGraph(@"test4.txt");

            int colorCount = graph1.WelshPowellGraphColoring();
            string vertices = graph1.ToString();
            WriteOutput(@"output1.txt", colorCount, vertices);

            colorCount = graph2.WelshPowellGraphColoring();
            vertices = graph2.ToString();
            WriteOutput(@"output2.txt",colorCount, vertices);

            colorCount=graph3.WelshPowellGraphColoring();
            vertices=graph3.ToString();
            WriteOutput(@"output3.txt", colorCount, vertices);

            colorCount = graph4.WelshPowellGraphColoring();
            vertices = graph4.ToString();
            WriteOutput(@"output4.txt", colorCount, vertices);
        }

        static Graph ReadGraph(string fileName)
        {
            FileStream stream = File.Open(fileName, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(stream);

            string[] content = sr.ReadLine().Split(' ');

            int vertexCount = int.Parse(content[1]);
            Graph graph = new Graph(vertexCount);
            int edgeCount = int.Parse(content[2]);

            for (int i = 0; i < edgeCount; i++)
            {
                content = sr.ReadLine().Split(' ');
                graph.AddEdge(int.Parse(content[1])-1, int.Parse(content[2])-1);
            }

            sr.Close();
            return graph;
        }

        static void WriteOutput(string fileName,int colorCount,string vertices)
        {
            FileStream stream = File.Open(fileName, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(stream);

            sw.WriteLine(colorCount);
            sw.Write(vertices);

            sw.Close();
        }
    }
}