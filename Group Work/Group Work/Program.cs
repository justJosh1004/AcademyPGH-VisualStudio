using System;
using System.Collections.Generic;

namespace braille
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string[,,] braille_alphabet ={
            { { "X", " " }, { " ", " " }, { " ", " " } },//a
			{ { "X", " " }, { "X", " " }, { " ", " " } },//b
			{ { "X", "X" }, { " ", " " }, { " ", " " } },//c
			{ { "X", "X" }, { " ", "X" }, { " ", " " } },//d
			{ { "X", " " }, { " ", "X" }, { " ", " " } },//e
			{ { "X", "X" }, { " ", " " }, { " ", " " } },//f

			{ { "X", "X" }, { "X", "X" }, { " ", " " } },
            { { "X", " " }, { "X", "X" }, { " ", " " } },
            { { "X", " " }, { "X", "X" }, { " ", " " } },
            { { " ", "X" }, { "X", "X" }, { " ", " " } },
            { { "X", " " }, { " ", "X" }, { "X", " " } },
            { { "X", " " }, { "X", " " }, { "X", " " } },


            { { "X", "X" }, { " ", " " }, { "X", " " } },
            { { "X", "X" }, { " ", "X" }, { "X", " " } },
            { { "X", " " }, { " ", "X" }, { "X", " " } },
            { { "X", "X" }, { "X", " " }, { "X", " " } },
            { { "X", "X" }, { "X", "X" }, { "X", " " } },
            { { "X", " " }, { "X", "X" }, { "X", " " } },

            { { " ", "X" }, { "X", " " }, { "X", " " } },
            { { " ", "X" }, { "X", "X" }, { "X", " " } },
            { { "X", " " }, { " ", "X" }, { "X", "X" } },
            { { "X", " " }, { "X", " " }, { "X", "X" } },
            { { "X", "X" }, { "X", " " }, { "X", "X" } },
            { { "X", "X" }, { " ", " " }, { "X", "X" } },
            { { "X", "X" }, { " ", "X" }, { "X", "X" } },
            { { "X", " " }, { " ", "X" }, { "X", "X" } },
            { { " ", " " }, { " ", " " }, { " ", " " } },
            };


            Console.WriteLine("Enter your text");
            string response = Console.ReadLine().ToUpper();
            char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            int[] referents = new int[response.Length];

            for (int i = 0; i < response.Length; i++)
            {
                for (int j = 0; j < alpha.Length; j++)
                {
                    if (alpha[j] == response[i])
                    {
                        referents[i] = j;
                    }
                }
            }
            for (int l = 0; l < response.Length; l++)
            {
                Console.Write($"{(braille_alphabet[referents[l], 0, 0])} {(braille_alphabet[referents[l], 0, 1])}  ");
                            }
            Console.WriteLine();
            for (int m = 0; m < response.Length; m++)
            {
                Console.Write($"{(braille_alphabet[referents[m], 1, 0])} {(braille_alphabet[referents[m], 1, 1])}  ");
            }
            Console.WriteLine();

            for (int n = 0; n < response.Length; n++)
            {
                Console.Write($"{(braille_alphabet[referents[n], 1, 0])} {(braille_alphabet[referents[n], 1, 1])}  ");
            }
            Console.WriteLine("\n");
            Console.ReadLine();
        }
    }
}