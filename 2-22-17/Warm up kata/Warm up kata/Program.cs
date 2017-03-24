using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warm_up_kata
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string input;
                Console.WriteLine("Enter your number to be converted: ");
                input = Console.ReadLine();
                int userInt = Convert.ToInt32(input);

                string result = ConvertToRoman(userInt);
                Console.WriteLine(input + " written in Roman Numerals is " + result);

                Console.WriteLine("\n\nDo you want to convert another number? Y/N");
                string again = Console.ReadLine().ToUpper();
                if (again == "N")
                {
                    return;
                }
                Console.Clear();
            }
        }

        static string ConvertToRoman(int number)
        {
            string roman = "";
            while (number >= 100)
            {
                number = number - 100;
                roman = roman + "C";
            }
            if (number >= 90)
            {
                number = number - 90;
                roman = roman + "XC";
            }
            if (number >= 50)
            {
                number = number - 50;
                roman = roman + "L";
            }
            if (number >= 40)
            {
                number = number - 40;
                roman = roman + "XL";
            }
            while (number >= 10)
            {
                number -= 10;
                roman = roman + "X";
            }
            if (number >= 9)
            {
                number -= 9;
                roman += "IX";
            }
            if (number >= 5)
            {
                number -= 5;
                roman += "V";
            }
            while (number >= 1)
            {
                number -= 1;
                roman += "I";
            }
            return roman;
        }
    }
}
