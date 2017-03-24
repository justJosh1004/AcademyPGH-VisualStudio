using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messaging_System
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;//counter for the array
            string[] inbox = new string [10]; //sets the size of the array to 10

            for (i = 0; i < inbox.Length; i++) //sets the value of each array to Empty
            {
                inbox[i] = "This message is empty.";
            }

            i = 0; //sets the coutner back to 0
            bool response = false;
            while (response == false)//loops the program until response is changed
            {
                Console.WriteLine("Do you want to save or retrieve a message? S/R");
                string choice = Console.ReadLine().ToUpper();

                if (choice == "S")
                {
                    if (i == inbox.Length)//if array is full, it will display this message
                    {
                        Console.WriteLine("Your inbox is full.");
                    }
                    else//if there is space, it will ask for the message
                    {
                        Console.WriteLine("What message do you want to save?");
                        string message = Console.ReadLine();
                        inbox[i] = message;
                        Console.WriteLine("Your messade ID is " + i);
                        i++;//goes to the next space in the array
                    }
                }

                if (choice == "R")
                {
                    Console.WriteLine("What is your message ID?");
                    string stringID = Console.ReadLine();
                    int ID = Convert.ToInt32(stringID);
                    if (ID >= inbox.Length)//if they picked an ID outside of the size of the array, it will display this message
                    {
                        Console.WriteLine("That is not a valid message ID.");
                    }
                    else//wil display the message of the inbox ID
                    {
                        Console.WriteLine(inbox[ID]);
                    }
                }

                //Console.ReadLine();
                Console.WriteLine("Do you want to keep going? Y/N");
                string yesNo = Console.ReadLine().ToUpper();
                if (yesNo == "N")//ends the loops
                {
                    response = true;
                }
                Console.Clear();//clears the console
            }
        }
    }
}
