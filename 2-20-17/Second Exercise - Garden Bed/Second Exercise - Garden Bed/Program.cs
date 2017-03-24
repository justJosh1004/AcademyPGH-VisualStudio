using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second_Exercise___Garden_Bed
{
    class Program
    {
        static void Main(string[] args)
        {
            //Get dimensions
            string length;
            string width;
            int length_int;
            int width_int;
            Console.WriteLine("What is the length of your garden box?");
            length = Console.ReadLine();
            length_int = Convert.ToInt16(length); 
            Console.WriteLine("\nWhat is the width of your garden box?");
            width = Console.ReadLine();
            width_int = Convert.ToInt16(width);

            //Calculate area and perimeter
            int area;
            int perimeter;

            area = length_int * width_int;
            perimeter = 2 * (length_int + width_int);

            Console.WriteLine("\nYour garden box has an area of " + area + " feet and a perimeter of " + perimeter + " feet\n\n");

            //Calculate how many plants to plant
            int carrot;
            int corn;
            int beets;

            carrot = 16 * (area / 16);
            corn = 3 * (area / 16);
            beets = 9 * (area / 16);

            Console.WriteLine("You can plant " + carrot + " carrot plants, " + corn + " corn plants, and " + beets
                + " beet plants in your garden box");

            Console.ReadLine();
        }
    }
}
