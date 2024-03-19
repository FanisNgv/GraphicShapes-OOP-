using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ClassLibrary1
{
    class Point
    {
        public int x { get; set; }
        public int y { get; set; }
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
            MessageBox.Show("Точка создана!");
        }
    }
}
