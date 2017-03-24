using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beginning_Programming
{
    class Program
    {
        static void Main(string[] args)
        {
            string userName;
            string number;
            int age;

            Console.WriteLine("What is your name?");
            userName = Console.ReadLine();
            Console.WriteLine("Hello " + userName);

            Console.WriteLine("How old are you?");
            number = Console.ReadLine();
            age = Convert.ToInt16(number);
            Console.WriteLine("You are " + age + " years old");

            int ageFuture = age + 5;

            Console.WriteLine("You will be " + ageFuture + " in five years");

            if (userName.Contains("o"))
            {
                Console.WriteLine("Your name has an O!");
            }

            if (userName.Length > 10)
            {
                Console.WriteLine("You have a really long name!");
            }

            if (userName.Length < 10)
            {
                Console.WriteLine("Your name is less then 10 letters");
            }

            Console.ReadLine();
                      
        }
    }
}
