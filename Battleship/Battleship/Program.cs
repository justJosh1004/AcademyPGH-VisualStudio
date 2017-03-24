using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Program
    {
        static void Main(string[] args)
        {
            bool play = true;
            while (play == true)
            {
                //makes the grid
                int[,] grid = new int[8, 8];
                Console.WriteLine("vY 1 2 3 4 5 6 7 8");
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        grid[i, j] = 0;
                    }
                }

                for (int i = 0; i < 8; i++)
                {
                    Console.Write((i + 1) + "  ");
                    for (int j = 0; j < 8; j++)
                    {
                        Console.Write(grid[i, j] + " ");
                    }
                    Console.Write(" " + (i + 1));
                    Console.WriteLine();
                }
                Console.WriteLine(" X>1 2 3 4 5 6 7 8");
                //end of grid code
                Console.WriteLine("\n");

                //assign ships on the grid
                int ship1_x = 3;
                int ship1_y = 5;
                int ship2_x = 6;
                int ship2_y = 4;

                bool game_on = true;
                int hits = 0; //keeps track of how many ships are left on the grid

                while (game_on == true) //game will play again unless the user says no at the end of the game
                {
                    //pick a square
                    string user_x_pick;//takes what  user chooses for x coordinate
                    string user_y_pick;//takes what user chooses for y coordinate
                    int x_pick = 0;//stores x coordinate as an integer
                    int y_pick = 0;//stores y coordinate as an integer
                    bool choice = false;//used to check condition for taking in coordinates

                    //pick the x coordinate
                    while (choice == false)//loop to keep asking for an x coordinate until a valid one is received
                    {
                        while (true)//loop to check if the user types in a number
                        {
                            Console.WriteLine("pick an x coordinate from 1 to 8");
                            user_x_pick = Console.ReadLine();
                            if (int.TryParse(user_x_pick, out x_pick))//if a number is typed in, it is stored to x_pick
                            {
                                break;//gets out of the loop
                            }
                            else
                            {
                                Console.WriteLine("Please choose a number from 1 to 8.");
                            }
                            
                        }
                        x_pick = Convert.ToInt32(user_x_pick);//convert the x coordinate from a string to an integer.  not sure if needed. stil works without
                        if (x_pick != 8 && x_pick != 1 && x_pick != 2 && x_pick != 3 && x_pick != 4 && x_pick != 5 && x_pick != 6 && x_pick != 7)//checks to see if the number they chose is within range
                        {
                            Console.WriteLine("That is not a valid coordinate.  Please try again.");
                        }
                        else
                        {
                            choice = true;//have a valid number and exits out of loop
                        }
                    }

                    //pick the y coordinate
                    choice = false;//resets the conditoin to false for y coordinate
                    while (choice == false)//loop to keep asking for a y coordinate until a valid one is recieved
                    {
                        while (true)//loop to check if user typed in a number
                        {
                            Console.WriteLine("pick a y coordinate from 1 to 8");
                            user_y_pick = Console.ReadLine();
                            if (int.TryParse(user_y_pick, out y_pick))//if a number is typed in, it is stored in y_pick
                            {
                                break;//gets out of loop
                            }
                            else
                            {
                                Console.WriteLine("Please choose a number from 1 to 8.");
                            }

                        }
                        y_pick = Convert.ToInt32(user_y_pick);//convert the y coordinate fro a string to an integer.  not sure if this is need.  still works without
                        if (y_pick != 8 && y_pick != 1 && y_pick != 2 && y_pick != 3 && y_pick != 4 && y_pick != 5 && y_pick != 6 && y_pick != 7)//checks to see if number they chose is within range
                        {
                            Console.WriteLine("That is not a valid coordinate.  Please try again.");
                        }
                        else
                        {
                            choice = true;//have a valid number and exits the loop
                        }
                    }

                    Console.Clear();

                    //hit or miss
                    //grids are all set to zero, need o figure out how to compare place and not value
                    if ((x_pick == ship1_x && y_pick == ship1_y) || (x_pick == ship2_x && y_pick == ship2_y))//if user hits the ship
                    {
                        grid[y_pick - 1, x_pick - 1] = 4;//changes the display to show a hit
                        //makes the grid
                        Console.WriteLine("vY 1 2 3 4 5 6 7 8");
                        for (int i = 0; i < 8; i++)
                        {
                            Console.Write((i + 1) + "  ");
                            for (int j = 0; j < 8; j++)
                            {
                                Console.Write(grid[i, j] + " ");
                            }
                            Console.Write(" " + (i + 1));
                            Console.WriteLine();
                        }
                        Console.WriteLine(" X>1 2 3 4 5 6 7 8");
                        //end of grid code

                        Console.WriteLine("\n");
                        Console.WriteLine("HIT!");
                        hits++;//adds to the counter to keep track of ships on the grid
                    }
                    else
                    {
                        grid[y_pick - 1, x_pick - 1] = 7;//changes the display for a miss
                        //makes the grid
                        Console.WriteLine("vY 1 2 3 4 5 6 7 8");
                        for (int i = 0; i < 8; i++)
                        {
                            Console.Write((i + 1) + "  ");
                            for (int j = 0; j < 8; j++)
                            {
                                Console.Write(grid[i, j] + " ");
                            }
                            Console.Write(" " + (i + 1));
                            Console.WriteLine();
                        }
                        Console.WriteLine(" X>1 2 3 4 5 6 7 8");
                        //end of grid code
                        Console.WriteLine("\n");
                        Console.WriteLine("MISS! Try again!");
                    }

                    //ends loops if all ships are sunk
                    if (hits == 2)
                    {
                        Console.WriteLine("You WIN!");
                        game_on = false;
                    }
                }

                Console.WriteLine("Would you like to play again? Y/N");//ask to play again
                string user_ans = Console.ReadLine().ToUpper();
                if (user_ans == "N")
                {
                    play = false;//ends the game and loop 
                }
                Console.Clear();
            }
        }
    }
}
