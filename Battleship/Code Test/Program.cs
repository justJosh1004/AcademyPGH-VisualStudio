using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Random num = new Random();
            while (true)
            {
                int choice = num.Next(1, 9);

                Console.WriteLine(choice);

                Console.WriteLine("AGAIN?");
                string response = Console.ReadLine();
                if (response == "n")
                    break;
                Console.Clear();
            }
        }
    }
}
