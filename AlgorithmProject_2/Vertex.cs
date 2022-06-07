using System.Collections.Generic;

namespace AlgorithmProject_2
{
    internal class Vertex : IComparer<Vertex>
    {
        internal int color;
        internal int Degree => adj.Count; 

        private List<Vertex> adj;

        #region Constructors

        internal Vertex()
        {
            color = -1;
            adj = new List<Vertex>();
        }

        internal Vertex(int color)
        {
            this.color = color;
            adj = new List<Vertex>();
        }

        internal Vertex(List<Vertex> neighbors)
        {
            color = -1;
            adj = neighbors;
        }

        internal Vertex(int color,List<Vertex> neighbors)
        {
            this.color = color;
            adj = neighbors;
        }

        #endregion

        internal void AddEdge(Vertex v)
        {
            if (v is null) 
                return;
            if (HasEdgeWith(v))
                return;
            adj.Add(v);
            v.AddEdge(this);
        }
        internal bool IsColored() => color > -1;
        internal bool IsColoredWith(int color) => this.color == color;
        internal bool HasEdgeWith(Vertex v) => adj.Contains(v);
        internal bool HasAnyNeighbors() => adj.Count > 0;
        public int Compare(Vertex x, Vertex y)
        {
            if (x is null && y is null) return 0;
            else if (x is null) return -1;
            else if (y is null) return 1;
            else if (x.Degree < y.Degree) return -1;
            else if (x.Degree > y.Degree) return 1;
            else return 0;
        }

        internal Vertex this[int index]
        {
            get
            {
                if(index >= Degree || index < 0) 
                    return null;
                return adj[index];
            }
            private set { }
        }
    }
}