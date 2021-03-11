using System;

namespace Question4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of the lines of the matrix:");//输入行数
            string Numline = Console.ReadLine();
                int a = Int32.Parse(Numline);

            Console.WriteLine("Enter the number of the columes of the matrix:");//输入列数
            string NumCol = Console.ReadLine();
                int b = Int32.Parse(Numline);
            

            int[,] arr = new int[a, b];

            for (int x = 0; x < a; x++)//按行进行数组输入
            {
                Console.WriteLine(@"Input a line of array,split with"","":");
                string[] str = Console.ReadLine().Split(",");
                try
                {
                    for (int k = 0; k < b; k++)
                    {
                        arr[x, k] = Int32.Parse(str[k]);
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Wrong input!!!");
                }
            }
            Console.WriteLine(judge(a, b, arr));
        }
        //判断
        static bool judge(int a,int b,int[,] array)
        {
            bool flag = true;
            if (a == 1 || b == 1)
                return false;
            for (int k = 0; k < a - 1; k++)
            {
                for (int i = 0; i < b - 1; i++)
                {
                    if (array[k, i] != array[k + 1, i + 1])
                        flag = false;
                }
            }
                return flag;
        }
    }
}
