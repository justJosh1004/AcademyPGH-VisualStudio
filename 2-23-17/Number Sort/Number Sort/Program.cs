using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] number = { 51, 16, 73, 48, 11 };
            int[] new_numbers = new int[number.Length - 1];
            int[] order = new int[5];
            int remove = 0;

            int current_min = 0;
            int num_compare = 0;
            int current = 0;

            int i = 0;
            
            while (i <  number.Length)
            {

               // Console.WriteLine(number[i]);
                int i2 = i + 1;
                current_min = number[i];
                while (i2 != number.Length)
                {
                    //Console.WriteLine(i2);
                    
                    num_compare = number[i2];
                    Console.WriteLine(current_min + " " + num_compare);
                    while (current_min > num_compare)
                    {
                        current_min = num_compare;
                        
                    }
                    
                    //Console.WriteLine(current_min);
                    
                    //Console.WriteLine(order[i]);
                    i2++;
                }
                Console.WriteLine("HERE");
                if (i2 != current_min)
                    {
                    order[i] = i;
                    Console.WriteLine("++++++++");
                    }
                order[i] = current_min;
                //Console.WriteLine(number[i]);

                Console.WriteLine(order[i]);
                Console.WriteLine("*****");
                //Console.WriteLine(i);
                i++;
            }
            
            Console.ReadLine();

        }
    }
}
