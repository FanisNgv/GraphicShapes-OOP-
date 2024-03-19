using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyLab1
{
    class frame
    {
        int lx_edge = 430;
        int ly_edge = 38;
        int rx_edge = 1100;
        int ry_edge = 750;
        
        rectangle internal_rect = new rectangle();
        rectangle external_rect = new rectangle();

        Point center_of_frame = new Point(0,0);

        Random rnd = new Random();
                
        public bool frame_is_visible { get; set; }

        private int out_more_than = 10;
        public int OUT_MORE_THAN
        {
            get
            {
                return out_more_than;
            }
            set 
            {
                out_more_than = value;
            }
        }
                
        public frame()
        {
            center_of_frame.x = rnd.Next(lx_edge, rx_edge);
            center_of_frame.y = rnd.Next(ly_edge, ry_edge);

            internal_rect.a = rnd.Next(16, 400);
            internal_rect.b = rnd.Next(16, 200);                        
            
            frame_is_visible = true;
        }
        public frame(int x, int y, int a, int b)
        {
            center_of_frame.x = x;
            center_of_frame.y = y;

            internal_rect.a = a;
            internal_rect.b = b;

            frame_is_visible = true;
        }
        public void show(Graphics gc, Color color)
        {
            if (frame_is_visible == true)
            {
                Pen pen = new Pen(color, 5);
                gc.DrawRectangle(pen, center_of_frame.x - internal_rect.a / 2, center_of_frame.y - internal_rect.b / 2, internal_rect.a, internal_rect.b);
                gc.DrawRectangle(pen, center_of_frame.x - internal_rect.a / 2 + OUT_MORE_THAN, center_of_frame.y - internal_rect.b / 2 + OUT_MORE_THAN, internal_rect.a - 2 * OUT_MORE_THAN, internal_rect.b - 2 * OUT_MORE_THAN);
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
                    center_of_frame.x += x;
                    break;
                case moving_to.Left:
                    center_of_frame.x += x;
                    break;
                case moving_to.Up:
                    center_of_frame.y += y;
                    break;
                case moving_to.Down:
                    center_of_frame.y += y;
                    break;
            }
        }
    }
}
