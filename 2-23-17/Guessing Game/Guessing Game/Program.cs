using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guessing_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] my_array = { 3, 12, 8, 33, 2 };
            while (true)
            {
                Console.WriteLine("I'm thinking of a number between 1 and 50.  Can you guess which one?");
                string user_guess = Console.ReadLine();
                int guess = Convert.ToInt32(user_guess);
            
                bool correct = false;
                bool check = false;

                while (correct == false)
                {
                    for (int i = 0; i < my_array.Length; i++)
                    {
                        if (my_array[i] == guess)
                        {
                            check = true;
                            i = 10;
                            correct = true;
                        }
                        else
                        {
                            check = false;
                        }
                    }
                    Console.WriteLine("HERE");
                    if (check == true)
                    {
                        Console.WriteLine("you got it");
                    }
                    else if (check == false)
                    {
                        Console.WriteLine("wrong");
                    }


                    Console.ReadLine();
                    //return;
                }
                
            Console.ReadLine();
            return;
            }

            
        }
    }
}
