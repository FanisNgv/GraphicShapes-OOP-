using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;
using ClassLibrary_1;

namespace MyLab1
{

     class  Massive_container
    {
        int iterator = 0;
        bool for_iterator = false;


        static int user_iterator = 0;
        
        static int num_of_variant = 27;
        int old_num_variant = num_of_variant;

        int num = Form1.num_of_shapes;
        

        static bool massive_is_created = false;
        static bool user_massive_is_created = false;        

        Random my_rnd = new Random();

        private Abstract_properties[][] massive_of_massives = new Abstract_properties[15][];         
                
        public Massive_container() 
        { 
            if (massive_is_created)
            {                
                return;
            }

            massive_of_massives[0] = new Abstract_properties[num_of_variant];

            int my_rand = my_rnd.Next(1, 50);

            for (int i = 0; i < num_of_variant; i++)
            {
                if (my_rand >= 1 && my_rand < 11)
                {
                    massive_of_massives[0][i] = new circle();
                }
                else if (my_rand >= 11 && my_rand < 21)
                {
                    massive_of_massives[0][i] = new ellipse();
                }
                else if (my_rand >= 21 && my_rand < 31)
                {
                    massive_of_massives[0][i] = new rectangle();
                }
                else if (my_rand >= 31 && my_rand < 41)
                {
                    massive_of_massives[0][i] = new square();
                }
                else if (my_rand >= 41 && my_rand < 51)
                {
                    massive_of_massives[0][i] = new rhomb();
                }

                my_rand = my_rnd.Next(1, 50);
                Thread.Sleep(10);
            }
            massive_is_created = true;
            System.Windows.Forms.MessageBox.Show("Массив создан!");
        }// СОЗДАНИЕ МАССИВА СО СЛУЧАЙНЫМИ ФИГУРАМИ

        public Massive_container(int n)
        {
            if (massive_is_created)
            {
                return;
            }

            massive_of_massives[0] = new Abstract_properties[n];

            for (int i = 0; i < n; i++)
            {
                massive_of_massives[0][i] = null;
            }

            massive_is_created = true;
            user_massive_is_created = true;

        }// КОНСТРУКТОР ДЛЯ СОЗДАНИЯ ПУСТОГО МАССИВА

        public void iterator_for_show(Graphics gr)
        {
            if (!massive_is_created)
            {
                System.Windows.Forms.MessageBox.Show("Массив еще не создан!");
                return;
            }
            
            else
            {
                if (!for_iterator)
                {
                    for (int i = 0; i < massive_of_massives[iterator].Length; i++)
                    {
                        if (massive_of_massives[iterator][i] is ellipse ell_type)
                        {
                            ell_type.ellipse_is_visible = true;
                            ell_type.Show(gr, Color.Aquamarine);
                        }

                        else if (massive_of_massives[iterator][i] is circle circ_type)
                        {

                            circ_type.circle_is_visible = true;
                            circ_type.Show(gr, Color.Aquamarine);
                        }

                        else if (massive_of_massives[iterator][i] is rectangle rect_type)
                        {

                            rect_type.rectangle_is_visible = true;
                            rect_type.Show(gr, Color.Aquamarine);
                        }
                        else if (massive_of_massives[iterator][i] is rhomb rh_type)
                        {

                            rh_type.rhomb_is_visible = true;
                            rh_type.Show(gr, Color.Aquamarine);
                        }
                        else if (massive_of_massives[iterator][i] is square square_type)
                        {

                            square_type.square_is_visible = true;
                            square_type.Show(gr, Color.Aquamarine);
                        }
                    }
                }
                else
                {

                    for (int i = 0; i < massive_of_massives[iterator+1].Length; i++)
                    {
                        if (massive_of_massives[iterator + 1][i] is ellipse ell_type)
                        {
                            ell_type.ellipse_is_visible = true;
                            ell_type.Show(gr, Color.Aquamarine);
                        }

                        else if (massive_of_massives[iterator + 1][i] is circle circ_type)
                        {

                            circ_type.circle_is_visible = true;
                            circ_type.Show(gr, Color.Aquamarine);
                        }

                        else if (massive_of_massives[iterator + 1][i] is rectangle rect_type)
                        {

                            rect_type.rectangle_is_visible = true;
                            rect_type.Show(gr, Color.Aquamarine);
                        }
                        else if (massive_of_massives[iterator + 1][i] is rhomb rh_type)
                        {

                            rh_type.rhomb_is_visible = true;
                            rh_type.Show(gr, Color.Aquamarine);
                        }
                        else if (massive_of_massives[iterator + 1][i] is square square_type)
                        {

                            square_type.square_is_visible = true;
                            square_type.Show(gr, Color.Aquamarine);
                        }
                    }
                }
            }
            
        } // ПОКАЗ ФИГУР

        public void iterator_for_delete(Graphics gr)
        {
            if (!massive_is_created)
            {
                System.Windows.Forms.MessageBox.Show("Массив еще не создан!");
                return;
            }
            gr.Clear(Color.White);
            
            
            for (int i = 0; i < massive_of_massives[iterator].Length; i++)
            {
                if (massive_of_massives[iterator][i] is ellipse ell_type)
                {

                    ell_type.ellipse_is_visible = false;
                    ell_type.Show(gr, Color.Aquamarine);
                }

                else if (massive_of_massives[iterator][i] is circle circ_type)
                {

                    circ_type.circle_is_visible = false;
                    circ_type.Show(gr, Color.Aquamarine);
                }

                else if (massive_of_massives[iterator][i] is rectangle rect_type)
                {

                    rect_type.rectangle_is_visible = false;
                    rect_type.Show(gr, Color.Aquamarine);
                }
                else if (massive_of_massives[iterator][i] is rhomb rh_type)
                {

                    rh_type.rhomb_is_visible = false;
                    rh_type.Show(gr, Color.Aquamarine);
                }
                else if (massive_of_massives[iterator][i] is square square_type)
                {

                    square_type.square_is_visible = false;
                    square_type.Show(gr, Color.Aquamarine);
                }
            }
            
            
        } // УДАЛЕНИЕ

        public void iterator_for_move(int x, int y, Graphics gr)
        {
            if (!massive_is_created)
            {
                System.Windows.Forms.MessageBox.Show("Массив еще не создан!");
                return;
            }
            gr.Clear(Color.White);
            
            
            if (!for_iterator)
            {
                for (int i = 0; i < massive_of_massives[iterator].Length; i++)
                {
                    if (massive_of_massives[iterator][i] is ellipse ell_type)
                    {
                        ell_type.Move(x, y);
                        ell_type.ellipse_is_visible = true;
                        ell_type.Show(gr, Color.Aquamarine);
                    }

                    else if (massive_of_massives[iterator][i] is circle circ_type)
                    {
                        circ_type.Move(x, y);
                        circ_type.circle_is_visible = true;
                        circ_type.Show(gr, Color.Aquamarine);
                    }

                    else if (massive_of_massives[iterator][i] is rectangle rect_type)
                    {
                        rect_type.Move(x, y);
                        rect_type.rectangle_is_visible = true;
                        rect_type.Show(gr, Color.Aquamarine);
                    }
                    else if (massive_of_massives[iterator][i] is rhomb rh_type)
                    {
                        rh_type.Move(x, y);
                        rh_type.rhomb_is_visible = true;
                        rh_type.Show(gr, Color.Aquamarine);
                    }
                    else if (massive_of_massives[iterator][i] is square square_type)
                    {
                        square_type.Move(x, y);
                        square_type.square_is_visible = true;
                        square_type.Show(gr, Color.Aquamarine);
                    }
                }
            }
            else
            {
                for (int i = 0; i < massive_of_massives[iterator+1].Length; i++)
                {
                    if (massive_of_massives[iterator+1][i] is ellipse ell_type)
                    {
                        ell_type.Move(x, y);
                        ell_type.ellipse_is_visible = true;
                        ell_type.Show(gr, Color.Aquamarine);
                    }

                    else if (massive_of_massives[iterator+1][i] is circle circ_type)
                    {
                        circ_type.Move(x, y);
                        circ_type.circle_is_visible = true;
                        circ_type.Show(gr, Color.Aquamarine);
                    }

                    else if (massive_of_massives[iterator+1][i] is rectangle rect_type)
                    {
                        rect_type.Move(x, y);
                        rect_type.rectangle_is_visible = true;
                        rect_type.Show(gr, Color.Aquamarine);
                    }
                    else if (massive_of_massives[iterator+1][i] is rhomb rh_type)
                    {
                        rh_type.Move(x, y);
                        rh_type.rhomb_is_visible = true;
                        rh_type.Show(gr, Color.Aquamarine);
                    }
                    else if (massive_of_massives[iterator+1][i] is square square_type)
                    {
                        square_type.Move(x, y);
                        square_type.square_is_visible = true;
                        square_type.Show(gr, Color.Aquamarine);
                    }
                }
            }
            
            
            
        } // ПЕРЕМЕЩЕНИЕ

        public void expansion_of_massive(Graphics gr)
        {


            if (!massive_is_created)
            {
                System.Windows.Forms.MessageBox.Show("Массив еще не создан!");
                return;
            }

            if (user_massive_is_created)
            {
                if (user_iterator < Form1.num_of_shapes)
                {                                                 

                    int my_rand_1 = my_rnd.Next(1, 50);

                    if (my_rand_1 >= 1 && my_rand_1 < 11)
                    {
                        massive_of_massives[iterator][user_iterator] = new circle();
                    }
                    else if (my_rand_1 >= 11 && my_rand_1 < 21)
                    {
                        massive_of_massives[iterator][user_iterator] = new ellipse();
                    }
                    else if (my_rand_1 >= 21 && my_rand_1 < 31)
                    {
                        massive_of_massives[iterator][user_iterator] = new rectangle();
                    }
                    else if (my_rand_1 >= 31 && my_rand_1 < 41)
                    {
                        massive_of_massives[iterator][user_iterator] = new square();
                    }
                    else if (my_rand_1 >= 41 && my_rand_1 < 51)
                    {
                        massive_of_massives[iterator][user_iterator] = new rhomb();
                    }

                    massive_of_massives[iterator][user_iterator].Show(gr, Color.Aquamarine);                  


                    user_iterator++;

                }
                else
                {
                    if (user_iterator == num)
                    {
                        System.Windows.Forms.MessageBox.Show("Массив переполнен! Добавил 10%");

                        if (num*0.1 < 1)
                        {
                            num++;
                        }
                        else
                        {
                            num = (int)(num + num * 0.1);
                        }
                        

                        if (for_iterator)
                            iterator++;
                        for_iterator = true;

                        massive_of_massives[iterator + 1] = new Abstract_properties[num];


                        for (int i = 0; i < massive_of_massives[iterator].Length; i++)
                        {
                            massive_of_massives[iterator + 1][i] = massive_of_massives[iterator][i];
                        }
                    }

                    int my_rand = my_rnd.Next(1, 50);
                    Thread.Sleep(100);

                    if (my_rand >= 1 && my_rand < 11)
                    {
                        massive_of_massives[iterator + 1][user_iterator-1] = new circle();
                    }
                    else if (my_rand >= 11 && my_rand < 21)
                    {
                        massive_of_massives[iterator + 1][user_iterator-1] = new ellipse();
                    }
                    else if (my_rand >= 21 && my_rand < 31)
                    {
                        massive_of_massives[iterator + 1][user_iterator-1] = new rectangle();
                    }
                    else if (my_rand >= 31 && my_rand < 41)
                    {
                        massive_of_massives[iterator + 1][user_iterator-1] = new square();
                    }
                    else if (my_rand >= 41 && my_rand < 51)
                    {
                        massive_of_massives[iterator + 1][user_iterator-1] = new rhomb();
                    }

                    massive_of_massives[iterator + 1][user_iterator-1].Show(gr, Color.Aquamarine);

                    user_iterator++;

                }
            }
            else
            {

                if (old_num_variant == num_of_variant)
                {
                    System.Windows.Forms.MessageBox.Show("Массив переполнен! Добавил 10%");
                    if (num_of_variant * 0.1 < 1)
                    {
                        num_of_variant++;
                    }
                    else
                    {
                        num_of_variant = (int)(num_of_variant + num_of_variant * 0.1);
                    }
                    

                    if (for_iterator)
                        iterator++;
                    for_iterator = true;

                    massive_of_massives[iterator + 1] = new Abstract_properties[num_of_variant];


                    for (int i = 0; i < old_num_variant; i++)
                    {
                        massive_of_massives[iterator + 1][i] = massive_of_massives[iterator][i];
                    }
                }



                int my_rand = my_rnd.Next(1, 50);
                Thread.Sleep(100);



                if (my_rand >= 1 && my_rand < 11)
                {
                    massive_of_massives[iterator + 1][old_num_variant] = new circle();
                }
                else if (my_rand >= 11 && my_rand < 21)
                {
                    massive_of_massives[iterator + 1][old_num_variant] = new ellipse();
                }
                else if (my_rand >= 21 && my_rand < 31)
                {
                    massive_of_massives[iterator + 1][old_num_variant] = new rectangle();
                }
                else if (my_rand >= 31 && my_rand < 41)
                {
                    massive_of_massives[iterator + 1][old_num_variant] = new square();
                }
                else if (my_rand >= 41 && my_rand < 51)
                {
                    massive_of_massives[iterator + 1][old_num_variant] = new rhomb();
                }

                massive_of_massives[iterator + 1][old_num_variant].Show(gr, Color.Aquamarine);

                old_num_variant++;
            }            
            
        } 
        
        public void collapsing_massive(Graphics gc)
        {
           


            try
            {
                gc.Clear(Color.White);
                for (int i = 0; i < 15; i++)
                {
                    for (int j = 0; j < 40; i++)
                    {
                        massive_of_massives[i][j] = null;
                    }
                }
            }
            catch
            {

            }
            
            iterator = 0;
            for_iterator = false;


            user_iterator = 0;

            
            massive_is_created = false;
            user_massive_is_created = false;
            System.Windows.Forms.MessageBox.Show("Массив уничтожен!");

        }
    }
}
