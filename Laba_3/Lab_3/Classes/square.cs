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

        Point square_center = new Point(0, 0);

        public int x1 { get; set; }        
        public int y1 { get; set; }
        public int x2 { get; set; }
        public int y2 { get; set; }
        public int a { get; set; }

        public bool square_is_visible { get; set; }

        public square()
        {
            square_center.x = rnd.Next(lx_edge, rx_edge);
            square_center.y = rnd.Next(ly_edge, ry_edge - 100);
            a = rnd.Next(10,300);
            square_is_visible = true;
        }

        public square(int x1, int y1, int A, bool square_is_visible)
        {
            
            square_center.x = x1;
            square_center.y = y1;
            this.a = A;
            this.square_is_visible = square_is_visible;
        }

        public void show(Graphics gc, Color color)
        {
            if (square_is_visible == true)
            {
                Pen pen = new Pen(color, 5);
                gc.DrawRectangle(pen, square_center.x-a/2, square_center.y-a/2, a, a);
            }
        }
        public void to_double()
        {
            this.a = 2 * a;
        }
        public void MoveToRight(int x)
        {
            square_center.x += x;
        }
        public void MoveToLeft(int x)
        {
            square_center.x -= x;

        }
        public void MoveToUp(int y)
        {
            square_center.y -= y;
        }
        public void MoveToDown(int y)
        {
            square_center.y += y;
        }

    }
}
