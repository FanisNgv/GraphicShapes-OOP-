using System;

namespace Lab__1
{
    class vect
    {
        Random rnd = new Random();

        const int group_number = 17 + 1;

        private int[] massive = new int[group_number];

        public vect()
        {
            for (int i = 0; i < group_number; i++)
            {
                massive[i] = rnd.Next(0, 100);
            }
        }
        public void shower()
        { }
        public void show_vector()
        {
            Console.Write("Вектор - (");

            for (int i = 0; i < massive.Length; i++)
            {
                Console.Write($"{massive[i]},");
            }

            Console.WriteLine("\b)");
        }
        public int access1() // сеттер_1
        {
            int max_element = 0;

            for (int i = 0; i < massive.Length; i++)
            {
                if (massive[i] > max_element)
                {
                    max_element = massive[i];
                }
            }

            return max_element;
        }

        public int access2() // сеттер_2
        {
            int sum = 0;

            for (int i = 0; i < massive.Length; i++)
            {
                sum += massive[i];
            }

            return sum;
        }

        public double access3() // сеттер_3
        {
            double sum = 0;

            for (int i = 0; i < massive.Length; i++)
            {
                sum += Math.Pow(massive[i], 2);
            }

            return Math.Sqrt(sum);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {

            C c = new C(5, 5);

        }
    }
    class cap
    {
        public string color;
        public cap(string color)
        {
            this.color = color;
            Console.Write($"Шапка {this.color} цвета надета на ");
        }
    }
    class human
    {
        public string name;
        public int age;
        cap humans_cap;
        public human(string name)
        {
            this.name = name;
            humans_cap = new cap("red");
            Console.WriteLine(this.name);
        }
    }
    class Point
    {
        private int x;
        private int y;
        public int GetX() { return x; }
        public int GetY() { return y; }
        public void SetX(int x) { this.x = x; }
        public void SetY(int y) { this.y = y; }
        public Point()
        {
            x = 0;
            y = 0;
        }
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

    }
    class circle
    {
        private int R;
        private Point center;

        public circle(Point P, int R)
        {
            center = P;
            this.R = R;
        }
        public void Show() { }
        public void Delete() { }

        public void Move(int dx, int dy)
        {
            Delete();
            center.SetX(center.GetX()+dx);
            center.SetY(center.GetY()+dy);
            Show();
        }
        public int GetX() { return center.GetX(); }
        public int GetY() { return center.GetY(); }

        public void SetX(int x) { center.SetX(x);  }
        public void SetY(int y) { center.SetY(y); }


    }
    class Segment
    {
        public Point Point1;
        public Point Point2;

        public Segment(Point P1, Point P2)
        {
            Point1 = P1;
            Point2 = P2;
        }
        public void Show()
        {
            // Отрисовка
        }
        public void Delete()
        {
            // Очистка
        }
        //public void Move(int dx, int dy)
        //{
        //    Delete();
        //    Point1.X += dx;
        //    Point1.Y += dy;
        //    Point2.X += dx;
        //    Point2.Y += dy;
        //    Show();
        //}

    }
    class A
    {
        public A(int x, int y)
        {
            Console.WriteLine($"Я конструктор класса А. Вот числа:{x},{y}") ;
        }
    }
    class B:A
    {
        public B(int x, int y):base(3, 9)
        {
            Console.WriteLine($"Я конструктор класса B.Вот числа:{x},{y}");
        }
    }
    class C:B
    {
        public C(int x, int y):base(6,9)
        {
            Console.WriteLine($"Я конструктор класса C.Вот числа:{x},{y}");
        }
    }

}
