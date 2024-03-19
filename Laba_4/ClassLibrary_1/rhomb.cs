using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ClassLibrary_1
{
    public class rhomb:square
    {
        Random rnd = new Random();
        public bool rhomb_is_visible { get; set; }        
        public int A { get; set; }
        public int B { get; set; }

        Point[] points = new Point[4];
        
        public rhomb()
        {
            A = rnd.Next(50, 500);
            B = rnd.Next(50, 500);
            Point point1 = new Point(rnd.Next(200, 1000), rnd.Next(200,800));
            Point point2 = new Point(point1.X+B/2, point1.Y+A/2);            
            Point point3 = new Point(point1.X, point1.Y+A);
            Point point4 = new Point(point1.X - B / 2, point1.Y + A / 2);

            points[0] = point1;
            points[1] = point2;
            points[2] = point3;
            points[3] = point4;

            rhomb_is_visible = true;                  

        }
        public rhomb(int x, int y, int a, int b)
        {
            A = a;
            B = b;
            Point point1 = new Point(x, y);
            Point point2 = new Point(point1.X + B / 2, point1.Y + A / 2);
            Point point3 = new Point(point1.X, point1.Y + A);
            Point point4 = new Point(point1.X - B / 2, point1.Y + A / 2);

            points[0] = point1;
            points[1] = point2;
            points[2] = point3;
            points[3] = point4;

            rhomb_is_visible = true;

        }
        public override void Show(Graphics gc, Color color)
        {
            if (rhomb_is_visible == true)
            {
                Pen pen = new Pen(color, 5);
                gc.DrawPolygon(pen, points);
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
                    points[0].X += x;
                    points[1].X += x;
                    points[2].X += x;
                    points[3].X += x;
                    break;
                case moving_to.Left:
                    points[0].X += x;
                    points[1].X += x;
                    points[2].X += x;
                    points[3].X += x;
                    break;
                case moving_to.Up:
                    points[0].Y += y;
                    points[1].Y += y;
                    points[2].Y += y;
                    points[3].Y += y;
                    break;
                case moving_to.Down:
                    points[0].Y += y;
                    points[1].Y += y;
                    points[2].Y += y;
                    points[3].Y += y;
                    break;
            }
        }
    }
}
