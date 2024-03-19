using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ClassLibrary_1
{
    enum moving_to
    {
        Right,
        Left,
        Down, 
        Up
    }
    
    public abstract class Abstract_properties
    {        
        public int lx_edge = 430;
        public int ly_edge = 38;
        public int rx_edge = 1100;
        public int ry_edge = 750;

        
        public bool rhomb_is_visible { get; set; }        
        public int A { get; set; }
        public int B { get; set; }

        public Point[] points = new Point[4];

        public Graphics gc;

        public int x1 { get; set; }
        public int y1 { get; set; }
        public int x2 { get; set; }
        public int y2 { get; set; }

        protected Abstract_properties() {}
      
        public virtual void Show(Graphics gc, Color color)
        {
            Console.WriteLine("Just writing smthg 'cause I will override it");
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
                    x1 += x;
                    Show(gc, Color.Aquamarine);
                    break;
                case moving_to.Left:
                    x1 += x;
                    Show(gc, Color.Aquamarine);
                    break;
                case moving_to.Up:
                    y1 += y;
                    Show(gc, Color.Aquamarine);
                    break;
                case moving_to.Down:
                    y1 += y;
                    Show(gc, Color.Aquamarine);
                    break;
            }
        }
        public void MoveRhomb(int x, int y)
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
                    Show(gc, Color.Aquamarine);
                    break;
                case moving_to.Left:
                    points[0].X += x;
                    points[1].X += x;
                    points[2].X += x;
                    points[3].X += x;
                    Show(gc, Color.Aquamarine);
                    break;
                case moving_to.Up:
                    points[0].Y += y;
                    points[1].Y += y;
                    points[2].Y += y;
                    points[3].Y += y;
                    Show(gc, Color.Aquamarine);
                    break;
                case moving_to.Down:
                    points[0].Y += y;
                    points[1].Y += y;
                    points[2].Y += y;
                    points[3].Y += y;
                    Show(gc, Color.Aquamarine);
                    break;
            }
        }
    }
}
