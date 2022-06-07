using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmProject_2
{
    internal class Graph : IComparer<Vertex>
    {
        List<Vertex> vertices;
        internal int VertexCount => vertices.Count;

        internal Graph(int vertexCount)
        {
            vertices = new List<Vertex>();
            for (int i = 0; i < vertexCount; i++)
                AddVertex();
        }

        internal Graph(List<Vertex> vertices)
        {
            this.vertices = vertices ?? new List<Vertex>();
        }
        internal Vertex this[int index]
        {
            get
            {
                if (index < 0 || index >= VertexCount)
                    return null;
                return vertices[index];
            }
            private set { }
        }

        internal void AddVertex() => vertices.Add(new Vertex());

        internal void AddVertex(Vertex v) => vertices.Add(v);

        internal void AddEdge(Vertex a,Vertex b)
        {
            if (a is null || b is null) 
                return;
            if (!vertices.Contains(a))
                vertices.Add(a);
            if (!vertices.Contains(b))
                vertices.Add(b);

            a.AddEdge(b);
        }

        internal void AddEdge(int a, int b) => AddEdge(this[a], this[b]);

        internal int WelshPowellGraphColoring()
        {
            List<Vertex> sorted = new List<Vertex>();
            foreach (var vertex in vertices)
            {
                vertex.color = -1;
                sorted.Add(vertex);
            }

            sorted.Sort(Compare); //Descending order
            bool validator;
            int color = 0;

            while (!AreAllcolored())
            {
                foreach (var vertex in sorted)
                {
                    if (vertex.IsColored())
                        continue;

                    validator = true;
                    for (int i = 0; i < vertex.Degree; i++)
                    {
                        if(vertex[i].IsColoredWith(color))
                        {
                            validator = false;
                            break;
                        }
                    }

                    if (validator)
                        vertex.color = color;
                }

                ++color;
            }

            return color;
        }

        internal bool AreAllcolored() => vertices.Find(v => v.color < 0) == null;
        
        public int Compare(Vertex x, Vertex y)
        {
            if (x is null && y is null) return 0;
            else if (x is null) return -1;
            else if (y is null) return 1;

            return -x.Compare(x, y);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            foreach (var vertex in vertices)
            {
                builder.Append(vertex.color);
                builder.Append(' ');
            }
            builder.Remove(builder.Length - 1, 1);

            return builder.ToString();
        }
    }
}