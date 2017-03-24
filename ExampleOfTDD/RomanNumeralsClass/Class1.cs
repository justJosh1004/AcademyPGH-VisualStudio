using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumeralsClass
{
    public class RomanConverter
    {
        public string GetRoman(int number)
        {
            string result = "";
            while (number >= 4)
            {
                result += "IV";
                number -= 4;
            }
            while (number > 0)
            {
                result += "I";
                number--;
            }
            return result;
        }
    }
}
