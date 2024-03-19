using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ClassLibrary_1
{
    public class square : Abstract_properties 
    {
        Random rnd = new Random();             
        public bool square_is_visible { get; set; }

        public square() 
        {
            this.x1 = rnd.Next(lx_edge, rx_edge - 80);
            this.x2 = rnd.Next(100, 400);
            this.y1 = rnd.Next(ly_edge, ry_edge - 80);
            this.y2 = x2;
            square_is_visible = true;
        }

        public square(int x1, int y1, int x2, int y2, bool square_is_visible)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = x2;
            this.square_is_visible = square_is_visible;
        }

        public override void Show(Graphics gc, Color color)
        {
            if (square_is_visible == true)
            {
                Pen pen = new Pen(color, 5);
                gc.DrawRectangle(pen, x1, y1, x2, y2);
            }
        }
        public void to_double()
        {
            this.x1 = x1 - x2 / 2;
            this.y1 = y1 - x2 / 2;
            this.x2 = 2 * x2;
            this.y2 = x2;
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
