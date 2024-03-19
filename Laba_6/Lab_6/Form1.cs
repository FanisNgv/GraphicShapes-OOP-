using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Collections;
using ClassLibrary_1;



namespace MyLab1
{
    public partial class Form1 : Form // пытаюсь все испортить
    {

        static int num_of_variant = 27;            


        Graphics gr;

        Random my_rnd = new Random();
        int move_pixels = 26;


        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = System.Drawing.Color.White;
        }
        Abstract_properties[] my_objects = new Abstract_properties[num_of_variant];
        bool button_18_is_clicked = false;
        private void button18_Click(object sender, EventArgs e)
        {
            if (button_18_is_clicked)
            {
                MessageBox.Show("Вы уже создали массив фигур!");
                return;
            }

            int my_rand = my_rnd.Next(1, 50);
            Thread.Sleep(10);

            for (int i = 0; i < num_of_variant; i++)
            {
                if (my_rand >= 1 && my_rand < 11)
                {
                    my_objects[i] = new circle();
                }
                else if (my_rand >= 11 && my_rand < 21)
                {
                    my_objects[i] = new ellipse();
                }
                else if (my_rand >= 21 && my_rand < 31)
                {
                    my_objects[i] = new rectangle();
                }
                else if (my_rand >= 31 && my_rand < 41)
                {
                    my_objects[i] = new square();
                }
                else if (my_rand >= 41 && my_rand < 51)
                {
                    my_objects[i] = new rhomb();
                }

                my_rand = my_rnd.Next(1, 50);
                Thread.Sleep(10);                
            }

            button_18_is_clicked = true;
            MessageBox.Show("Массив фигур создан!");

        } // СОЗДАЕМ МАССИВ
        private void button19_Click(object sender, EventArgs e)
        {
            if (!button_18_is_clicked)
            {
                MessageBox.Show("Вы еще не создали массив фигур!");
                return;
            }

            foreach (object item in my_objects)
            {
                if (item is circle circ_type)
                {
                    circ_type.circle_is_visible = true;
                    circ_type.Show(gr = CreateGraphics(), Color.Aquamarine);
                }
                else if (item is ellipse ell_type)
                {
                    ell_type.ellipse_is_visible = true;
                    ell_type.Show(gr = CreateGraphics(), Color.Aquamarine);
                }
                else if (item is rectangle rect_type)
                {
                    rect_type.rectangle_is_visible = true;
                    rect_type.Show(gr = CreateGraphics(), Color.Aquamarine);
                }
                else if (item is rhomb rh_type)
                {
                    rh_type.rhomb_is_visible = true;
                    rh_type.Show(gr = CreateGraphics(), Color.Aquamarine);
                }
                else if (item is square square_type)
                {
                    square_type.square_is_visible = true;
                    square_type.Show(gr = CreateGraphics(), Color.Aquamarine);
                }
            }


        } // ПОКАЗ ФИГУР

        private void button1_Click(object sender, EventArgs e)
        {
            if (!button_18_is_clicked)
            {
                MessageBox.Show("Вы еще не создали массив фигур!");
                return;
            }
            gr.Clear(Color.White);

            foreach (object item in my_objects)
            {
                if (item is ellipse ell_type)
                {
                    ell_type.Delete();
                }
                else if(item is circle circ_type)
                {
                    circ_type.Delete();
                }
                 
                else if (item is rectangle rect_type)
                {
                    rect_type.Delete();
                }
                else if (item is rhomb rh_type)
                {
                    rh_type.Delete();
                }
                else if (item is square square_type)
                {
                    square_type.Delete();
                }
            }

        }// ОЧИСТКА

        private void button2_Click(object sender, EventArgs e)
        {
            if (!button_18_is_clicked)
            {
                MessageBox.Show("Вы еще не создали массив фигур!");
                return;
            }
            gr.Clear(Color.White);
                        

            foreach (object item in my_objects)
            {
                if (item is ellipse ell_type)
                {
                    ell_type.rotate_for_90();
                    ell_type.Show(gr = CreateGraphics(), Color.Aquamarine);
                }
                else if (item is circle circ_type)
                {                    
                    circ_type.Show(gr = CreateGraphics(), Color.Aquamarine);                    
                }
                
                else if (item is rectangle rect_type)
                {                   
                    rect_type.Show(gr = CreateGraphics(), Color.Aquamarine);
                }
                else if (item is rhomb rh_type)
                {                     
                    rh_type.Show(gr = CreateGraphics(), Color.Aquamarine);
                }
                else if (item is square square_type)
                {                     
                    square_type.Show(gr = CreateGraphics(), Color.Aquamarine);
                }
            }

            
        }// ПОВОРОТ ЭЛЛИПСА

        private void button3_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();

            int rnd_x = rnd.Next(300, 1200);
            int rnd_y = rnd.Next(300, 600);

            if (!button_18_is_clicked)
            {
                MessageBox.Show("Вы еще не создали массив фигур!");
                return;
            }
            gr.Clear(Color.White);

            foreach (object item in my_objects)
            {
                if (item is ellipse ell_type)
                {
                    ell_type.x1 = rnd_x;
                    ell_type.y1 = rnd_y;
                    ell_type.Show(gr = CreateGraphics(), Color.Aquamarine);
                }
                else if (item is circle circ_type)
                {
                    circ_type.x1 = rnd_x;
                    circ_type.y1 = rnd_y;
                    circ_type.Show(gr = CreateGraphics(), Color.Aquamarine);
                }

                else if (item is rectangle rect_type)
                {
                    rect_type.x1 = rnd_x;
                    rect_type.y1 = rnd_y;
                    rect_type.Show(gr = CreateGraphics(), Color.Aquamarine);
                }
                else if (item is rhomb rh_type)
                {
                    rh_type.points[0] = new Point(rnd_x, rnd_y - rh_type.A/2);
                    rh_type.points[2] = new Point(rnd_x, rnd_y + rh_type.A/2);
                    rh_type.points[1] = new Point(rnd_x + rh_type.B/2, rnd_y);
                    rh_type.points[3] = new Point(rnd_x - rh_type.B/2, rnd_y);

                    rh_type.Show(gr = CreateGraphics(), Color.Aquamarine);
                }
                else if (item is square square_type)
                {
                    square_type.x1 = rnd_x;
                    square_type.y1 = rnd_y;
                    square_type.Show(gr = CreateGraphics(), Color.Aquamarine);
                }
            }

        } // ПРИВЕДЕНИЕ К ОДНОЙ ТОЧКЕ

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!button_18_is_clicked)
            {
                MessageBox.Show("Вы еще не создали массив фигур!");
                return;
            }

            gr.Clear(Color.White);

            bool circ_type_is_moving = false;
            bool square_type_is_moving = false;

            if (checkedListBox1.GetItemChecked(0))
            {

                circ_type_is_moving = true;           

                if (e.KeyValue == (char)Keys.Right)
                {
                    foreach (object item in my_objects)
                    {                        
                        if (item is circle circ_type)
                        {
                            circ_type.Move(move_pixels, 0);
                            circ_type.Show(gr = CreateGraphics(), Color.Aquamarine);
                        }                        
                    }
                }
                else if (e.KeyValue == (char)Keys.Left)
                {
                    foreach (object item in my_objects)
                    {
                        if (item is circle circ_type)
                        {
                            circ_type.Move(-move_pixels, 0);
                            circ_type.Show(gr = CreateGraphics(), Color.Aquamarine);
                        }                        
                    }
                }
                else if (e.KeyValue == (char)Keys.Up)
                {
                    foreach (object item in my_objects)
                    {                     
                        if (item is circle circ_type)
                        {
                            circ_type.Move(0, -move_pixels);
                            circ_type.Show(gr = CreateGraphics(), Color.Aquamarine);
                        }                        
                    }
                }
                else if (e.KeyValue == (char)Keys.Down)
                {
                    foreach (object item in my_objects)
                    {
                        if (item is circle circ_type)
                        {
                            circ_type.Move(0, move_pixels);
                            circ_type.Show(gr = CreateGraphics(), Color.Aquamarine);
                        }                       
                    }
                }
            }

            if (checkedListBox1.GetItemChecked(1))
            {
                square_type_is_moving = true;

                foreach (object item in my_objects)
                {
                    if (item is ellipse ell_type)
                    {
                        ell_type.ellipse_is_visible = true;
                        ell_type.Show(gr = CreateGraphics(), Color.Aquamarine);
                    }
                    else if(item is circle circ_type)
                    {
                        circ_type.circle_is_visible = true;
                        circ_type.Show(gr = CreateGraphics(), Color.Aquamarine);
                    }                 
                    
                }

                if (e.KeyValue == (char)Keys.Right)
                {
                    foreach (object item in my_objects)
                    {
                        if (item is square square_type)
                        {
                            square_type.Move(move_pixels, 0);
                            square_type.Show(gr = CreateGraphics(), Color.Aquamarine);
                        }
                    }
                }
                else if (e.KeyValue == (char)Keys.Left)
                {
                    foreach (object item in my_objects)
                    {
                        if (item is square square_type)
                        {
                            square_type.Move(-move_pixels, 0);
                            square_type.Show(gr = CreateGraphics(), Color.Aquamarine);
                        }
                    }
                }
                else if (e.KeyValue == (char)Keys.Up)
                {
                    foreach (object item in my_objects)
                    {
                        if (item is square square_type)
                        {
                            square_type.Move(0, -move_pixels);
                            square_type.Show(gr = CreateGraphics(), Color.Aquamarine);
                        }
                    }
                }
                else if (e.KeyValue == (char)Keys.Down)
                {
                    foreach (object item in my_objects)
                    {
                        if (item is square square_type)
                        {
                            square_type.Move(0, move_pixels);
                            square_type.Show(gr = CreateGraphics(), Color.Aquamarine);
                        }
                    }
                }
            }

            if(!circ_type_is_moving)
            {
                foreach (object item in my_objects)
                {
                    if (item is ellipse ell_type)
                    {
                        ell_type.ellipse_is_visible = true;
                        ell_type.Show(gr = CreateGraphics(), Color.Aquamarine);
                    }
                    else if (item is circle circ_type)
                    {
                        circ_type.circle_is_visible = true;
                        circ_type.Show(gr = CreateGraphics(), Color.Aquamarine);
                    }
                }
            }

            if(!square_type_is_moving)
            {
                foreach (object item in my_objects)
                {
                    if (item is rhomb rh_type)
                    {
                        rh_type.rhomb_is_visible = true;
                        rh_type.Show(gr = CreateGraphics(), Color.Aquamarine);
                    }
                    else if (item is rectangle rect_type)
                    {
                        rect_type.rectangle_is_visible = true;
                        rect_type.Show(gr = CreateGraphics(), Color.Aquamarine);
                    }
                    else if (item is square square_type)
                    {
                        square_type.square_is_visible = true;
                        square_type.Show(gr = CreateGraphics(), Color.Aquamarine);
                    }
                }
            }

        } // ПЕРЕМЕЩЕНИЕ

        private void button4_Click(object sender, EventArgs e)
        {
            button_18_is_clicked = false;

            gr.Clear(Color.White);
            
            for (int i = 0; i < num_of_variant; i++)
            {
                my_objects[i] = null;
            }
            MessageBox.Show("Массив очищен!");
        } // ОПУСТОШЕНИЕ МАССИВА
    }
}
