using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort_an_Array___Class_Answer
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] my_array = { 2, 6, 4, 1, 8, 5 };

            for (int x = 0; x < my_array.Length; x++)
            {
                for (int i = 0; i < my_array.Length - 1; i++)
                {
                    if (my_array[i] > my_array[i + 1])
                    {
                        //swap
                        int temp = my_array[i];
                        my_array[i] = my_array[i + 1];
                        my_array[i + 1] = temp;

                        /* alternate way to do a swap
                         * int a = 5;
                         * int b = 10;
                         * a = a + b;
                         * b = a - b;
                         * a = a - b;
                        */
                    }
                }
            }

            












            for (int i = 0; i < my_array.Length; i++)
            {
                Console.WriteLine(my_array[i]);
            }
            Console.ReadLine();
        }
    }
}
