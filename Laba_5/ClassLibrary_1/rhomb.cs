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
        
    }
}
