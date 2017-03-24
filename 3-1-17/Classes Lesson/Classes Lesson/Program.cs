using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes_Lesson
{
    class Program
    {
        static void Main(string[] args)
        {
            Person student1;
            student1 = new Person();
            student1.FirstName = "Orion";
            student1.LastName = "HALL";

            Console.WriteLine("First name is: " + student1.FirstName);

            Console.ReadLine();
        }
    }

    class Person
    {
        public string FirstName;
        public string LastName;
    }
}
