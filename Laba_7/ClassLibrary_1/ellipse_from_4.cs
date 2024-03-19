using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ClassLibrary_1
{
    public class ellipse : circle
    {
        Random rnd = new Random();
        public int radius;
        public bool ellipse_is_visible {get;set;}             
        public ellipse()
        {
            x1 = rnd.Next(lx_edge, rx_edge - 80);
            y1 = rnd.Next(100, 400);
            this.r = rnd.Next(10, 250);
            this.radius = rnd.Next(10, 250);
            
            ellipse_is_visible = true;
        }
        public ellipse(int x1, int y1, int a, int b, bool ellipse_is_visible)
        {
            this.x1 = x1;
            this.y1 = y1;
            r = a / 2;
            radius = b / 2;

            this.ellipse_is_visible = ellipse_is_visible;
        }
        public override void Show(Graphics gc, Color color)
        {
            if (ellipse_is_visible == true)
            {
                Pen pen = new Pen(color, 5);
                gc.DrawEllipse(pen, x1-r, y1-radius, 2*r, 2*radius);
            }
        }
        public void rotate_for_90()
        {
            int changer = this.r;
            this.r = radius;
            radius = changer;                       
        }
        public override void Move(int x, int y)
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
                    x1 += x;
                    break;
                case moving_to.Left:
                    x1 += x;
                    break;
                case moving_to.Up:
                    y1 += y;
                    break;
                case moving_to.Down:
                    y1 += y;
                    break;
            }
        }

    }
}
