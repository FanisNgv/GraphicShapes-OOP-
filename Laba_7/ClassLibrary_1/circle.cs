using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ClassLibrary_1
{
    public class circle : Abstract_properties
    {      

        Random rnd = new Random();               

        public bool circle_is_visible { get; set; }
        private int R;
        public int r
        {
            get
            {
                return R;
            }
            set
            {
                R = value;
            }
        }
        
        public circle()
        {                     
            this.x1 = rnd.Next(lx_edge, rx_edge - 100);
            this.y1 = rnd.Next(ly_edge, ry_edge - 100);
            this.R = rnd.Next(10, 200);
            this.circle_is_visible = true;
        }

        public circle(int x1, int y1, int R, bool circle_is_visible) 
        {
            this.x1 = x1;           
            this.y1 = y1;
            this.R = R;
            
            this.circle_is_visible = circle_is_visible;

        }

        public override void Show(Graphics gc, Color color)
        {
            if (circle_is_visible == true)
            {
                Pen pen = new Pen(color, 5);
                gc.DrawEllipse(pen, x1-R, y1-R, 2*R, 2*R);
            }
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
