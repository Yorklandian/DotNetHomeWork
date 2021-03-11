using System;

namespace Questionn2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"Input an array,split with"","":");
            string[] str = Console.ReadLine().Split(",");
            int strLenth = str.Length;
            int[] input = new int[strLenth];
            try
            {
                for(int k=0; k < strLenth; k++)
                {
                    input[k] = Int32.Parse(str[k]);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Wrong input!!!");
            }
            double[] output = getNumbers(input);
            Console.WriteLine($"The max is {output[0]}");
            Console.WriteLine($"The min is {output[1]}");
            Console.WriteLine($"The ave is {output[2]}");
            Console.WriteLine($"The sum is {output[3]}");

        }
        static double[] getNumbers(int[] a)
        {
            double [] res=new double[4];
            int max=a[0],min = a[0],sum=0;
            double ave = 0;
            for(int i = 0; i < a.Length; i++)
            {
                if (a[i] > max)
                    max = a[i];
            }
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] < min)
                    min = a[i];
            }
            for (int i = 0; i < a.Length; i++)
            {
                sum += a[i];
            }
            ave = sum / a.Length;
            res[0] = max;
            res[1] = min;
            res[2] = ave;
            res[3] = sum;
            return res;

        }
    }
}
