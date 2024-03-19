using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ClassLibrary1
{
    class square // пытаюсь все испортить
    {
        int lx_edge = 430;
        int ly_edge = 38;
        int rx_edge = 1100;
        int ry_edge = 750;
        Random rnd = new Random();
        Graphics gr;

        public int x1 { get; set; }        
        public int y1 { get; set; }
        public int x2 { get; set; }
        public int y2 { get; set; }

        public bool square_is_visible { get; set; }

        public square()
        {
            Point square_center = new Point(rnd.Next(lx_edge, rx_edge), rnd.Next(ly_edge, ry_edge-100));
            this.x1 = square_center.x;
            this.y1 = square_center.y;
            this.x2 = rnd.Next(100, 400);            
            this.y2 = x2;
            square_is_visible = true;
        }

        public square(int x1, int y1, int x2, bool square_is_visible)
        {
            Point square_center = new Point(x1 + (x2 - x1) / 2, y1 + (y2 - y1) / 2);
            this.x1 = square_center.x - (x2 - x1) / 2;
            this.y1 = square_center.y - (y2 - y1) / 2;
            this.x2 = x2;            
            this.y2 = x2;
            this.square_is_visible = square_is_visible;
        }

        public void show(Graphics gc, Color color)
        {
            if (square_is_visible == true)
            {
                Pen pen = new Pen(color, 5);
                gc.DrawRectangle(pen, x1, y1, x2, y2);
            }
        }
        public void to_double()
        {            
            this.x1 = x1 - x2/2;
            this.y1 = y1 - x2/2;
            this.x2 = 2*x2;
            this.y2 = x2;
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
