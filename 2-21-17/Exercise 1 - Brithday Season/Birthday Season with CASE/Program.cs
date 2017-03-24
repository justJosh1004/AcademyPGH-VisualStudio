using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birthday_Season_with_CASE
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("What month is your birthday?");
                string month = Console.ReadLine().ToUpper();

                switch (month)
                {
                    
                    case "MARCH":
                    case "APRIL":
                    case "MAY":
                        Console.WriteLine("Your birthday is in the SPRING!");
                        break;
                    case "JUNE":
                    case "JULY":
                    case "AUGUST":
                        Console.WriteLine("Your birthday is in the SUMMER!");
                        break;
                    case "SEPTEMBER":
                    case "OCTOBER":
                    case "NOVEMBER":
                        Console.WriteLine("Your birthday is in the FALL!");
                        break;
                    case "DECEMBER":
                    case "JANUARY":
                    case "FEBRUARY":
                        Console.WriteLine("Your birthday is in the WINTER!");
                        break;
                    default:
                        Console.WriteLine("You did not give a valid answer. Please fully type out the name of the month");
                        break;
                }
                

                Console.WriteLine("Would you like to enter another birth month? Y/N");
                string option = Console.ReadLine().ToUpper();
                if (option == "N")
                    {
                    return;
                    }

                Console.Clear();
            }
        }
    }
}
