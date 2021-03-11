using System;

namespace Question1
{
    class Program
    {
        static void Main(string[] args)
        {
            string s;
            int a;
            Console.WriteLine("Input an intger:");
            s = Console.ReadLine();
            a = Int32.Parse(s);
            Console.WriteLine("The Prime numbers are:");
            Program.factor(a);
            
        }
        static bool IsPrime(int n)
        {
            int i;
            bool flag = true;
            for (i = 2; i <= n / 2; i++)
                if (n % i == 0)
                {
                    flag = false ;
                    return flag;
                }
            return flag;
        }
         static void factor(int n)
        {
            int i;
            i = 2;
            while (i <= n)
            {
                if ((n % i == 0) && IsPrime(i))
                {
                    Console.WriteLine(i);
                    n = n / i;
                    continue;
                }
                i++;
            }
        }
    }
}
