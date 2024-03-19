using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;
using System.Drawing;
using ClassLibrary_1;


namespace MyLab1
{

    public class LinkedList: IEnumerable<Abstract_properties> // односвязный список
    {
        Random my_rnd = new Random();

        List_objects head; // головной/первый элемент

        List_objects tail; // последний/хвостовой элемент

        int count;  // количество элементов в списке

        public LinkedList()
        {
            for (int i = 0; i < Form1.variant; i++)
            {
                int my_rand = my_rnd.Next(1, 50);

                List_objects my_node;

                if (my_rand >= 1 && my_rand < 11)
                {
                    my_node =  new List_objects(new circle());
                }
                else if (my_rand >= 11 && my_rand < 21)
                {
                    my_node = new List_objects(new ellipse());
                }
                else if (my_rand >= 21 && my_rand < 31)
                {
                    my_node = new List_objects(new rectangle());
                }
                else if (my_rand >= 31 && my_rand < 41)
                {
                    my_node = new List_objects(new square());
                }                
                else
                    my_node = new List_objects(new rhomb());


                my_rand = my_rnd.Next(1, 50);
                Thread.Sleep(10);

                if (i == 0)
                {
                    my_node.Next = head;
                    head = my_node;
                    if (count == 0)
                        tail = head;
                    count++;
                }
                else
                {
                    if (head == null)
                        head = my_node;
                    else
                        tail.Next = my_node;
                    tail = my_node;
                    count++;
                }

            }

        }
        public LinkedList(int n)
        {
            for (int i = 0; i < n; i++)
            {
                int my_rand = my_rnd.Next(1, 50);

                List_objects my_node;

                if (my_rand >= 1 && my_rand < 11)
                {
                    my_node = new List_objects(new circle());
                }
                else if (my_rand >= 11 && my_rand < 21)
                {
                    my_node = new List_objects(new ellipse());
                }
                else if (my_rand >= 21 && my_rand < 31)
                {
                    my_node = new List_objects(new rectangle());
                }
                else if (my_rand >= 31 && my_rand < 41)
                {
                    my_node = new List_objects(new square());
                }
                else
                    my_node = new List_objects(new rhomb());


                my_rand = my_rnd.Next(1, 50);
                Thread.Sleep(10);

                if (i == 0)
                {
                    my_node.Next = head;
                    head = my_node;
                    if (count == 0)
                        tail = head;
                    count++;
                }
                else
                {
                    if (head == null)
                        head = my_node;
                    else
                        tail.Next = my_node;
                    tail = my_node;
                    count++;
                }

            }

        }

        public void iterator_for_show(Graphics gr)
        {
            List_objects current = head;

            while (current != null)
            {
                while (current != null)
                {
                    if (current.Data is ellipse ell_type)
                    {
                        ell_type.ellipse_is_visible = true;
                        ell_type.Show(gr, Color.Aquamarine);
                    }
                    else if (current.Data is circle circ_type)
                    {
                        circ_type.circle_is_visible = true;
                        circ_type.Show(gr, Color.Aquamarine);
                    }
                    else if (current.Data is rectangle rect_type)
                    {
                        rect_type.rectangle_is_visible = true;
                        rect_type.Show(gr, Color.Aquamarine);
                    }
                    else if (current.Data is rhomb rh_type)
                    {
                        rh_type.rhomb_is_visible = true;
                        rh_type.Show(gr, Color.Aquamarine);
                    }
                    else if (current.Data is square square_type)
                    {
                        square_type.square_is_visible = true;
                        square_type.Show(gr, Color.Aquamarine);
                    }
                    current = current.Next;
                }
                current = current.Next;
            }
        }
        public void iterator_for_delete(Graphics gr)
        {
            List_objects current = head;
            gr.Clear(Color.White);

            while (current != null)
            {
                if (current.Data is ellipse ell_type)
                {
                    ell_type.ellipse_is_visible = false;
                }
                else if (current.Data is circle circ_type)
                {
                    circ_type.circle_is_visible = false;
                }
                else if (current.Data is rectangle rect_type)
                {
                    rect_type.rectangle_is_visible = false;
                }
                else if (current.Data is rhomb rh_type)
                {
                    rh_type.rhomb_is_visible = false;
                }
                else if (current.Data is square square_type)
                {
                    square_type.square_is_visible = false;
                }
                current = current.Next;
            }
        }

        public void iterator_for_move(int x, int y,Graphics gr)
        {
            List_objects current = head;
            gr.Clear(Color.White);

            while (current != null)
            {
                if (current.Data is ellipse ell_type)
                {
                    ell_type.Move(x, y);
                    ell_type.Show(gr, Color.Aquamarine);
                }
                else if (current.Data is circle circ_type)
                {
                    circ_type.Move(x, y);
                    circ_type.Show(gr, Color.Aquamarine);
                }
                else if (current.Data is rectangle rect_type)
                {
                    rect_type.Move(x, y);
                    rect_type.Show(gr, Color.Aquamarine);
                }
                else if (current.Data is rhomb rh_type)
                {
                    rh_type.Move(x, y);
                    rh_type.Show(gr, Color.Aquamarine);
                }
                else if (current.Data is square square_type)
                {
                    square_type.Move(x, y);
                    square_type.Show(gr, Color.Aquamarine);
                }
                current = current.Next;
            }
        }
        public void expansion_of_list(Graphics gr)
        {
            if (count == Form1.num_of_shapes)
            {
                System.Windows.Forms.MessageBox.Show("Список заполнен! Теперь вы расширяете список");
            }
            int my_rand = my_rnd.Next(1, 50);

            List_objects added_element;

            if (my_rand >= 1 && my_rand < 11)
            {
                added_element = new List_objects(new circle());
            }
            else if (my_rand >= 11 && my_rand < 21)
            {
                added_element = new List_objects(new ellipse());
            }
            else if (my_rand >= 21 && my_rand < 31)
            {
                added_element = new List_objects(new rectangle());
            }
            else if (my_rand >= 31 && my_rand < 41)
            {
                added_element = new List_objects(new square());
            }
            else
                added_element = new List_objects(new rhomb());

            if (head == null)
                head = added_element;
            else
                tail.Next = added_element;
            tail = added_element;
            added_element.Data.Show(gr, Color.Aquamarine);
            count++;

        }

     
        public void Add(Abstract_properties data)
        {
            List_objects node = new List_objects(data);

            if (head == null)
                head = node;
            else
                tail.Next = node;
            tail = node;

            count++;
        }
        public bool Remove(Abstract_properties data)
        {
            List_objects current = head;
            List_objects previous = null;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    // Если узел в середине или в конце
                    if (previous != null)
                    {
                        previous.Next = current.Next;
                        if (current.Next == null)
                            tail = previous;
                    }
                    else
                    {
                        head = head.Next;

                        if (head == null)
                            tail = null;
                    }
                    count--;
                    return true;
                }
                previous = current;
                current = current.Next;
            }
            return false;
        }
        
        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }        
        public bool Contains(Abstract_properties data)
        {
            List_objects current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }

        public void AppendFirst(Abstract_properties data)
        {
            List_objects node = new List_objects(data);
            node.Next = head;
            head = node;
            if (count == 0)
                tail = head;
            count++;
        }
        

        IEnumerator<Abstract_properties> IEnumerable<Abstract_properties>.GetEnumerator()
        {
            List_objects current = head;

            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }


    }
}
