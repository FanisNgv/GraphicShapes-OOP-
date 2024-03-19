using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyLab1
{
    
    class ring
    {
        int lx_edge = 430;
        int ly_edge = 38;
        int rx_edge = 1100;
        int ry_edge = 750;
                                
        Random rnd = new Random();

        circle internal_circle = new circle();
        circle external_circle = new circle();
        Point center_of_ring = new Point(0,0);
                
        public bool ring_is_visible { get; set; }

        public ring()
        {
            center_of_ring.x = rnd.Next(lx_edge, rx_edge);
            center_of_ring.y = rnd.Next(ly_edge, ry_edge);

            external_circle.R = rnd.Next(50, 200);
            internal_circle.R = rnd.Next(10, 49);                   
                        
            ring_is_visible = true;
        }
        public ring(int x, int y, int R, int a)
        {
            center_of_ring.x = x;
            center_of_ring.y = y;
            external_circle.R = R;
            internal_circle.R = R - a;

            ring_is_visible = true;
        }
        public void show(Graphics gc, Color color)
        {
            if (ring_is_visible == true)
            {
                Pen pen = new Pen(color, 5);

                gc.DrawEllipse(pen, center_of_ring.x - (internal_circle.R), center_of_ring.y - (internal_circle.R), 2 * (internal_circle.R), 2 * (internal_circle.R));
                gc.DrawEllipse(pen, center_of_ring.x - external_circle.R, center_of_ring.y - external_circle.R, 2 * external_circle.R, 2 * external_circle.R);
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
                    center_of_ring.x += x;                    
                    break;
                case moving_to.Left:
                    center_of_ring.x += x;                    
                    break;
                case moving_to.Up:                    
                    center_of_ring.y += y;
                    break;
                case moving_to.Down:
                    center_of_ring.y += y;                    
                    break;
            }
        }
    }
}
