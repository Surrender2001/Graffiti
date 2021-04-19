using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graffiti
{
    class Edge
    {

        public int From { get; set; }
        public int To { get; set; }
        public int Weight { get; set; }
        public Edge(int from, int to, int weight = 0)
        {
            From = from;
            To = to;
            Weight = weight;
        }



    }
}
