using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyLab1
{
    public partial class Form1 : Form
    {
        
        string row_name;
        int for_circ = 1;
        int for_rect = 1;
        int for_square = 1;
        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;            
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            circle Circle = new circle();

            MessageBox.Show("Круг успешно создан!");
            row_name = "Круг";

            checkedListBox1.Items.Add(row_name + for_circ);
            row_name = "";
            for_circ++;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            rectangle Rect = new rectangle();

            MessageBox.Show("Прямоугольник успешно создан!");
            row_name = "Прямоугольник";
            checkedListBox1.Items.Add(row_name + for_rect);
            row_name = "";
            for_rect++;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            square Square = new square();
           
            MessageBox.Show("Квадрат успешно создан!");
            row_name = "Квадрат";
            checkedListBox1.Items.Add(row_name + for_square);
            row_name = "";
            for_square++;
        }

        private void button4_Click(object sender, EventArgs e)
        {            
            
            if (!true)
            {
                MessageBox.Show("Вы еще не создали квадрат!");
                return;
            }

           
            MessageBox.Show("Квадрат успешно увеличен!");
        }

        
        private void button5_Click(object sender, EventArgs e)
        {
            
            checkedListBox1.Items.Clear();

            for_circ = 1;
            for_rect = 1;
            for_square = 1;
                     
        }

        
    }
}
