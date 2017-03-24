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
                //start of grid
                int[,] grid = new int[4, 4];
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        grid[i, j] = 0;
                    }
                }

                //temp grid
                int[,] temp_grid = new int[4, 4];
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        temp_grid[i, j] = 0;
                    }
                }

                //set live spaces
                grid[2, 1] = 1;
                grid[2, 2] = 1;
                grid[2, 3] = 1;

                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        Console.Write(grid[i, j]);
                    }
                    Console.WriteLine();
                }
                
                Console.ReadLine();
                //end of grid
                //bool check = false;
                /*
                for (int i = 0; i < 4; i++)//checking each space
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (grid[i, j] == 0)//if space has a "0"
                        {
                            check = true;
                            //Console.WriteLine(grid[i, j] = 4);
                        }
                        Console.WriteLine(grid[i, j] = 4);
                    }
                }
                */
                int[,] current_grid;
                if (grid[1, 2] == 0)
                {

                    current_grid = (1, 2);
                        temp_grid[1, 2] = 1;
                }
                Console.WriteLine(temp_grid);
                //draw temp_grid
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        Console.Write(temp_grid[i, j]);
                    }
                    Console.WriteLine();
                }

                Console.WriteLine();

                /*
                if (check == true)
                {
                    Console.WriteLine("HERE");
                    break;
                }
                */
            }//end of main while loop

            Console.ReadLine();
        }//end of Main
    }
}
