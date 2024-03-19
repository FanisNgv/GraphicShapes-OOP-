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
        private Random rnd = new Random();             
        public bool square_is_visible { get; set; }
        public int A;

        public square() 
        {
            this.x1 = rnd.Next(lx_edge, rx_edge - 80);            
            this.y1 = rnd.Next(ly_edge, ry_edge - 80);
            this.A = rnd.Next(50, 200);

            square_is_visible = true;
        }
              

        public override void Show(Graphics gc, Color color)
        {
            if (square_is_visible == true)
            {
                Pen pen = new Pen(color, 5);
                gc.DrawRectangle(pen, x1-A/2, y1-A/2, A, A);
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
        public override void Delete()
        {
            square_is_visible = false;
        }

    }
}
