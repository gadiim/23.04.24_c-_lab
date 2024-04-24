using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

//Тема: Вступ у Generics
//Модуль 10. Part 1

namespace _23._04._24_c__lab
{

    //Task_1

    class Max<T> where T : IComparable<T>
    {
        public T MaxCalculation(T a, T b, T c)
        {
            T max = a;
            if (b.CompareTo(max) > 0) { max = b; }
            if (c.CompareTo(max) > 0) { max = c; }
            return max;
        }
    }

    //Task_2
    class Min<T> where T : IComparable<T>
    {

        public T MinCalculation(T a, T b, T c)
        {
            T min = a;
            if (b.CompareTo(min) < 0) { min = b; }
            if (c.CompareTo(min) < 0) { min = c; }
            return min;
        }
    }

    //Task_3

    class ArrSum<T>
    {
        public static T Sum(T[] arr)
        {
            T sum = default(T);

            for (int i = 0; i < arr.Length; i++)
            {
                sum += (dynamic)arr[i];
            }
            return sum;
        }
    }

    //Task_4

    class Stack<T>
    {
        private T[] values;
        private int size;
        private int top;
        public Stack(int size)
        {
            values = new T[size];
            this.size = size;
            top = -1;
        }
        public void Push(T value)
        {
            values[top + 1] = value;
            top++;
        }
        public T Pop()
        {
            T temp_top = values[top];
            top--;
            T[] resize_arr = new T[values.Length - 1];
            Array.Copy(values, resize_arr, top+1);
            values = resize_arr;
            return temp_top;  
        }
        public T Peek()
        {
            return values[top];
        }
        public int Count()
        {
            return values.Length;
        }

            public void Show()
        {
            Console.Write($"stack:\t\t\t\t");
            foreach (T value in values)
            {
                Console.Write(value + "  ");
            }
            Console.WriteLine();
        }
    }

    //Task_5

    class Queue<T>
    {
        private List<T> values = new List<T>();

        public void Enqueue(T item)
        {
            values.Add(item);
        }

        public T Dequeue()
        {
            T value = values[0];
            values.RemoveAt(0);
            return value;
        }

        public T Peek()
        {
            return values[0];
        }

        public int Count()
        {
            return values.Count;
        }
        public void Show()
        {
            Console.Write($"queue:\t\t\t\t");
            foreach (T value in values)
            {
                Console.Write(value + "  ");
            }
            Console.WriteLine();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //Завдання 1
            //Створіть generic-версію методу обчислення максимуму з трьох чисел.

            Console.WriteLine($"Task 1\n");

            Max<int> int_value_1 = new Max<int>();
            int max_int = int_value_1.MaxCalculation(3, 2, 5);
            Console.WriteLine($"max int:\t\t\t{max_int}");

            Max<double> double_value_1 = new Max<double>();
            double max_double = double_value_1.MaxCalculation(3.2, 2.5, 5.3);
            Console.WriteLine($"max double:\t\t\t{max_double}");

            Console.WriteLine("\nPress any key to continue . . .");
            Console.ReadKey();
            Console.WriteLine();

            //Завдання 2
            //Створіть generic-версію методу обчислення мінімуму
            //з трьох чисел.

            Console.WriteLine($"Task 2\n");

            Min<int> int_value_2 = new Min<int>();
            int min_int = int_value_2.MinCalculation(3, 2, 5);
            Console.WriteLine($"min int:\t\t\t{min_int}");

            Min<double> double_value_2 = new Min<double>();
            double min_double = double_value_2.MinCalculation(3.2, 2.5, 5.3);
            Console.WriteLine($"min double:\t\t\t{min_double}");

            Console.WriteLine("\nPress any key to continue . . .");
            Console.ReadKey();
            Console.WriteLine();

            //Завдання 3
            //Створіть generic-версію методу пошуку суми елементів у масиві.

            Console.WriteLine($"Task 3\n");

            int[] int_arr = { 3, 2, 5 };
            Console.WriteLine($"sum int:\t\t\t{ArrSum<int>.Sum(int_arr)}");

            double[] double_arr = { 3.2, 2.5, 5.3 };
            Console.WriteLine($"sum double:\t\t\t{ArrSum<double>.Sum(double_arr)}");

            Console.WriteLine("\nPress any key to continue . . .");
            Console.ReadKey();
            Console.WriteLine();

            //Завдання 4
            //Створіть generic-клас «Стек». Реалізуйте стандартні
            //методи і властивості для роботи стеку:
            //■ pop;
            //■ push;
            //■ peek;
            //■ count.
            //Докладніше про організацію стеку читайте тут: https://
            //            uk.wikipedia.org / wiki / Стек.

            Console.WriteLine($"Task 4\n");

            Stack<int> int_stack = new Stack<int>(3);
            int_stack.Push(3);
            int_stack.Push(2);
            int_stack.Push(5);
            int_stack.Show();
            Console.WriteLine($"count int:\t\t\t{int_stack.Count()}");
            Console.WriteLine($"peek int:\t\t\t{int_stack.Peek()}");
            Console.WriteLine($"pop int:\t\t\t{int_stack.Pop()}");
            Console.WriteLine($"peek int:\t\t\t{int_stack.Peek()}");
            int_stack.Show();
            Console.WriteLine();

            Stack<double> double_stack = new Stack<double>(3);
            double_stack.Push(3.2);
            double_stack.Push(2.5);
            double_stack.Push(5.3);
            double_stack.Show();
            Console.WriteLine($"count double:\t\t\t{double_stack.Count()}");
            Console.WriteLine($"peek double:\t\t\t{double_stack.Peek()}");
            Console.WriteLine($"pop double:\t\t\t{double_stack.Pop()}");
            Console.WriteLine($"peek double:\t\t\t{double_stack.Peek()}");
            double_stack.Show();
            Console.WriteLine();

            Stack<string> string_stack = new Stack<string>(4);
            string_stack.Push("three");
            string_stack.Push("two");
            string_stack.Push("five");
            string_stack.Push("one");
            string_stack.Show();
            Console.WriteLine($"count string:\t\t\t{string_stack.Count()}");
            Console.WriteLine($"peek string:\t\t\t{string_stack.Peek()}");
            Console.WriteLine($"pop string:\t\t\t{string_stack.Pop()}");
            Console.WriteLine($"peek string:\t\t\t{string_stack.Peek()}");
            string_stack.Show();

            Console.WriteLine("\nPress any key to continue . . .");
            Console.ReadKey();
            Console.WriteLine();

            //Завдання 5
            //Створіть generic-клас «Черга». Реалізуйте стандартні
            //методи і властивості для роботи черги:
            //■ enqueue;
            //■ dequeue;
            //■ peek;
            //■ count.
            //Докладніше про принципи черги читайте тут: https://
            //            uk.wikipedia.org / wiki / Черга_(структура_даних).

            Console.WriteLine($"Task 5\n");

            Queue<int> int_queue = new Queue<int>();
            int_queue.Enqueue(3);
            int_queue.Enqueue(2);
            int_queue.Enqueue(5);
            int_queue.Show();
            Console.WriteLine($"count int:\t\t\t{int_queue.Count()}");
            Console.WriteLine($"peek int:\t\t\t{int_queue.Peek()}");
            Console.WriteLine($"dequeue int:\t\t\t{int_queue.Dequeue()}");
            Console.WriteLine($"peek int:\t\t\t{ int_queue.Peek()}");
            int_queue.Show();
            Console.WriteLine();

            Queue<double> double_queue = new Queue<double>();
            double_queue.Enqueue(3.2);
            double_queue.Enqueue(2.5);
            double_queue.Enqueue(5.3);
            double_queue.Show();
            Console.WriteLine($"count double:\t\t\t{double_queue.Count()}");
            Console.WriteLine($"peek double:\t\t\t{double_queue.Peek()}");
            Console.WriteLine($"dequeue double:\t\t\t{double_queue.Dequeue()}");
            Console.WriteLine($"peek double:\t\t\t{double_queue.Peek()}");
            double_queue.Show();
            Console.WriteLine();

            Queue<string> string_queue = new Queue<string>();
            string_queue.Enqueue("three");
            string_queue.Enqueue("two");
            string_queue.Enqueue("five");
            string_queue.Enqueue("one");
            string_queue.Show();
            Console.WriteLine($"count string:\t\t\t{string_queue.Count()}");
            Console.WriteLine($"peek string:\t\t\t{string_queue.Peek()}");
            Console.WriteLine($"dequeue string:\t\t\t{string_queue.Dequeue()}");
            Console.WriteLine($"peek string:\t\t\t{string_queue.Peek()}");
            string_queue.Show();
            Console.WriteLine();

            Console.WriteLine();

        }
    }
}
