using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyLab1
{
    class rectangle
    {
        int lx_edge = 430;
        int ly_edge = 38;
        int rx_edge = 1100;
        int ry_edge = 750;
        Random rnd = new Random();
        
        public int x1 { get; set; }
        public int x2 { get; set; }
        public int y1 { get; set; }
        public int y2 { get; set; }

        public bool rectangle_is_visible { get; set; }

        public rectangle()
        {
            x1 = rnd.Next(lx_edge, rx_edge-80);
            x2 = rnd.Next(100, 400);
            y1 = rnd.Next(ly_edge, ry_edge-80);
            y2 = rnd.Next(100, 400);
            rectangle_is_visible = true;
        }

        public rectangle(int x1, int y1, int x2, int y2, bool rectangle_is_visible)
        {
            this.x1 = x1;
            this.x2 = x2;
            this.y1 = y1;
            this.y2 = y2;
            this.rectangle_is_visible = rectangle_is_visible;
        }

        public void show(Graphics gc, Color color)
        {
            if (rectangle_is_visible == true)
            {
                Pen pen = new Pen(color, 5);
                gc.DrawRectangle(pen, x1, y1, x2, y2);
            }
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
