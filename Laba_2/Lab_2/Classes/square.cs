using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

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
        public int a { get; set; }

        public bool square_is_visible { get; set; }

        public square()
        {
            x1 = rnd.Next(lx_edge, ry_edge-80);
            y1 = rnd.Next(ly_edge, ry_edge-80);
            a = rnd.Next(50, 200);
            square_is_visible = true;
        }

        public square(int x1, int y1, int a, bool square_is_visible)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.a = a;
            this.square_is_visible = square_is_visible;
        }

        public void show(Graphics gc, Color color)
        {
            if (square_is_visible == true)
            {
                Pen pen = new Pen(color, 5);
                gc.DrawRectangle(pen, x1-a, y1-a, 2*a, 2*a);
            }
        }
        public void to_double()
        {
            this.a = 2 * a;            
                       
        }
        public void MoveToRight(int x)
        {
            x1 += x;
        }
        public void MoveToLeft(int x)
        {
            x1 -= x;

        }
        public void MoveToUp(int y)
        {
            y1 -= y;
        }
        public void MoveToDown(int y)
        {
            y1 += y;
        }

    }
}
