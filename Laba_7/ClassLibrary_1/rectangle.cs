using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace ClassLibrary_1
{
    public class rectangle : square // пытаюсь все испортить
    {

        Random rnd = new Random();

        public bool rectangle_is_visible { get; set; }

        public rectangle()
        {
            x1 = rnd.Next(lx_edge, rx_edge - 80);
            x2 = rnd.Next(100, 400);
            y1 = rnd.Next(ly_edge, ry_edge - 80);
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

        public override void Show(Graphics gc, Color color)
        {
            if (rectangle_is_visible == true)
            {
                Pen pen = new Pen(color, 5);
                gc.DrawRectangle(pen, x1, y1, x2, y2);
            }
        }

    }
}

