using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Field_Painting
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)//Will keep asking until user says they are don't want to keep going
            {
                //Ask for size
                Console.WriteLine("What is the radius of the circle in feet?");
                string ansRad = Console.ReadLine();
                double rad = Convert.ToDouble(ansRad);

                //Find area
                double area = (Math.PI * rad * rad);

                //Ask for the color of paint
                string color = "";
                bool answer = true;
                while (answer == true) //loop so that they cannot type in an invalid string
                {
                    Console.WriteLine("What color paint do you want to use?\nRed, blue, green, or yellow?");
                    color = Console.ReadLine().ToUpper();
                    if (color == "RED" || color == "BLUE" || color == "GREEN" || color == "YELLOW" )
                    {
                        answer = false;
                    }
                    else
                    {
                        Console.WriteLine("That was not a valid color. \nPlease choose another color.\n\n");
                    }
                }
                
                //Calculating number of buckets and  puts in the cost of the paint
                double bucket = 0;
                double cost = 0;
                if (color == "RED")
                {
                    bucket = area / 100;
                    cost = 25;
                }
                else if (color == "BLUE")
                {
                    bucket = area / 120;
                    cost = 28;
                }
                else if (color == "GREEN")
                {
                    bucket = area / 90;
                    cost = 33;
                }
                else if (color == "YELLOW")
                {
                    bucket = area / 70;
                    cost = 22;
                }

                double numBuckets = Math.Ceiling(bucket);//Math.Ceiling to round up to whole number
                decimal bucketCost = Convert.ToDecimal(cost) * Convert.ToDecimal(numBuckets);//Calculates the cost of all the buckets
                Console.WriteLine("It will take " + numBuckets + " buckets to paint the " + rad + "ft radius circle.\nIt will cost $" + bucketCost);

                Console.WriteLine("Do you want to do another field? Y/N");
                string ans = Console.ReadLine().ToUpper();
                if (ans == "N" || ans == "NO")
                {
                    return;//Ends the loop
                }
                Console.Clear();
            }
        }
    }
}
