using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warm_Up_Kata_2
{
    public class Denomination
    {
        public int value;
        public string name;
    }

    public class RomanConverter
    {
        //Properties
        private List<Denomination> denominations;

        //Constructors
        public RomanConverter()
        {
            denominations = new List<Denomination>();
            FillDenominations();
        }

        public RomanConverter(List<Denomination> denominations)
        {
            this.denominations = denominations;
        }

        //Private Functions (methods)
        private void FillDenominations()
        {
            AddDenomination(100, "C");
            AddDenomination(90, "XC");
            AddDenomination(50, "L");
            AddDenomination(40, "XL");
            AddDenomination(10, "X");
            AddDenomination(5, "V");
            AddDenomination(4, "IV");
            AddDenomination(1, "I");
        }

        private void AddDenomination(int value, string name)
        {
            Denomination tempDenomination = new Denomination();
            tempDenomination.value = value;
            tempDenomination.name = name;
            denominations.Add(tempDenomination);
        }

        //Public Functions (method)
        public string Convert(int number)
        {
            string result = "";
            foreach(Denomination denomination in denominations)
            {
                while (number >= denomination.value)
                {
                    number -= denomination.value;
                    result += denomination.name;
                }
            }
            return result;
        }
    }
}
