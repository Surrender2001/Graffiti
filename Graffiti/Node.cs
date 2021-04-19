using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graffiti
{
    class Node
    {
        public Node(int data)
        {
            Data = data;
        }
        public int Data { get; set; }
        public Node Previous { get; set; }
        public Node Next { get; set; }

    }
}
