using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morse_Code
{
    class Program
    {
        static void Main(string[] args)
        {
           //morse code library
            Dictionary<char, String> morseCode = new Dictionary<char, String>()
            {
                {'a' , ".-"},{'b' , "-..."},{'c' , "-.-."}, //alpha
                {'d' , "-.."},{'e' , "."},{'f' , "..-."},
                {'g' , "--."},{'h' , "...."},{'i' , ".."},
                {'j' , ".---"},{'k' , "-.-"},{'l' , ".-.."},
                {'m' , "--"},{'n' , "-."},{'o' , "---"},
                {'p' , ".--."},{'q' , "--.-"},{'r' , ".-."},
                {'s' , ".-."},{'t' , "-"},{'u' , "..-"},
                {'v' , "...-"},{'w' , ".--"},{'x' , "-..-"},
                {'y' , "-.--"},{'z' , "--.."}, { ' ' , "   " },
                //Numbers 
                {'0' , "-----"},{'1' , ".----"},{'2' , "..----"},{'3' , "...--"},
                {'4' , "....-"},{'5' , "....."},{'6' , "-...."},{'7' , "--..."},
                {'8' , "---.."},{'9' , "----."},
            };

            Console.WriteLine("What is your message?"); //asks the user for input
            string message = Console.ReadLine().ToLower(); //stores the input into message

            string results = ""; //defines variable results
            foreach (char i in message) // this can also be written as 
            {
                results += morseCode[i] + " "; // adds the morse code to the end of the string until the entire input is checked
            }
            Console.WriteLine(results); //prints out the input as morse code

            Console.ReadLine();
        }
    }
}
