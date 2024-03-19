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
        Up,
    }
    public abstract class Abstract_properties
    {
        public int lx_edge = 430;
        public int ly_edge = 38;
        public int rx_edge = 1100;
        public int ry_edge = 750;
        public int x1 { get; set; }
        public int y1 { get; set; }
        public int x2 { get; set; }
        public int y2 { get; set; }

        protected Abstract_properties() {}
      
        public abstract void Show(Graphics gc, Color color);
        public abstract void Move(int x, int y);
        
    }
}
