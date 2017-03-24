using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encrpytion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type in  something:");
            string input = Console.ReadLine();
            int number = 0;

            string hex = "";
            foreach (char c in input)
            {
                int tmp = c;
                hex += String.Format("{0:x2}", (uint)System.Convert.ToUInt32(tmp.ToString()));
            }
            Console.WriteLine("***** " + hex);

            string StrValue = "";
            while (hex.Length > 0)
            {
                StrValue += System.Convert.ToChar(System.Convert.ToUInt32(hex.Substring(0, 2), 16)).ToString();
                hex = hex.Substring(2, hex.Length - 2);
            }
            Console.WriteLine(StrValue);
            

            

            number = Convert.ToInt32(input[0]);
            //Console.WriteLine(number);

            Console.WriteLine("Type in a number");
            string number_to_letter = Console.ReadLine();
            //number_to_letter = Convert.ToChar(number_to_letter);
           // Console.WriteLine(input);
            
            Console.WriteLine(number_to_letter);

            Console.ReadLine();
        }
    }
}
