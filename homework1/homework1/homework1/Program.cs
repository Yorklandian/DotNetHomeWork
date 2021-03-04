using System;

namespace homework1
{
    class Program
    {
        static void Main(string[] args)
        {
            string s,v;
            Console.WriteLine("Type in number 1:");
            s = Console.ReadLine();
            double a = Double.Parse(s);
            Console.WriteLine("Type in operator:");
            v = Console.ReadLine();
            Console.WriteLine("Type in number 2:");
            s = Console.ReadLine();
            double b = Double.Parse(s);
            switch (v)
            {
                case "+":
                    Console.WriteLine(a+b);
                    break;
                case "-":
                    Console.WriteLine(a-b);
                    break;
                case "*":
                    Console.WriteLine(a*b);
                    break;
                case "/":
                    Console.WriteLine(a/b);
                    break;
             
            }
        }
    }
}
