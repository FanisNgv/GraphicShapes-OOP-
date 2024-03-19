using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyLab1
{
    class circle 
    {
        int lx_edge = 430;
        int ly_edge = 38;
        int rx_edge = 1100;
        int ry_edge = 750;
                
        Random rnd = new Random();

        Point circle_center = new Point(0, 0);
        
        public int R { get; set; }

        public bool circle_is_visible { get; set; }

        public circle()
        {
            circle_center.x = rnd.Next(lx_edge, rx_edge - 100);
            circle_center.y = rnd.Next(ly_edge, ry_edge + 100);
            this.R = rnd.Next(10, 200);            
            this.circle_is_visible = true;            
        }

        public circle( int x1, int y1, int R, bool circle_is_visible)
        {
            circle_center.x = x1; 
            circle_center.y = y1;        
            this.R = R;
            this.circle_is_visible = circle_is_visible;            
        }

        public void show(Graphics gc, Color color)
        {
            if (circle_is_visible == true)
            {
                Pen pen = new Pen(color, 5);
                gc.DrawEllipse(pen, circle_center.x-R, circle_center.y-R, 2*R, 2*R);
            }
        }
        
        public void Move(int x, int y)
        {
            moving_to moving = moving_to.Right;

            if (x > 0 && y == 0)
            {
                moving = moving_to.Right;
            }
            else if (x < 0 && y == 0)
            {
                moving = moving_to.Left;
            }
            else if (x == 0 && y > 0)
            {
                moving = moving_to.Down;
            }
            else if (x == 0 && y < 0)
            {
                moving = moving_to.Up;
            }


            switch (moving)
            {
                case moving_to.Right:
                    circle_center.x += x;
                    break;
                case moving_to.Left:
                    circle_center.x += x;
                    break;
                case moving_to.Up:
                    circle_center.y += y;
                    break;
                case moving_to.Down:
                    circle_center.y += y;
                    break;
            }
        }

    }
}
