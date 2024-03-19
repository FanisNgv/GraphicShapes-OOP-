using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ClassLibrary1
{
    class circle 
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

        public bool circle_is_visible { get; set; }

        public circle()
        {
            Point circle_center = new Point(rnd.Next(lx_edge, rx_edge - 100), rnd.Next(50, 400));
            this.x1 = circle_center.x;            
            this.y1 = circle_center.y;
            this.x2 = rnd.Next(50, 400);
            this.y2 = x2;
            this.circle_is_visible = true;            
        }

        public circle( int x1, int y1, int x2, int y2, bool circle_is_visible)
        {
            Point circle_center = new Point(x1+(x2-x1)/2, y1+(y2-y1)/2);
            
            this.x1 = circle_center.x- (x2 - x1) / 2;
            this.x2 = x2;
            this.y1 =circle_center.y - (y2 - y1) / 2;
            this.y2 = x2;
            this.circle_is_visible = circle_is_visible;
            
        }

        public void show(Graphics gc, Color color)
        {
            if (circle_is_visible == true)
            {
                Pen pen = new Pen(color, 5);
                gc.DrawEllipse(pen, x1, y1, x2, y2);
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
