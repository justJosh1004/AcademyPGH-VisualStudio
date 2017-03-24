using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conway_s_Game_of_Life
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int[,] grid = new int[4, 4];
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        grid[i, j] = 0;
                    }
                }

                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        Console.Write(grid[i, j]);
                    }
                    Console.WriteLine();
                }

            }//end of main while loop

            Console.ReadLine();
        }//end of Main
    }
}
