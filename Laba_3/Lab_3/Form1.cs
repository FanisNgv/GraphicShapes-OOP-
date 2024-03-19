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


namespace MyLab1
{  

    public partial class Form1 : Form // пытаюсь все испортить
    {        
        string row_name; // для имени элемента в CheckBox

        int cb_for_circ = 0;
        int cb_for_rect = 0; // индекс для фигур в Checkbox
        int cb_for_square = 0;
        int cb_for_ring = 0;
        int cb_for_frame = 0;

        int move_pixels = 10; 

        int for_circ = 0;
        int for_rect = 0; // индексация по массиву
        int for_square = 0;
        int for_ring = 0;
        int for_frame = 0;

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

        string[] ring_data;
        int user_ring_x; 
        int user_ring_y;
        int user_ring_R;
        int user_ring_a;

        string[] frame_data;
        int user_frame_x;
        int user_frame_y;
        int user_frame_a;
        int user_frame_b;

        Graphics gr;

        static int num_of_circles = 20;
        static int num_of_rectangles = 20;
        static int num_of_squares = 20;
        static int num_of_rings= 20;
        static int num_of_frames = 20;

        circle[] m_circles = new circle[num_of_circles];
        rectangle[] m_rectangles = new rectangle[num_of_rectangles];
        square[] m_squares= new square[num_of_squares];
        ring[] m_rings = new ring[num_of_rings];
        frame[] m_frames = new frame[num_of_frames]; 
                
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
                new circle(user_circ_x, user_circ_y, user_circ_R, true);
            }
            else
            {
                m_circles[for_circ] = new circle();                 
            }
            m_circles[for_circ].show(gr = CreateGraphics(), Color.Aquamarine); //заполнение массива объектов одной группы
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
                        
            m_rectangles[for_rect].show(gr = CreateGraphics(), Color.Aquamarine); //заполнение массива объектов одной группы
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
                new square(user_square_x, user_square_y,
                user_square_a, true);
            }
            else
            {
                m_squares[for_square] = new square();
            }            
            m_squares[for_square].show(gr = CreateGraphics(), Color.Aquamarine); //заполнение массива объектов одной группы
            for_square++;

            MessageBox.Show("Квадрат успешно создан!");
            row_name = "Квадрат";
            checkedListBox1.Items.Add(row_name + cb_for_square);
            row_name = "";
            cb_for_square++;
        }
        private void button13_Click(object sender, EventArgs e)
        {   if (textBox5.Text != "")
            {
                m_rings[for_ring] = new ring(user_ring_x, user_ring_y, user_ring_R, user_ring_a);
            }
            else
            { 
                m_rings[for_ring] = new ring();
            }
            m_rings[for_ring].show(gr = CreateGraphics(), Color.Aquamarine); //заполнение массива объектов одной группы
            for_ring++;

            MessageBox.Show("Кольцо успешно создано!");
            row_name = "Кольцо";

            checkedListBox1.Items.Add(row_name + cb_for_ring);
            row_name = "";
            cb_for_ring++;
        }// создание кольца
        private void button15_Click(object sender, EventArgs e)// создание рамки
        {
            if (textBox6.Text != "")
            {
                m_frames[for_frame] = new frame(user_frame_x, user_frame_y, user_frame_a, user_frame_b);
            }
            else
            {
                m_frames[for_frame] = new frame();
            }
            
            m_frames[for_frame].show(gr = CreateGraphics(), Color.Aquamarine); //заполнение массива объектов одной группы
            for_frame++;

            MessageBox.Show("Рама успешно создана!");
            row_name = "Рама";

            checkedListBox1.Items.Add(row_name + cb_for_frame);
            row_name = "";
            cb_for_frame++;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            for (int k = 0; k < checkedListBox1.Items.Count; k++) // проверка, что есть отмеченные, чтобы не стереть все
            {
                if (checkedListBox1.GetItemChecked(k))
                {
                    gr.Clear(Color.White);
                    break;
                    
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
                    m_squares[int.Parse(item.Replace("Квадрат", ""))].show(gr, Color.Aquamarine);
                }
                else if (item.Contains("Круг"))
                {                    
                    m_circles[int.Parse(item.Replace("Круг", ""))].show(gr, Color.Aquamarine);
                }
                else if (item.Contains("Прямоугольник"))
                {
                    m_rectangles[int.Parse(item.Replace("Прямоугольник", ""))].show(gr, Color.Aquamarine);

                }
                else if (item.Contains("Кольцо"))
                {
                    m_rings[int.Parse(item.Replace("Кольцо", ""))].show(gr, Color.Aquamarine);

                }
                else if (item.Contains("Рама"))
                {
                    m_frames[int.Parse(item.Replace("Рама", ""))].show(gr, Color.Aquamarine);
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
        
        private void button5_Click(object sender, EventArgs e)
        {

            for (int k = 0; k < checkedListBox1.Items.Count; k++) // проверка, что есть отмеченные, чтобы не стереть все
            {
                if (checkedListBox1.GetItemChecked(k))
                {
                    gr.Clear(Color.White);
                    break;
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
                    m_circles[int.Parse(item.Replace("Круг", ""))].show(gr, Color.Aquamarine);

                }
                else if (item.Contains("Прямоугольник"))
                {


                    if (checkedListBox1.GetItemChecked(i))
                    {
                        m_rectangles[int.Parse(item.Replace("Прямоугольник", ""))].rectangle_is_visible = false;
                        checkedListBox1.Items[i] = "Удалено";
                    }
                    m_rectangles[int.Parse(item.Replace("Прямоугольник", ""))].show(gr, Color.Aquamarine);


                }

                else if (item.Contains("Квадрат"))
                {

                    if (checkedListBox1.GetItemChecked(i))
                    {
                        m_squares[int.Parse(item.Replace("Квадрат", ""))].square_is_visible = false;
                        checkedListBox1.Items[i] = "Удалено";
                    }
                    m_squares[int.Parse(item.Replace("Квадрат", ""))].show(gr, Color.Aquamarine);


                }
                else if (item.Contains("Кольцо"))
                {

                    if (checkedListBox1.GetItemChecked(i))
                    {
                        m_rings[int.Parse(item.Replace("Кольцо", ""))].ring_is_visible = false;
                        checkedListBox1.Items[i] = "Удалено";
                    }
                    m_rings[int.Parse(item.Replace("Кольцо", ""))].show(gr, Color.Aquamarine);

                }
                else if (item.Contains("Рама"))
                {

                    if (checkedListBox1.GetItemChecked(i))
                    {
                        m_frames[int.Parse(item.Replace("Рама", ""))].frame_is_visible= false;
                        checkedListBox1.Items[i] = "Удалено";
                    }
                    m_frames[int.Parse(item.Replace("Рама", ""))].show(gr, Color.Aquamarine);


                }

                i++;

            }


        } // очистка      

        private void button8_Click(object sender, EventArgs e)
        {
            for (int k = 0; k < checkedListBox1.Items.Count; k++) // проверка, что есть отмеченные, чтобы не стереть все
            {
                if (checkedListBox1.GetItemChecked(k))
                {
                    gr.Clear(Color.White);
                    break;
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

                    m_circles[int.Parse(item.Replace("Круг", ""))].show(gr, Color.Aquamarine);
                                                

                    
                }
                else if (item.Contains("Прямоугольник"))
                {
                    
                    
                    if (checkedListBox1.GetItemChecked(i))
                    {
                        m_rectangles[int.Parse(item.Replace("Прямоугольник", ""))].Move(move_pixels, 0);
                    }
                    m_rectangles[int.Parse(item.Replace("Прямоугольник", ""))].show(gr, Color.Aquamarine);
                                               
                    
                }

                else if (item.Contains("Квадрат"))
                {                   
                    
                    if (checkedListBox1.GetItemChecked(i))
                    {
                        m_squares[int.Parse(item.Replace("Квадрат", ""))].MoveToRight(move_pixels);
                    }
                    m_squares[int.Parse(item.Replace("Квадрат", ""))].show(gr, Color.Aquamarine);
                       
                    
                }
                else if (item.Contains("Кольцо"))
                {
                    if (checkedListBox1.GetItemChecked(i))
                    {
                        m_rings[int.Parse(item.Replace("Кольцо", ""))].Move(move_pixels, 0);
                    }
                    m_rings[int.Parse(item.Replace("Кольцо", ""))].show(gr, Color.Aquamarine);
                }    
                else if (item.Contains("Рама"))
                {
                    if (checkedListBox1.GetItemChecked(i))
                    {
                        m_frames[int.Parse(item.Replace("Рама", ""))].Move(move_pixels, 0);
                    }
                    m_frames[int.Parse(item.Replace("Рама", ""))].show(gr, Color.Aquamarine);
                }    
                i++;
            }           

        } // сдвиг вправо

        private void button7_Click(object sender, EventArgs e)
        {
            for (int k = 0; k < checkedListBox1.Items.Count; k++) // проверка, что есть отмеченные, чтобы не стереть все
            {
                if (checkedListBox1.GetItemChecked(k))
                    gr.Clear(Color.White);
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

                    m_circles[int.Parse(item.Replace("Круг", ""))].show(gr, Color.Aquamarine);



                }
                else if (item.Contains("Прямоугольник"))
                {


                    if (checkedListBox1.GetItemChecked(i))
                    {
                        m_rectangles[int.Parse(item.Replace("Прямоугольник", ""))].Move(-move_pixels,0);
                    }
                    m_rectangles[int.Parse(item.Replace("Прямоугольник", ""))].show(gr, Color.Aquamarine);


                }

                else if (item.Contains("Квадрат"))
                {

                    if (checkedListBox1.GetItemChecked(i))
                    {
                        m_squares[int.Parse(item.Replace("Квадрат", ""))].MoveToLeft(move_pixels);
                    }
                    m_squares[int.Parse(item.Replace("Квадрат", ""))].show(gr, Color.Aquamarine);


                }
                else if (item.Contains("Кольцо"))
                {
                    if (checkedListBox1.GetItemChecked(i))
                    {
                        m_rings[int.Parse(item.Replace("Кольцо", ""))].Move(-move_pixels, 0);
                    }
                    m_rings[int.Parse(item.Replace("Кольцо", ""))].show(gr, Color.Aquamarine);
                }
                else if (item.Contains("Рама"))
                {
                    if (checkedListBox1.GetItemChecked(i))
                    {
                        m_frames[int.Parse(item.Replace("Рама", ""))].Move(-move_pixels, 0);
                    }
                    m_frames[int.Parse(item.Replace("Рама", ""))].show(gr, Color.Aquamarine);
                }
                i++;
            }
        } // сдвиг влево

        private void button9_Click(object sender, EventArgs e)
        {
            for (int k = 0; k < checkedListBox1.Items.Count; k++) // проверка, что есть отмеченные, чтобы не стереть все
            {
                if (checkedListBox1.GetItemChecked(k))
                    gr.Clear(Color.White);
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

                    m_circles[int.Parse(item.Replace("Круг", ""))].show(gr, Color.Aquamarine);



                }
                else if (item.Contains("Прямоугольник"))
                {


                    if (checkedListBox1.GetItemChecked(i))
                    {
                        m_rectangles[int.Parse(item.Replace("Прямоугольник", ""))].Move(0, move_pixels);
                    }
                    m_rectangles[int.Parse(item.Replace("Прямоугольник", ""))].show(gr, Color.Aquamarine);


                }

                else if (item.Contains("Квадрат"))
                {

                    if (checkedListBox1.GetItemChecked(i))
                    {
                        m_squares[int.Parse(item.Replace("Квадрат", ""))].MoveToDown(move_pixels);
                    }
                    m_squares[int.Parse(item.Replace("Квадрат", ""))].show(gr, Color.Aquamarine);


                }
                else if (item.Contains("Кольцо"))
                {
                    if (checkedListBox1.GetItemChecked(i))
                    {
                        m_rings[int.Parse(item.Replace("Кольцо", ""))].Move(0, move_pixels);
                    }
                    m_rings[int.Parse(item.Replace("Кольцо", ""))].show(gr, Color.Aquamarine);
                }
                else if (item.Contains("Рама"))
                {
                    if (checkedListBox1.GetItemChecked(i))
                    {
                        m_frames[int.Parse(item.Replace("Рама", ""))].Move(0, move_pixels);
                    }
                    m_frames[int.Parse(item.Replace("Рама", ""))].show(gr, Color.Aquamarine);
                }
                i++;
            }
        } // сдвиг вниз

        private void button6_Click(object sender, EventArgs e)
        {
            for (int k = 0; k < checkedListBox1.Items.Count; k++) // проверка, что есть отмеченные, чтобы не стереть все
            {
                if (checkedListBox1.GetItemChecked(k))
                    gr.Clear(Color.White);
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

                    m_circles[int.Parse(item.Replace("Круг", ""))].show(gr, Color.Aquamarine);



                }
                else if (item.Contains("Прямоугольник"))
                {


                    if (checkedListBox1.GetItemChecked(i))
                    {
                        m_rectangles[int.Parse(item.Replace("Прямоугольник", ""))].Move(0, -move_pixels);
                    }
                    m_rectangles[int.Parse(item.Replace("Прямоугольник", ""))].show(gr, Color.Aquamarine);


                }

                else if (item.Contains("Квадрат"))
                {

                    if (checkedListBox1.GetItemChecked(i))
                    {
                        m_squares[int.Parse(item.Replace("Квадрат", ""))].MoveToUp(move_pixels);
                    }
                    m_squares[int.Parse(item.Replace("Квадрат", ""))].show(gr, Color.Aquamarine);


                }
                else if (item.Contains("Кольцо"))
                {
                    if (checkedListBox1.GetItemChecked(i))
                    {
                        m_rings[int.Parse(item.Replace("Кольцо", ""))].Move(0, -move_pixels);
                    }
                    m_rings[int.Parse(item.Replace("Кольцо", ""))].show(gr, Color.Aquamarine);
                }
                else if (item.Contains("Рама"))
                {
                    if (checkedListBox1.GetItemChecked(i))
                    {
                        m_frames[int.Parse(item.Replace("Рама", ""))].Move(0, -move_pixels);
                    }
                    m_frames[int.Parse(item.Replace("Рама", ""))].show(gr, Color.Aquamarine);
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
                ring_data = textBox5.Text.Split(' ');
                user_ring_x = int.Parse(ring_data[0]);
                user_ring_y = int.Parse(ring_data[1]);
                user_ring_R = int.Parse(ring_data[2]);
                user_ring_a = int.Parse(ring_data[3]);

                if (user_ring_a <= 0 | user_ring_a >= user_ring_R)
                {
                    throw new Exception();
                }

            }
            catch
            {
                MessageBox.Show("Возникла ошибка");
            }
           
        } // задание значений кольца

        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                frame_data = textBox6.Text.Split(' ');
                user_frame_x = int.Parse(frame_data[0]);
                user_frame_y = int.Parse(frame_data[1]);
                user_frame_a = int.Parse(frame_data[2]);
                user_frame_b = int.Parse(frame_data[3]);

                //if ()
                //{
                //    throw new Exception();
                //}

            }
            catch
            {
                MessageBox.Show("Возникла ошибка");
            }
        }
    }
}
