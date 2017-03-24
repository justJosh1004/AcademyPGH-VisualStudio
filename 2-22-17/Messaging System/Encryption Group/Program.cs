using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption_Group
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Would you like to (S)tore a message or (R)etrieve a message or e(x)it?
             * > S
             * What is your message?
             * > I am testing this message system!
             * Saved! Your message ID is 0
             * Would you like to (S)tore a message or (R)etriev a message?
             * > R
             * What is the message ID?
             * > 0
             * The message is: I am testing this message system!
             * 
			 * */
            string[] message;
            message = new string[5];
            int i = 0;
            bool stop = false;
            while (stop == false)
            {
                Console.WriteLine("Would you like to (s)tore a message or (r)etrieve a message or (l)ist storage or e(x)it?");
                string response = Console.ReadLine().ToLower();
                if (response == "s")
                {
                    // Saving a message
                    Console.WriteLine("What is your message?");

                    string message_string = Console.ReadLine();
                    message[i] = Encrypter(message_string);


                    Console.WriteLine("Saved! Your message ID is " + i);
                    i++;
                }
                else if (response == "l")
                {
                    for (i = 0; i < message.Length; i++) { Console.WriteLine(message[i]); }
                }



                else if (response == "r")
                {
                    // Retrieving a message
                    Console.WriteLine("What is your message id?");
                    string message_id = Console.ReadLine();
                    int message_id_int = Convert.ToInt32(message_id);

                    Console.WriteLine("The message is: " + Decrypter(message[message_id_int]));
                }
                else if (response == "x")
                {
                    stop = true;
                }
                else
                {
                    // Typed anything else
                    Console.WriteLine("I didn't understand what you typed.");
                }
            }
            Console.ReadLine();
        }

        static string Encrypter(string message)
        {
            string hex = "";
            foreach (char c in message)
            {
                int tmp = c;
                hex += String.Format("{0:x2}", (uint)System.Convert.ToUInt32(tmp.ToString()));
            }
            return hex;
        }

        static string Decrypter(string code)
        {
            string StrValue = "";
            while (code.Length > 0)
            {
                StrValue += System.Convert.ToChar(System.Convert.ToUInt32(code.Substring(0, 2), 16)).ToString();
                code = code.Substring(2, code.Length - 2);
            }
            return StrValue;
        }
    }
}
