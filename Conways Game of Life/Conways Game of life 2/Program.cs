using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conways_Game_of_life_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int gridSize = 20;

            //Create grid
            int[,] grid = new int[gridSize, gridSize];

            //Add a known shape
            grid[12, 12] = 1;
            grid[13, 13] = 1;
            grid[10, 13] = 1;
            grid[13, 10] = 1;
            grid[5, 5] = 1;
            grid[5, 6] = 1;
            grid[5, 7] = 1;
            grid[8, 6] = 1;
            grid[8, 7] = 1;
            grid[7, 7] = 1;
            


            while (true)
            {
                //Creat a new temporary grid
                int[,] new_grid = new int[gridSize, gridSize];
                int alive = 0;

                //Do some work to temp grid

                for (int i = 1; i < grid.GetLength(0) - 1; i++)
                {
                    for (int j = 1; j < grid.GetLength(1) - 1; j++)
                    {
                        //new_grid[i, j] = grid[i, j];

                        if ((grid[i, j]) == 0)//if space is dead
                        {
                            if (grid[i - 1, j] == 1)
                            {
                                alive++;
                            }
                            if (grid[i, j - 1] == 1)
                            {
                                alive++;
                            }
                            if (grid[i - 1, j - 1] == 1)
                            {
                                alive++;
                            }
                            if (grid[i + 1, j] == 1)
                            {
                                alive++;
                            }
                            if (grid[i, j + 1] == 1)
                            {
                                alive++;
                            }
                            if (grid[i + 1, j + 1] == 1)
                            {
                                alive++;
                            }
                            if (grid[i - 1, j + 1] == 1)
                            {
                                alive++;
                            }
                            if (grid[i + 1, j - 1] == 1)
                            {
                                alive++;
                            }

                            if (alive == 3)
                            {
                                new_grid[i, j] = 1;
                            }
                            alive = 0;

                        }//end of if

                        // checking live cells
                        if (grid[i, j] == 1)
                        {
                            if (grid[i - 1, j] == 1)
                            {
                                alive++;
                            }
                            if (grid[i, j - 1] == 1)
                            {
                                alive++;
                            }
                            if (grid[i - 1, j - 1] == 1)
                            {
                                alive++;
                            }
                            if (grid[i + 1, j] == 1)
                            {
                                alive++;
                            }
                            if (grid[i, j + 1] == 1)
                            {
                                alive++;
                            }
                            if (grid[i + 1, j + 1] == 1)
                            {
                                alive++;
                            }
                            if (grid[i - 1, j + 1] == 1)
                            {
                                alive++;
                            }
                            if (grid[i + 1, j - 1] == 1)
                            {
                                alive++;
                            }

                            if (alive != 2 && alive != 3)
                            {
                                new_grid[i, j] = 0;
                            }
                            else
                            {
                                new_grid[i, j] = 1;
                            }
                            alive = 0;
                        }
                        Console.Write(new_grid[i, j]);
                    }
                    Console.WriteLine();
                }//end of for loop



                //Copy temp grid over original grid
                grid = new_grid;

                //clear the screen
                Console.Clear();
                //Print grid

                for (int i = 1; i < gridSize; i++)
                {
                    for (int j = 1; j < gridSize; j++)
                    {
                        Console.Write(grid[i, j]);
                    }
                    Console.WriteLine();
                }

                //wait until enter is hit
                // Console.ReadLine();
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(.5));
            }//end of main loop
        }//end of main
    }
}
