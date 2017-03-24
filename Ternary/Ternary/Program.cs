using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ternary
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 5;

            string result = "";

            result = i > 10 ? "i is greater than 10" : "i is less than 10";

            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
