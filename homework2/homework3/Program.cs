using System;

namespace Question3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[99];
           for(int i = 0; i <arr.Length; i++)
            {
                arr[i] = i + 2;
            }
            Esieve(arr);
        }
        static bool isMultiple(int a,int b)
        {
            bool ismul= true;
            if ( a%b!= 0 || (a / b == 1))
            {
                ismul = false;
            }
            return ismul;
        }
        static void Esieve(int[] array)
        {
            int max = 10;
            for(int i = 2; i <=max; i++)
            {
                for (int j = 0; j < 99; j++)
                {
                    if (array[j] != -1 && isMultiple(j + 2, i))
                        array[j] = -1;
                }
            }
            getElements(array);
        }
        static void getElements(int[] array)
        {
            for(int i = 0; i < array.Length; i++)
            {
                if (array[i] != -1)
                    Console.Write(array[i] + " ");
            }
        }
    }
}
