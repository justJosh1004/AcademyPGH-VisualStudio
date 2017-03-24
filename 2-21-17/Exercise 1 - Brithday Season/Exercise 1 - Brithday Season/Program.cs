using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_1___Brithday_Season
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true) //starts the main loop
            { 
                int i = 0; //counter
                while (i < 10) //starts another loop that conuts how many times it runs
                {
                    bool answer = true;
                    while (answer == true) //another loop so that the counter doesn't go up when they type in something wrong
                    {
                        Console.WriteLine("What month is your birthday?");
                        string month = Console.ReadLine().ToUpper();

                        if (month == "MARCH" || month == "APRIL" || month == "MAY")
                        {
                            Console.WriteLine("Your birthday is in the spring!");
                            answer = false;
                        }
                        else if (month == "JUNE" || month == "JULY" || month == "AUGUST")
                        {
                            Console.WriteLine("Your birthday is in the summer!");
                            answer = false;
                        }
                        else if (month == "SEPTEMBER" || month == "OCTOBER" || month == "NOVEMBER")
                        {
                            Console.WriteLine("Your birthday is in the fall!");
                            answer = false;
                        }
                        else if (month == "DECEMBER" || month == "JANUARY" || month == "FEBRUARY")
                        {
                            Console.WriteLine("Your birthday is in the winter!");
                            answer = false;
                        }
                        else
                        {
                            Console.WriteLine("You did not give a valid answer. \nPlease fully write out the name of the month.");
                        }
                    }

                    i = i + 1; //they typed in an acceptable answer and counter goes up
                    if (i == 1)
                    {
                        Console.WriteLine("You have done this once");
                    }
                    else
                    {
                        Console.WriteLine("You have done this " + i + " times.");
                    }

                    Console.WriteLine("Would you like to enter another birth month? Y/N");
                    string option = Console.ReadLine().ToUpper();
                    if (option == "N" || option == "NO")
                    {
                        return; //ends loop
                    }
                    if (i == 10)
                    {
                        Console.WriteLine("You have done this 10 times.  Do you want to keep going? Y/N");
                        string yesNo = Console.ReadLine().ToUpper();
                        if (yesNo == "N" || option == "NO")
                        {
                            return; //ends loop
                        }
                    }
                    Console.Clear(); //clears the console
                }
            }
        }
    }
}
