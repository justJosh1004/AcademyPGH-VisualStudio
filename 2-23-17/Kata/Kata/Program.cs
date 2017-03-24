using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            Console.WriteLine("Enter your number to be converted: ");
            input = Console.ReadLine();
            int userInt = Convert.ToInt32(input);

            string result = ConvertToRoman(userInt);
            Console.WriteLine(input + " written in Roman Numerals is " + result);
            Console.ReadLine();
        }

        static string ConvertToRoman(int number)
        {
            string roman = "";
            while (number >= 100)
            {
                number -= 100;
                roman += "C";
            }
            if (number >=90)
            {
                number -= 90;
                roman += "XC";
            }
            if (number >= 50) 
            {
                number -= 50;
                roman += "L";
            }
            if (number >= 40)
            {
                number -= 40;
                roman += "xl";
            }
            while (number >= 10)
            {
                number -= 10;
                roman += "X";
            }
            if (number >= 5)
            {
                number -= 5;
                roman += "V";
            }
            while (number >=1)
            {
                number -= 1;
                roman += "I";
            }
            return roman;
        }
    }
}
