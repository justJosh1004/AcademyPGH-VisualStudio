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
                double radius = getRadius(Convert.ToDouble(Console.ReadLine()));//converts the radius to a double

                //Find area
                double area = getArea(radius);//gets the area

                //Ask for the color of paint
                string color = "";
                bool answer = true;
                while (answer == true) //loop so that they cannot type in an invalid string
                {
                    Console.WriteLine("What color paint do you want to use?\nRed, blue, green, or yellow?");
                    color = Console.ReadLine().ToUpper();
                    if (color == "RED" || color == "BLUE" || color == "GREEN" || color == "YELLOW")
                    {
                        answer = false;
                    }
                    else
                    {
                        Console.WriteLine("That was not a valid color. \nPlease choose another color.\n\n");
                    }
                }
                
                colorValues(color, radius);//gets the values for the colors chosen
                
                Console.WriteLine("It will take " + totalBuckets(howManyBuckets(color, radius))/*getting the total number of buckets by calling function totalBuckets which uses function howManyBuckets*/ + 
                    " buckets to paint the " + radius + "ft radius circle.\nIt will cost $"
                    + getCost(colorValues(color, radius), totalBuckets(howManyBuckets(color, radius)))/*gets the total cost by calling colorValue and totalBuckets function.  This is a function calling 
                                                                                                        in two other functions for its values functionA(functionB(), functionC())*/);

                Console.WriteLine("Do you want to do another field? Y/N");
                string ans = Console.ReadLine().ToUpper();
                if (ans == "N" || ans == "NO")
                {
                    return;//Ends the loop
                }
                Console.Clear();
            }//end of main loop
        }//end of main









        static double getArea (double radius)//calculates the area with the given radius
        {
            double area = Math.PI * Math.Pow(radius, 2);
            return area;
        }//end of getArea

        static double getRadius(double userAnswer)//grabs the radius from the user
        {
            double radius = userAnswer;
            return radius;
        }//end of getRadius

        static double totalBuckets(double bucket)//calculates the total number of buckets to fill the area
        {
            double totalBuckets = Math.Ceiling(bucket);//rounds the number of bucket to the highest integer
            return totalBuckets;
        }//end of numBuckets

        static decimal getCost(double bucketCost, double numBuckets)//calculates the total cost of everything
        {
            decimal totalCost = Convert.ToDecimal(bucketCost) * Convert.ToDecimal(numBuckets);
            return totalCost;
        }//end of getCost

        static double colorValues (string color, double radius)//assigns values based on the color picked
        {
            double cost = 0;
            if (color == "RED")
            {
                howManyBuckets(color, radius);//calls howManyBuckets
                cost = 25;
            }
            else if (color == "BLUE")
            {
                howManyBuckets(color, radius);
                cost = 28;
            }
            else if (color == "GREEN")
            {
                howManyBuckets(color, radius);
                cost = 33;
            }
            else if (color == "YELLOW")
            {
                howManyBuckets(color, radius);
                cost = 22;
            }
            return cost;
        }//end of colorValues

        static double howManyBuckets (string color, double radius)//calculates how many buckets are needed
        {
            double buckets = 0;
            if (color == "RED")
            {
                buckets = getArea(radius) / 100;//calls getArea
            }
            else if (color == "BLUE")
            {
                buckets = getArea(radius) / 120;
            }
            else if (color == "GREEN")
            {
                buckets = getArea(radius) / 90;
            }
            else if (color == "YELLOW")
            {
                buckets = getArea(radius) / 70;
            }
            return buckets;
        }//end of howManybuckets
    }
}
