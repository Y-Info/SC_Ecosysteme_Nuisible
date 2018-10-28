using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_nuisible
{
    class Ecosysteme
    {
        public int LimiteX { get; set; }
        public int LimiteY { get; set; }


        public Ecosysteme()
        {
        }

        public Ecosysteme(int maxX, int maxY)
        {
            this.LimiteX = maxX;
            this.LimiteY = maxY;
        }
    }
}
