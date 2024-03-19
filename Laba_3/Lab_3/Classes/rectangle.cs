using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyLab1
{
    enum moving_to
    {
        Right,
        Left,
        Down,
        Up,
    }

    class rectangle // пытаюсь все испортить
    {
        int lx_edge = 430;
        int ly_edge = 38;
        int rx_edge = 1100;
        int ry_edge = 750;        

        Random rnd = new Random();
        Point rect_center = new Point(0, 0);             

        public int a { get; set; }
        public int b { get; set; }

        public bool rectangle_is_visible { get; set; }

        public rectangle()
        {
            rect_center.x = rnd.Next(lx_edge, rx_edge - 80);
            rect_center.y = rnd.Next(ly_edge, ry_edge - 80);

            a = rnd.Next(10, 200);
            b = rnd.Next(10, 200);
            
            rectangle_is_visible = true;
        }

        public rectangle(int x1, int y1, int A, int B, bool rectangle_is_visible)
        {
            rect_center.x = x1;
            rect_center.y = y1;
            a = A;
            b = B;
            
            this.rectangle_is_visible = rectangle_is_visible;
        }

        public void show(Graphics gc, Color color)
        {
            if (rectangle_is_visible == true)
            {
                Pen pen = new Pen(color, 5);
                gc.DrawRectangle(pen, rect_center.x - a/2, rect_center.y - b/2, a, b);
                
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
            else if (x ==0 && y > 0)
            {
                moving = moving_to.Down;
            }
            else if (x == 0 && y < 0)
            {
                moving = moving_to.Up;
            }
            

            switch(moving)
            {
                case moving_to.Right:
                    rect_center.x += x;
                    break;
                case moving_to.Left:
                    rect_center.x += x;
                    break;
                case moving_to.Up:
                    rect_center.y += y;
                    break;
                case moving_to.Down:
                    rect_center.y += y;
                    break;
            }
        }

    }
}
