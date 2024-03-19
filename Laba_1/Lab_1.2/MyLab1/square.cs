using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLab1
{
    class square
    {
        int lx_edge = 430;
        int ly_edge = 38;
        int rx_edge = 1100;
        int ry_edge = 750;

        Random rnd = new Random();
        
        public int x1 { get; set; }
        public int y1 { get; set; }
        public int x2 { get; set; }
        public int y2 { get; set; }

        public bool square_is_visible { get; set; }

        public square()
        {
            x1 = rnd.Next(lx_edge, ry_edge - 80);
            x2 = rnd.Next(100, 400);
            y1 = rnd.Next(ly_edge, ry_edge - 80);
            y2 = x2;
            square_is_visible = true;
        }

        public square(int x1, int y1, int x2, bool square_is_visible)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = x2;
            this.square_is_visible = square_is_visible;
        }

    }
}
