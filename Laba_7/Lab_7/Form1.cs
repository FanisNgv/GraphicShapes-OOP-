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
       
        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = System.Drawing.Color.White;            
        }

        Graphics gc;

        bool text_box_is_wrote = false;
        bool text_box_of_list_is_wrote = false;

        public static int num_of_shapes;

        bool massive_is_created = false;
        bool list_is_created = false;
        bool user_list_is_created = false;

        int move_pixels = 10;
        public static int variant = 27;

        int itr = 0;

        Random my_rnd = new Random();

        
        Massive_container[] massives = new Massive_container[2];

        LinkedList[] list_massive = new LinkedList[2];


        private void button1_Click_1(object sender, EventArgs e)
        {
            if (massive_is_created)
            {
                MessageBox.Show("Массив уже создан!");
            }
            massives[0] = new Massive_container();
            massive_is_created = true;
            
        }// СОЗДАНИЕ МАССИВА

        private void button3_Click(object sender, EventArgs e)
        {
            if (text_box_is_wrote)
            {
                massives[1].expansion_of_massive(gc = CreateGraphics());
            }
            else
                massives[0].expansion_of_massive(gc = CreateGraphics());
        } // РАСШИРЕНИЕ МАССИВА

        private void button4_Click(object sender, EventArgs e)
        {
            if (text_box_is_wrote)
            {
                massives[1].iterator_for_delete(gc = CreateGraphics());
            }
            else
                massives[0].iterator_for_delete(gc = CreateGraphics());
        }// УДАЛЕНИЕ ФИГУР

        private void button5_Click(object sender, EventArgs e)
        {
            if (text_box_is_wrote)
            {
                massives[1].iterator_for_show(gc = CreateGraphics());
            }
            else
                massives[0].iterator_for_show(gc = CreateGraphics());
        } // ПОКАЗ ФИГУР

        private void button6_Click(object sender, EventArgs e)
        {
            if (list_is_created)
            {
                gc.Clear(Color.White);


                list_massive[0].iterator_for_move(0,-move_pixels, gc);
                return;
            }
            else if (user_list_is_created)
            {
                gc.Clear(Color.White);


                list_massive[1].iterator_for_move(0, -move_pixels, gc);
                return;
            }
            if (text_box_is_wrote)
            {
                massives[1].iterator_for_move(0, -move_pixels, gc);
            }
            else
                massives[0].iterator_for_move(0, -move_pixels, gc);
        }// ДВИЖЕНИЕ ВВЕРХ

        private void button9_Click(object sender, EventArgs e)
        {

            if (list_is_created)
            {
                gc.Clear(Color.White);


                list_massive[0].iterator_for_move(0,move_pixels, gc);
                return;
            }
            else if (user_list_is_created)
            {
                gc.Clear(Color.White);


                list_massive[1].iterator_for_move(0,move_pixels, gc);
                return;
            }


            if (text_box_is_wrote)
            {
                massives[1].iterator_for_move(0, move_pixels, gc);
            }
            else
                massives[0].iterator_for_move(0, move_pixels, gc);
            
        }// ДВИЖЕНИЕ ВНИЗ

        private void button8_Click(object sender, EventArgs e)
        {
            if (list_is_created)
            {
                gc.Clear(Color.White);


                list_massive[0].iterator_for_move(move_pixels, 0, gc);
                return;
            }
            else if (user_list_is_created)
            {
                gc.Clear(Color.White);


                list_massive[1].iterator_for_move(move_pixels, 0, gc);
                return;
            }

            if (text_box_is_wrote)
            {
                massives[1].iterator_for_move(move_pixels, 0, gc);
            }
            else
                massives[0].iterator_for_move(move_pixels, 0, gc);
            
        }// ДВИЖЕНИЕ ВПРАВО

        private void button7_Click(object sender, EventArgs e)
        {
            if (list_is_created)
            {
                gc.Clear(Color.White);

                list_massive[0].iterator_for_move(-move_pixels, 0, gc);
                return;
            }    
            else if(user_list_is_created)
            {
                gc.Clear(Color.White);

                list_massive[1].iterator_for_move(-move_pixels, 0, gc);
                return;
            }
           
            if (text_box_is_wrote)
            {
                massives[1].iterator_for_move(-move_pixels, 0, gc);
            }
            else
                massives[0].iterator_for_move(-move_pixels, 0, gc);
            
        }// ДВИЖЕНИЕ ВЛЕВО

        private void button2_Click(object sender, EventArgs e)
        { 
            if(massive_is_created)
            {
                MessageBox.Show("Массив уже создан!");
                return;
            }

            num_of_shapes = int.Parse(textBox1.Text);
            massives[1] = new Massive_container(num_of_shapes);
            text_box_is_wrote = true;
            massive_is_created = true;
            MessageBox.Show("Пустой массив создан!");

        } // ПОДТВЕРЖДЕНИЕ ВВОДА
        private void button11_Click(object sender, EventArgs e)
        {

            if (text_box_is_wrote)
            {
                massives[1].collapsing_massive(gc);
            }
            else
                massives[0].collapsing_massive(gc);

            text_box_is_wrote = false;
            massive_is_created = false;
        }// УНИЧТОЖЕНИЕ МАССИВА
        private void tabControl1_Click(object sender, EventArgs e)
        {
            if (massive_is_created)
            {
                try { gc.Clear(Color.White); }
                catch { };
                
                if (text_box_is_wrote)
                {
                    massives[1].collapsing_massive(gc);
                }
                else
                    massives[0].collapsing_massive(gc);

                text_box_is_wrote = false;
                massive_is_created = false;
            }
            else if (list_is_created||user_list_is_created)
            {
                try
                {
                    gc.Clear(Color.White);
                }
                catch
                {

                }
                try
                {
                    foreach (var item in list_massive[0])
                    {
                        list_massive[0].Remove(item);
                    }
                    foreach (var item in list_massive[1])
                    {
                        list_massive[1].Remove(item);
                    }
                }
                catch
                {}

                text_box_of_list_is_wrote = false;
                list_is_created = false;
                user_list_is_created = false;
                itr = 0;
                MessageBox.Show("Список уничтожен!");

            }
            


        } //НАЖАТИЕ ПО ВКЛАДКЕ





        private void button10_Click(object sender, EventArgs e) // СОЗДАНИЕ СПИСКА
        {
            if (user_list_is_created || list_is_created)
            {
                MessageBox.Show("Список уже создан!");
                return;
            }

            list_massive[0] = new LinkedList();

            foreach (var item in list_massive[0])
            {
                item.Show(gc = CreateGraphics(), Color.Aquamarine);
            }
            list_is_created = true;           


        }

        private void button13_Click(object sender, EventArgs e)
        {
            gc.Clear(Color.White);

            if (list_is_created)
            {
                foreach (var item in list_massive[0])
                {
                    if (item is ellipse ell_type)
                    {
                        ell_type.ellipse_is_visible = false;
                        ell_type.Show(gc, Color.Aquamarine);
                    }

                    else if (item is circle circ_type)
                    {
                        circ_type.circle_is_visible = false;
                        circ_type.Show(gc, Color.Aquamarine);
                    }

                    else if (item is rectangle rect_type)
                    {
                        rect_type.rectangle_is_visible = false;
                        rect_type.Show(gc, Color.Aquamarine);
                    }
                    else if (item is rhomb rh_type)
                    {
                        rh_type.rhomb_is_visible = false;
                        rh_type.Show(gc, Color.Aquamarine);
                    }
                    else if (item is square square_type)
                    {
                        square_type.square_is_visible = false;
                        square_type.Show(gc, Color.Aquamarine);
                    }
                }
            }
            else if(user_list_is_created)
            {
                foreach (var item in list_massive[1])
                {
                    if (item is ellipse ell_type)
                    {
                        ell_type.ellipse_is_visible = false;
                        ell_type.Show(gc, Color.Aquamarine);
                    }

                    else if (item is circle circ_type)
                    {
                        circ_type.circle_is_visible = false;
                        circ_type.Show(gc, Color.Aquamarine);
                    }

                    else if (item is rectangle rect_type)
                    {
                        rect_type.rectangle_is_visible = false;
                        rect_type.Show(gc, Color.Aquamarine);
                    }
                    else if (item is rhomb rh_type)
                    {
                        rh_type.rhomb_is_visible = false;
                        rh_type.Show(gc, Color.Aquamarine);
                    }
                    else if (item is square square_type)
                    {
                        square_type.square_is_visible = false;
                        square_type.Show(gc, Color.Aquamarine);
                    }
                }
            }
        } //ОЧИСТКА ФИГУР В СПИСКЕ

        private void button12_Click(object sender, EventArgs e)
        {
            if (list_is_created)
            {
                foreach (var item in list_massive[0])
                {
                    if (item is ellipse ell_type)
                    {
                        ell_type.ellipse_is_visible = true;
                        ell_type.Show(gc, Color.Aquamarine);
                    }

                    else if (item is circle circ_type)
                    {
                        circ_type.circle_is_visible = true;
                        circ_type.Show(gc, Color.Aquamarine);
                    }

                    else if (item is rectangle rect_type)
                    {
                        rect_type.rectangle_is_visible = true;
                        rect_type.Show(gc, Color.Aquamarine);
                    }
                    else if (item is rhomb rh_type)
                    {
                        rh_type.rhomb_is_visible = true;
                        rh_type.Show(gc, Color.Aquamarine);
                    }
                    else if (item is square square_type)
                    {
                        square_type.square_is_visible = true;
                        square_type.Show(gc, Color.Aquamarine);
                    }
                }
            }
            else if (user_list_is_created)
            {
                foreach (var item in list_massive[1])
                {
                    if (item is ellipse ell_type)
                    {
                        ell_type.ellipse_is_visible = true;
                        ell_type.Show(gc, Color.Aquamarine);
                    }

                    else if (item is circle circ_type)
                    {
                        circ_type.circle_is_visible = true;
                        circ_type.Show(gc, Color.Aquamarine);
                    }

                    else if (item is rectangle rect_type)
                    {
                        rect_type.rectangle_is_visible = true;
                        rect_type.Show(gc, Color.Aquamarine);
                    }
                    else if (item is rhomb rh_type)
                    {
                        rh_type.rhomb_is_visible = true;
                        rh_type.Show(gc, Color.Aquamarine);
                    }
                    else if (item is square square_type)
                    {
                        square_type.square_is_visible = true;
                        square_type.Show(gc, Color.Aquamarine);
                    }
                }
            }
        } // ПОКАЗ ФИГУР В СПИСКЕ

        private void button14_Click(object sender, EventArgs e)
        {
            if (list_is_created || user_list_is_created)
            {
                MessageBox.Show("Массив уже создан!");
                return;
            }            

            num_of_shapes = int.Parse(textBox2.Text);

            list_massive[1] = new LinkedList(0);            

            text_box_of_list_is_wrote = true;
            user_list_is_created = true;

            MessageBox.Show("Ваш список создан!");
        } // СВОЙ СПИСОК

        private void button15_Click(object sender, EventArgs e)
        {
            if (list_is_created)
            {
                list_massive[0].expansion_of_list(gc = CreateGraphics());
            }
            else if (user_list_is_created)
            {
                list_massive[1].expansion_of_list(gc = CreateGraphics());
            }    
            else
                MessageBox.Show("Вы еще не создали список!");
        }// РАСШИРЕНИЕ СПИСКА

        private void button16_Click(object sender, EventArgs e)
        {
            gc.Clear(Color.White);
            if (list_is_created)
            {
                foreach (var item in list_massive[0])
                {
                    list_massive[0].Remove(item);
                }
            }
            else if (user_list_is_created)
            {
                foreach (var item in list_massive[1])
                {
                    list_massive[1].Remove(item);
                }
            }
            else
            {
                MessageBox.Show("Список еще не создан!");
            }

            text_box_of_list_is_wrote = false;               
            list_is_created = false;
            user_list_is_created = false;
            itr = 0;

            MessageBox.Show("Список уничтожен!");
        }// УНИЧТОЖЕНИЕ СПИСКА

    }
}

