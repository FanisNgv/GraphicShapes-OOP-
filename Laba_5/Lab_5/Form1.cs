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
        string row_name; // для имени элемента в CheckBox

        int cb_for_circ = 0;
        int cb_for_rect = 0; // индекс для фигур в Checkbox
        int cb_for_square = 0;
        int cb_for_ellipse = 0;
        int cb_for_rhomb = 0;
    

        int move_pixels = 10; 

        int for_circ = 0;
        int for_rect = 0; // индексация по массиву
        int for_square = 0;
        int for_ellipse = 0;
        int for_rhomb = 0;


        string[] circ_data;
        int user_circ_x; // координаты, если пользователь сам захочет их ввести
        int user_circ_y;
        int user_circ_R;

        string[] rect_data;
        int user_rect_x;
        int user_rect_y;
        int user_rect_a;
        int user_rect_b;

        string[] square_data;
        int user_square_x;
        int user_square_y;
        int user_square_a;

        string[] ellipse_data;
        int user_ellipse_x;
        int user_ellipse_y;
        int user_ellipse_a;
        int user_ellipse_b;

        string[] rhomb_data;
        int user_rhomb_x;
        int user_rhomb_y;
        int user_rhomb_a;
        int user_rhomb_b;

        Graphics gr;

        static int num_of_circles = 20;
        static int num_of_rectangles = 20;
        static int num_of_squares = 20;
        static int num_of_ellipses = 20;
        static int num_of_rhombes = 20;
        
        circle[] m_circles = new circle[num_of_circles];
        rectangle[] m_rectangles = new rectangle[num_of_rectangles];
        square[] m_squares= new square[num_of_squares];
        ellipse[] m_ellipses = new ellipse[num_of_ellipses];
        rhomb[] m_rhomb = new rhomb[num_of_rhombes];
       
        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = System.Drawing.Color.White;            
        }        
    
        private void button1_Click(object sender, EventArgs e)
            {            
                if (textBox2.Text != "")
                {
                    m_circles[for_circ] =
                    new circle(user_circ_x , user_circ_y ,
                    user_circ_R, true);
                }
                else
                {
                    m_circles[for_circ] = new circle();                 
                }
                m_circles[for_circ].Show(m_circles[for_circ].gc = CreateGraphics(), Color.Aquamarine); //заполнение массива объектов одной группы
                for_circ++;

                MessageBox.Show("Круг успешно создан!");
                row_name = "Круг";
            
                checkedListBox1.Items.Add(row_name + cb_for_circ);
                row_name = "";
                cb_for_circ++;
            }// создание круга
        private void button2_Click(object sender, EventArgs e) // создание прямоугольника
        {
            if (textBox3.Text != "")
            {
                m_rectangles[for_rect] =
                new rectangle(user_rect_x - user_rect_a/2, user_rect_y - user_rect_b/2,
                user_rect_a, user_rect_b, true);
            }
            else
            {
                m_rectangles[for_rect] = new rectangle();
            }
                        
            m_rectangles[for_rect].Show(m_rectangles[for_rect].gc = CreateGraphics(), Color.Aquamarine); //заполнение массива объектов одной группы
            for_rect++;

            MessageBox.Show("Прямоугольник успешно создан!");    
            row_name = "Прямоугольник";
            checkedListBox1.Items.Add(row_name + cb_for_rect);
            row_name = "";
            cb_for_rect++;
        }
        private void button3_Click(object sender, EventArgs e) // создание квадрата
        {
            if (textBox4.Text != "")
            {
                m_squares[for_square] =
                new square(user_square_x - user_square_a / 2, user_square_y - user_square_a / 2,
                user_square_a, user_square_a, true);
            }
            else
            {
                m_squares[for_square] = new square();
            }            
            m_squares[for_square].Show(m_squares[for_square].gc = CreateGraphics(), Color.Aquamarine); //заполнение массива объектов одной группы
            for_square++;

            MessageBox.Show("Квадрат успешно создан!");
            row_name = "Квадрат";
            checkedListBox1.Items.Add(row_name + cb_for_square);
            row_name = "";
            cb_for_square++;
        }
        private void button13_Click(object sender, EventArgs e)
        {
            if (textBox5.Text != "")
            {
                m_ellipses[for_ellipse] = new ellipse(user_ellipse_x , user_ellipse_y ,
                user_ellipse_a, user_ellipse_b, true);
            }
            else
            {
                m_ellipses[for_ellipse] = new ellipse();
            }            
            m_ellipses[for_ellipse].Show(m_ellipses[for_ellipse].gc = CreateGraphics(), Color.Aquamarine); //заполнение массива объектов одной группы
            for_ellipse++;
            MessageBox.Show("Эллипс успешно создан!");
            row_name = "Эллипс";
            checkedListBox1.Items.Add(row_name + cb_for_ellipse);
            row_name = "";
            cb_for_ellipse++;
        }// создание эллипса
        private void button16_Click(object sender, EventArgs e)// создание ромба
        {
            if (textBox6.Text != "")
            {
                m_rhomb[for_rhomb] = new rhomb(user_rhomb_x, user_rhomb_y, user_rhomb_a, user_rhomb_b);
            }
            else 
            {
                m_rhomb[for_rhomb] = new rhomb();
            }           
            m_rhomb[for_rhomb].Show(m_rhomb[for_rhomb].gc = CreateGraphics(), Color.Aquamarine);
            for_rhomb++;
            MessageBox.Show("Ромб создан!");
            row_name = "Ромб";
            checkedListBox1.Items.Add(row_name + cb_for_rhomb);
            row_name = "";
            cb_for_rhomb++;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int k = 0; k < checkedListBox1.Items.Count; k++) // проверка, что есть отмеченные, чтобы не стереть все
            {
                if (checkedListBox1.GetItemChecked(k))
                {
                    foreach (var item in checkedListBox1.Items.OfType<string>().ToList())
                    {
                        if (item.Contains("Круг"))
                        {
                            m_circles[int.Parse(item.Replace("Круг", ""))].gc.Clear(Color.White);
                            break;

                        }
                        else if (item.Contains("Прямоугольник"))
                        {
                            m_rectangles[int.Parse(item.Replace("Прямоугольник", ""))].gc.Clear(Color.White);
                            break;

                        }

                        else if (item.Contains("Квадрат"))
                        {
                            m_squares[int.Parse(item.Replace("Квадрат", ""))].gc.Clear(Color.White);
                            break;
                        }
                        else if (item.Contains("Эллипс"))
                        {
                            m_ellipses[int.Parse(item.Replace("Эллипс", ""))].gc.Clear(Color.White);
                            break;

                        }
                        else if (item.Contains("Ромб"))
                        {
                            m_rhomb[int.Parse(item.Replace("Ромб", ""))].gc.Clear(Color.White);
                            break;

                        }
                    }

                }

            }
            int i = 0;
            int counter = 0;
            bool square_exist = false;

            foreach (var item in checkedListBox1.Items.OfType<string>().ToList())
            {
                if (item.Contains("Квадрат"))
                {
                    square_exist = true;
                    if (checkedListBox1.GetItemChecked(i))
                    {
                        m_squares[int.Parse(item.Replace("Квадрат", ""))].to_double();                        
                        counter++;                        
                    }                    
                    m_squares[int.Parse(item.Replace("Квадрат", ""))].Show(m_squares[int.Parse(item.Replace("Квадрат", ""))].gc = CreateGraphics(), Color.Aquamarine);
                }
                else if (item.Contains("Круг"))
                {                    
                    m_circles[int.Parse(item.Replace("Круг", ""))].Show(m_circles[int.Parse(item.Replace("Круг", ""))].gc = CreateGraphics(), Color.Aquamarine);
                }
                else if (item.Contains("Прямоугольник"))
                {
                    m_rectangles[int.Parse(item.Replace("Прямоугольник", ""))].Show(m_rectangles[int.Parse(item.Replace("Прямоугольник", ""))].gc = CreateGraphics(), Color.Aquamarine);

                }
                else if (item.Contains("Эллипс"))
                {                    
                    m_ellipses[int.Parse(item.Replace("Эллипс", ""))].Show(m_ellipses[int.Parse(item.Replace("Эллипс", ""))].gc = CreateGraphics(), Color.Aquamarine);
                }
                else if (item.Contains("Ромб"))
                {
                    m_rhomb[int.Parse(item.Replace("Ромб", ""))].Show(m_rhomb[int.Parse(item.Replace("Ромб", ""))].gc = CreateGraphics(), Color.Aquamarine);
                }


                i++;
            }


            if (counter == 0)
            {
                MessageBox.Show("Не выбрано ни одного квадрата");
            }

            if (!square_exist)
            {
                MessageBox.Show("Квадраты не созданы!");
            }
            
                
        } // удвоение длины квадрата
        private void button15_Click(object sender, EventArgs e)// поворот эллипса
        {
            for (int k = 0; k < checkedListBox1.Items.Count; k++) // проверка, что есть отмеченные, чтобы не стереть все
            {
                if (checkedListBox1.GetItemChecked(k))
                {
                    foreach (var item in checkedListBox1.Items.OfType<string>().ToList())
                    {
                        if (item.Contains("Круг"))
                        {
                            m_circles[int.Parse(item.Replace("Круг", ""))].gc.Clear(Color.White);
                            break;

                        }
                        else if (item.Contains("Прямоугольник"))
                        {
                            m_rectangles[int.Parse(item.Replace("Прямоугольник", ""))].gc.Clear(Color.White);
                            break;

                        }

                        else if (item.Contains("Квадрат"))
                        {
                            m_squares[int.Parse(item.Replace("Квадрат", ""))].gc.Clear(Color.White);
                            break;
                        }
                        else if (item.Contains("Эллипс"))
                        {
                            m_ellipses[int.Parse(item.Replace("Эллипс", ""))].gc.Clear(Color.White);
                            break;

                        }
                        else if (item.Contains("Ромб"))
                        {
                            m_rhomb[int.Parse(item.Replace("Ромб", ""))].gc.Clear(Color.White);
                            break;

                        }
                    }

                }

            }
            int i = 0;
            int counter = 0;
            bool ellipse_exist = false;

            foreach (var item in checkedListBox1.Items.OfType<string>().ToList())
            {
                if (item.Contains("Эллипс"))
                {
                    ellipse_exist = true;
                    if (checkedListBox1.GetItemChecked(i))
                    {
                        m_ellipses[int.Parse(item.Replace("Эллипс", ""))].rotate_for_90();
                        counter++;
                    }
                    m_ellipses[int.Parse(item.Replace("Эллипс", ""))].Show(m_ellipses[int.Parse(item.Replace("Эллипс", ""))].gc = CreateGraphics(), Color.Aquamarine);
                }
                else if (item.Contains("Круг"))
                {
                    m_circles[int.Parse(item.Replace("Круг", ""))].Show(m_circles[int.Parse(item.Replace("Круг", ""))].gc = CreateGraphics(), Color.Aquamarine);
                }
                else if (item.Contains("Прямоугольник"))
                {
                    m_rectangles[int.Parse(item.Replace("Прямоугольник", ""))].Show(m_rectangles[int.Parse(item.Replace("Прямоугольник", ""))].gc = CreateGraphics(), Color.Aquamarine);

                }
                else if (item.Contains("Квадрат"))
                {
                    m_squares[int.Parse(item.Replace("Квадрат", ""))].Show(m_squares[int.Parse(item.Replace("Квадрат", ""))].gc = CreateGraphics(), Color.Aquamarine);
                }
                else if (item.Contains("Ромб"))
                {
                    m_rhomb[int.Parse(item.Replace("Ромб", ""))].Show(m_rhomb[int.Parse(item.Replace("Ромб", ""))].gc = CreateGraphics(), Color.Aquamarine);
                }


                i++;
            }


            if (counter == 0)
            {
                MessageBox.Show("Не выбрано ни одного эллипса");
            }

            if (!ellipse_exist)
            {
                MessageBox.Show("Эллипсы не созданы!");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int k = 0; k < checkedListBox1.Items.Count; k++) // проверка, что есть отмеченные, чтобы не стереть все
            {
                if (checkedListBox1.GetItemChecked(k))
                {
                    foreach (var item in checkedListBox1.Items.OfType<string>().ToList())
                    {
                        if (item.Contains("Круг"))
                        {
                            m_circles[int.Parse(item.Replace("Круг", ""))].gc.Clear(Color.White);
                            break;
                        }
                        else if (item.Contains("Прямоугольник"))
                        {
                            m_rectangles[int.Parse(item.Replace("Прямоугольник", ""))].gc.Clear(Color.White);
                            break;
                        }

                        else if (item.Contains("Квадрат"))
                        {
                            m_squares[int.Parse(item.Replace("Квадрат", ""))].gc.Clear(Color.White);
                            break;
                        }
                        else if (item.Contains("Эллипс"))
                        {
                            m_ellipses[int.Parse(item.Replace("Эллипс", ""))].gc.Clear(Color.White);
                            break;
                        }
                        else if (item.Contains("Ромб"))
                        {
                            m_rhomb[int.Parse(item.Replace("Ромб", ""))].gc.Clear(Color.White);
                            break;
                        }
                    }
                }

            }
            int i = 0;

            foreach (var item in checkedListBox1.Items.OfType<string>().ToList())
            {
                if (item.Contains("Круг"))
                {
                    if (checkedListBox1.GetItemChecked(i))
                    {
                        m_circles[int.Parse(item.Replace("Круг", ""))].circle_is_visible = false;
                        checkedListBox1.Items[i] = "Удалено";

                    }
                    m_circles[int.Parse(item.Replace("Круг", ""))].Show(m_circles[int.Parse(item.Replace("Круг", ""))].gc = CreateGraphics(), Color.Aquamarine);

                }
                else if (item.Contains("Прямоугольник"))
                {
                    if (checkedListBox1.GetItemChecked(i))
                    {
                        m_rectangles[int.Parse(item.Replace("Прямоугольник", ""))].rectangle_is_visible = false;
                        checkedListBox1.Items[i] = "Удалено";
                    }
                    m_rectangles[int.Parse(item.Replace("Прямоугольник", ""))].Show(m_rectangles[int.Parse(item.Replace("Прямоугольник", ""))].gc = CreateGraphics(), Color.Aquamarine);

                }

                else if (item.Contains("Квадрат"))
                {

                    if (checkedListBox1.GetItemChecked(i))
                    {
                        m_squares[int.Parse(item.Replace("Квадрат", ""))].square_is_visible = false;
                        checkedListBox1.Items[i] = "Удалено";
                    }
                    m_squares[int.Parse(item.Replace("Квадрат", ""))].Show(m_squares[int.Parse(item.Replace("Квадрат", ""))].gc = CreateGraphics(), Color.Aquamarine);


                }
                else if (item.Contains("Эллипс"))
                {

                    if (checkedListBox1.GetItemChecked(i))
                    {
                        m_ellipses[int.Parse(item.Replace("Эллипс", ""))].ellipse_is_visible = false;
                        checkedListBox1.Items[i] = "Удалено";
                    }
                    m_ellipses[int.Parse(item.Replace("Эллипс", ""))].Show(m_ellipses[int.Parse(item.Replace("Эллипс", ""))].gc = CreateGraphics(), Color.Aquamarine);

                }
                else if (item.Contains("Ромб"))
                {

                    if (checkedListBox1.GetItemChecked(i))
                    {
                        m_rhomb[int.Parse(item.Replace("Ромб", ""))].rhomb_is_visible = false;
                        checkedListBox1.Items[i] = "Удалено";
                    }
                    m_rhomb[int.Parse(item.Replace("Ромб", ""))].Show(m_rhomb[int.Parse(item.Replace("Ромб", ""))].gc = CreateGraphics(), Color.Aquamarine);

                }
                i++;
            }
        }  // очистка

        private void button8_Click(object sender, EventArgs e)
        {
            for (int k = 0; k < checkedListBox1.Items.Count; k++) // проверка, что есть отмеченные, чтобы не стереть все
            {
                if (checkedListBox1.GetItemChecked(k))
                {
                    foreach (var item in checkedListBox1.Items.OfType<string>().ToList())
                    {
                        if (item.Contains("Круг"))
                        {
                            m_circles[int.Parse(item.Replace("Круг", ""))].gc.Clear(Color.White);
                            break;

                        }
                        else if (item.Contains("Прямоугольник"))
                        {
                            m_rectangles[int.Parse(item.Replace("Прямоугольник", ""))].gc.Clear(Color.White);
                            break;

                        }

                        else if (item.Contains("Квадрат"))
                        {
                            m_squares[int.Parse(item.Replace("Квадрат", ""))].gc.Clear(Color.White);
                            break;
                        }
                        else if (item.Contains("Эллипс"))
                        {
                            m_ellipses[int.Parse(item.Replace("Эллипс", ""))].gc.Clear(Color.White);
                            break;

                        }
                        else if (item.Contains("Ромб"))
                        {
                            m_rhomb[int.Parse(item.Replace("Ромб", ""))].gc.Clear(Color.White);
                            break;

                        }
                    }                       
                }

            }
            int i = 0;

            foreach (var item in checkedListBox1.Items.OfType<string>().ToList())
            {
                if (item.Contains("Круг"))
                {                    
                    
                    if (checkedListBox1.GetItemChecked(i))
                    {
                        m_circles[int.Parse(item.Replace("Круг", ""))].Move(move_pixels, 0);
                    }

                    m_circles[int.Parse(item.Replace("Круг", ""))].Show(m_circles[int.Parse(item.Replace("Круг", ""))].gc = CreateGraphics(), Color.Aquamarine);
                                                

                    
                }
                else if (item.Contains("Прямоугольник"))
                {
                    
                    
                    if (checkedListBox1.GetItemChecked(i))
                    {
                        m_rectangles[int.Parse(item.Replace("Прямоугольник", ""))].Move(move_pixels, 0);
                    }
                    m_rectangles[int.Parse(item.Replace("Прямоугольник", ""))].Show(m_rectangles[int.Parse(item.Replace("Прямоугольник", ""))].gc = CreateGraphics(), Color.Aquamarine);
                                               
                    
                }

                else if (item.Contains("Квадрат"))
                {               
                    
                    if (checkedListBox1.GetItemChecked(i))
                    {
                        m_squares[int.Parse(item.Replace("Квадрат", ""))].Move(move_pixels, 0);
                    }
                    m_squares[int.Parse(item.Replace("Квадрат", ""))].Show(m_squares[int.Parse(item.Replace("Квадрат", ""))].gc = CreateGraphics(), Color.Aquamarine);
                                           
                }
                else if (item.Contains("Эллипс"))
                {

                    if (checkedListBox1.GetItemChecked(i))
                    {
                        m_ellipses[int.Parse(item.Replace("Эллипс", ""))].Move(move_pixels, 0);
                    }
                    m_ellipses[int.Parse(item.Replace("Эллипс", ""))].Show(m_ellipses[int.Parse(item.Replace("Эллипс", ""))].gc = CreateGraphics(), Color.Aquamarine);

                }
                else if (item.Contains("Ромб"))
                {

                    if (checkedListBox1.GetItemChecked(i))
                    {
                        m_rhomb[int.Parse(item.Replace("Ромб", ""))].MoveRhomb(move_pixels, 0);
                    }
                    m_rhomb[int.Parse(item.Replace("Ромб", ""))].Show(m_rhomb[int.Parse(item.Replace("Ромб", ""))].gc = CreateGraphics(), Color.Aquamarine);

                }

                i++;
            }


        } // сдвиг вправо

        private void button7_Click(object sender, EventArgs e)
        {
            for (int k = 0; k < checkedListBox1.Items.Count; k++) // проверка, что есть отмеченные, чтобы не стереть все
            {
                if (checkedListBox1.GetItemChecked(k))
                {
                    foreach (var item in checkedListBox1.Items.OfType<string>().ToList())
                    {
                        if (item.Contains("Круг"))
                        {
                            m_circles[int.Parse(item.Replace("Круг", ""))].gc.Clear(Color.White);
                            break;

                        }
                        else if (item.Contains("Прямоугольник"))
                        {
                            m_rectangles[int.Parse(item.Replace("Прямоугольник", ""))].gc.Clear(Color.White);
                            break;

                        }

                        else if (item.Contains("Квадрат"))
                        {
                            m_squares[int.Parse(item.Replace("Квадрат", ""))].gc.Clear(Color.White);
                            break;
                        }
                        else if (item.Contains("Эллипс"))
                        {
                            m_ellipses[int.Parse(item.Replace("Эллипс", ""))].gc.Clear(Color.White);
                            break;

                        }
                        else if (item.Contains("Ромб"))
                        {
                            m_rhomb[int.Parse(item.Replace("Ромб", ""))].gc.Clear(Color.White);
                            break;

                        }
                    }
                }
            }

            int i = 0;

            foreach (var item in checkedListBox1.Items.OfType<string>().ToList())
            {
                if (item.Contains("Круг"))
                {

                    if (checkedListBox1.GetItemChecked(i))
                    {
                        m_circles[int.Parse(item.Replace("Круг", ""))].Move(-move_pixels, 0);
                    }

                    m_circles[int.Parse(item.Replace("Круг", ""))].Show(m_circles[int.Parse(item.Replace("Круг", ""))].gc = CreateGraphics(), Color.Aquamarine);



                }
                else if (item.Contains("Прямоугольник"))
                {


                    if (checkedListBox1.GetItemChecked(i))
                    {
                        m_rectangles[int.Parse(item.Replace("Прямоугольник", ""))].Move(-move_pixels, 0);
                    }
                    m_rectangles[int.Parse(item.Replace("Прямоугольник", ""))].Show(m_rectangles[int.Parse(item.Replace("Прямоугольник", ""))].gc = CreateGraphics(), Color.Aquamarine);


                }

                else if (item.Contains("Квадрат"))
                {

                    if (checkedListBox1.GetItemChecked(i))
                    {
                        m_squares[int.Parse(item.Replace("Квадрат", ""))].Move(-move_pixels, 0);
                    }
                    m_squares[int.Parse(item.Replace("Квадрат", ""))].Show(m_squares[int.Parse(item.Replace("Квадрат", ""))].gc = CreateGraphics(), Color.Aquamarine);

                }
                else if (item.Contains("Эллипс"))
                {

                    if (checkedListBox1.GetItemChecked(i))
                    {
                        m_ellipses[int.Parse(item.Replace("Эллипс", ""))].Move(-move_pixels, 0);
                    }
                    m_ellipses[int.Parse(item.Replace("Эллипс", ""))].Show(m_ellipses[int.Parse(item.Replace("Эллипс", ""))].gc = CreateGraphics(), Color.Aquamarine);

                }
                else if (item.Contains("Ромб"))
                {

                    if (checkedListBox1.GetItemChecked(i))
                    {
                        m_rhomb[int.Parse(item.Replace("Ромб", ""))].MoveRhomb(-move_pixels, 0);
                    }
                    m_rhomb[int.Parse(item.Replace("Ромб", ""))].Show(m_rhomb[int.Parse(item.Replace("Ромб", ""))].gc = CreateGraphics(), Color.Aquamarine);

                }

                i++;
            }
        } // сдвиг влево

        private void button9_Click(object sender, EventArgs e)
        {
            for (int k = 0; k < checkedListBox1.Items.Count; k++) // проверка, что есть отмеченные, чтобы не стереть все
            {
                if (checkedListBox1.GetItemChecked(k))
                {
                    foreach (var item in checkedListBox1.Items.OfType<string>().ToList())
                    {
                        if (item.Contains("Круг"))
                        {
                            m_circles[int.Parse(item.Replace("Круг", ""))].gc.Clear(Color.White);
                            break;

                        }
                        else if (item.Contains("Прямоугольник"))
                        {
                            m_rectangles[int.Parse(item.Replace("Прямоугольник", ""))].gc.Clear(Color.White);
                            break;

                        }

                        else if (item.Contains("Квадрат"))
                        {
                            m_squares[int.Parse(item.Replace("Квадрат", ""))].gc.Clear(Color.White);
                            break;
                        }
                        else if (item.Contains("Эллипс"))
                        {
                            m_ellipses[int.Parse(item.Replace("Эллипс", ""))].gc.Clear(Color.White);
                            break;

                        }
                        else if (item.Contains("Ромб"))
                        {
                            m_rhomb[int.Parse(item.Replace("Ромб", ""))].gc.Clear(Color.White);
                            break;

                        }
                    }
                }
            }
            int i = 0;

            foreach (var item in checkedListBox1.Items.OfType<string>().ToList())
            {
                if (item.Contains("Круг"))
                {

                    if (checkedListBox1.GetItemChecked(i))
                    {
                        m_circles[int.Parse(item.Replace("Круг", ""))].Move(0, move_pixels);
                    }

                    m_circles[int.Parse(item.Replace("Круг", ""))].Show(m_circles[int.Parse(item.Replace("Круг", ""))].gc = CreateGraphics(), Color.Aquamarine);



                }
                else if (item.Contains("Прямоугольник"))
                {


                    if (checkedListBox1.GetItemChecked(i))
                    {
                        m_rectangles[int.Parse(item.Replace("Прямоугольник", ""))].Move(0, move_pixels);
                    }
                    m_rectangles[int.Parse(item.Replace("Прямоугольник", ""))].Show(m_rectangles[int.Parse(item.Replace("Прямоугольник", ""))].gc = CreateGraphics(), Color.Aquamarine);


                }

                else if (item.Contains("Квадрат"))
                {

                    if (checkedListBox1.GetItemChecked(i))
                    {
                        m_squares[int.Parse(item.Replace("Квадрат", ""))].Move(0, move_pixels);
                    }
                    m_squares[int.Parse(item.Replace("Квадрат", ""))].Show(m_squares[int.Parse(item.Replace("Квадрат", ""))].gc = CreateGraphics(), Color.Aquamarine);

                }
                else if (item.Contains("Эллипс"))
                {

                    if (checkedListBox1.GetItemChecked(i))
                    {
                        m_ellipses[int.Parse(item.Replace("Эллипс", ""))].Move(0, move_pixels);
                    }
                    m_ellipses[int.Parse(item.Replace("Эллипс", ""))].Show(m_ellipses[int.Parse(item.Replace("Эллипс", ""))].gc = CreateGraphics(), Color.Aquamarine);

                }
                else if (item.Contains("Ромб"))
                {

                    if (checkedListBox1.GetItemChecked(i))
                    {
                        m_rhomb[int.Parse(item.Replace("Ромб", ""))].MoveRhomb(0, move_pixels);
                    }
                    m_rhomb[int.Parse(item.Replace("Ромб", ""))].Show(m_rhomb[int.Parse(item.Replace("Ромб", ""))].gc = CreateGraphics(), Color.Aquamarine);

                }

                i++;
            }
        } // сдвиг вниз

        private void button6_Click(object sender, EventArgs e)
        {
            for (int k = 0; k < checkedListBox1.Items.Count; k++) // проверка, что есть отмеченные, чтобы не стереть все
            {
                if (checkedListBox1.GetItemChecked(k))
                {
                    foreach (var item in checkedListBox1.Items.OfType<string>().ToList())
                    {
                        if (item.Contains("Круг"))
                        {
                            m_circles[int.Parse(item.Replace("Круг", ""))].gc.Clear(Color.White);
                            break;

                        }
                        else if (item.Contains("Прямоугольник"))
                        {
                            m_rectangles[int.Parse(item.Replace("Прямоугольник", ""))].gc.Clear(Color.White);
                            break;

                        }

                        else if (item.Contains("Квадрат"))
                        {
                            m_squares[int.Parse(item.Replace("Квадрат", ""))].gc.Clear(Color.White);
                            break;
                        }
                        else if (item.Contains("Эллипс"))
                        {
                            m_ellipses[int.Parse(item.Replace("Эллипс", ""))].gc.Clear(Color.White);
                            break;

                        }
                        else if (item.Contains("Ромб"))
                        {
                            m_rhomb[int.Parse(item.Replace("Ромб", ""))].gc.Clear(Color.White);
                            break;

                        }
                    }
                }
            }
            int i = 0;

            foreach (var item in checkedListBox1.Items.OfType<string>().ToList())
            {
                if (item.Contains("Круг"))
                {

                    if (checkedListBox1.GetItemChecked(i))
                    {
                        m_circles[int.Parse(item.Replace("Круг", ""))].Move(0, -move_pixels);
                    }

                    m_circles[int.Parse(item.Replace("Круг", ""))].Show(m_circles[int.Parse(item.Replace("Круг", ""))].gc = CreateGraphics(), Color.Aquamarine);



                }
                else if (item.Contains("Прямоугольник"))
                {


                    if (checkedListBox1.GetItemChecked(i))
                    {
                        m_rectangles[int.Parse(item.Replace("Прямоугольник", ""))].Move(0, -move_pixels);
                    }
                    m_rectangles[int.Parse(item.Replace("Прямоугольник", ""))].Show(m_rectangles[int.Parse(item.Replace("Прямоугольник", ""))].gc = CreateGraphics(), Color.Aquamarine);


                }

                else if (item.Contains("Квадрат"))
                {

                    if (checkedListBox1.GetItemChecked(i))
                    {
                        m_squares[int.Parse(item.Replace("Квадрат", ""))].Move(0, -move_pixels);
                    }
                    m_squares[int.Parse(item.Replace("Квадрат", ""))].Show(m_squares[int.Parse(item.Replace("Квадрат", ""))].gc = CreateGraphics(), Color.Aquamarine);

                }
                else if (item.Contains("Эллипс"))
                {

                    if (checkedListBox1.GetItemChecked(i))
                    {
                        m_ellipses[int.Parse(item.Replace("Эллипс", ""))].Move(0, -move_pixels);
                    }
                    m_ellipses[int.Parse(item.Replace("Эллипс", ""))].Show(m_ellipses[int.Parse(item.Replace("Эллипс", ""))].gc = CreateGraphics(), Color.Aquamarine);

                }
                else if (item.Contains("Ромб"))
                {

                    if (checkedListBox1.GetItemChecked(i))
                    {
                        m_rhomb[int.Parse(item.Replace("Ромб", ""))].MoveRhomb(0, -move_pixels);
                    }
                    m_rhomb[int.Parse(item.Replace("Ромб", ""))].Show(m_rhomb[int.Parse(item.Replace("Ромб", ""))].gc = CreateGraphics(), Color.Aquamarine);

                }

                i++;
            }
        } // сдвиг вверх

        private void textBox1_TextChanged(object sender, EventArgs e) // сдвиг по пикселям
        {
            if (textBox1.Text == "")
                move_pixels = 10;
            else
            {                
                move_pixels = int.Parse(textBox1.Text);
            }

        }        

        private void button10_Click(object sender, EventArgs e)
        {
            
            try
            {
                circ_data = textBox2.Text.Split(' ');
                user_circ_x = int.Parse(circ_data[0]);
                user_circ_y = int.Parse(circ_data[1]);
                user_circ_R = int.Parse(circ_data[2]);
            }
            catch
            {
                MessageBox.Show("Возникла ошибка");
            }

        } // задание значений кругу        

        private void button11_Click(object sender, EventArgs e) // задание значений для прямо-ка
        {

            try
            {
                rect_data = textBox3.Text.Split(' ');
                user_rect_x = int.Parse(rect_data[0]);
                user_rect_y = int.Parse(rect_data[1]);
                user_rect_a = int.Parse(rect_data[2]);
                user_rect_b = int.Parse(rect_data[3]);
            }
            catch
            {
                MessageBox.Show("Возникла ошибка");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                square_data = textBox4.Text.Split(' ');
                user_square_x = int.Parse(square_data[0]);
                user_square_y = int.Parse(square_data[1]);
                user_square_a = int.Parse(square_data[2]);
                
            }
            catch
            {
                MessageBox.Show("Возникла ошибка");
            }
        } // задание значений квадрата

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                ellipse_data = textBox5.Text.Split(' ');
                user_ellipse_x = int.Parse(ellipse_data[0]);
                user_ellipse_y = int.Parse(ellipse_data[1]);
                user_ellipse_a = int.Parse(ellipse_data[2]);
                user_ellipse_b = int.Parse(ellipse_data[3]);
            }
            catch
            {
                MessageBox.Show("Возникла ошибка");
            }
        }// задание значений для эллипса

        private void button17_Click(object sender, EventArgs e)// задание значений для ромба
        {
            try
            {
                rhomb_data = textBox6.Text.Split(' ');
                user_rhomb_x = int.Parse(rhomb_data[0]);
                user_rhomb_y = int.Parse(rhomb_data[1]);
                user_rhomb_a = int.Parse(rhomb_data[2]);
                user_rhomb_b = int.Parse(rhomb_data[3]);
            }
            catch
            {
                MessageBox.Show("Возникла ошибка");
            }
        }
    }
}
