using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace ClassLibrary_1
{
    public class rectangle : square
    {

        private Random rnd = new Random();

        public bool rectangle_is_visible { get; set; }

        public int A;
        public int B;

        public rectangle()
        {
            x1 = rnd.Next(lx_edge, rx_edge - 80);
            x2 = rnd.Next(100, 400);

            A = rnd.Next(50, 200);
            B = rnd.Next(50, 200);

            rectangle_is_visible = true;
        }        

        public override void Show(Graphics gc, Color color)
        {
            if (rectangle_is_visible == true)
            {
                Pen pen = new Pen(color, 5);
                gc.DrawRectangle(pen, x1-A/2, y1-B/2, A, B);
            }
        }
        public override void Delete()
        {
            rectangle_is_visible = false;
        }
    }
}

