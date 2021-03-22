using System;

namespace question1
{
    class Program
    {
        static void Main(string[] args)
        {
            GenericList<double> List = new GenericList<double>();
            for(int i = 0; i < 10; i++)
            {
                List.Add(i);
            }
            List.ForEach(n => Console.WriteLine(n + " "));
            double max=0, min=0,sum=0;
            List.ForEach(n =>
            {
                max = (n >= max) ? n : max;
                min = (n <= min) ? n : min;
                sum += n;
            });
            Console.WriteLine("The max is " + max + "; the min is " + min + " ;the sum is:" + sum);
        }
    }
    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; }
        public Node(T t)
        {
            Next = null;
            Data = t;
        }
    }
    public class GenericList<T>
    {
        private Node<T> head;
        private Node<T> tail;
        public GenericList()
        {
            tail = head = null;
        }
        public Node<T> Head
        {
            get => head;
        }
        public void Add(T t)
        {
            Node<T> n = new Node<T>(t);
            if (tail == null)
            {
                head = tail = n;
            }
            else
            {
                tail.Next = n;
                tail = n;
            }
        }
        public void ForEach(Action<T> action)
        {
            for (Node<T> n = head; n != null; n = n.Next)
            {
                action(n.Data);
            }
        }
    }
}
