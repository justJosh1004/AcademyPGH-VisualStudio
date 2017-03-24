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
                string[,] grid = new string[8, 8];
                Console.WriteLine("vY 1 2 3 4 5 6 7 8");
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        grid[i, j] = Convert.ToString(i);
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
                int[] ship1 = { 3, 5 };//sets the coordinates for the first ship
                int[] ship2 = { 6, 4 };//sets the coordinates for the second ship


                bool game_on = true;
                int hits = 0; //keeps track of how many ships are left on the grid

                while (game_on == true) //game will play again unless the user says no at the end of the game
                {
                    //pick a square
                    string[] user_pick = new string [2];//takes in the users guess
                    int[] pick = new int [2];//stores their guess as an integer

                    bool choice = false;//used to check condition for taking in coordinates

                    //pick the x coordinate
                    while (choice == false)//loop to keep asking for an x coordinate until a valid one is received
                    {
                        while (true)//loop to check if the user types in a number
                        {
                            Console.WriteLine("pick an x coordinate from 1 to 8");
                            user_pick[0] = Console.ReadLine();
                            if (int.TryParse(user_pick[0], out pick[0]))//if an acceptable number is typed in, it is stored to x_pick
                            {
                                break;//gets out of the loop
                            }
                            else
                            {
                                Console.WriteLine("Please choose a number from 1 to 8.");
                            }
                        }
                        pick[0] = Convert.ToInt32(user_pick[0]);//convert the x coordinate from a string to an integer.  not sure if needed. stil works without
                        if (pick[0] != 8 && pick[0] != 1 && pick[0] != 2 && pick[0] != 3 && pick[0] != 4 && pick[0] != 5 && pick[0] != 6 && pick[0] != 7)//checks to see if the number they chose is within range
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
                            user_pick[1] = Console.ReadLine();
                            if (int.TryParse(user_pick[1], out pick[1]))//if an acceptable number is typed in, it is stored in y_pick
                            {
                                break;//gets out of loop
                            }
                            else
                            {
                                Console.WriteLine("Please choose a number from 1 to 8.");
                            }
                        }
                        pick[1] = Convert.ToInt32(user_pick[1]);//convert the y coordinate from a string to an integer.  not sure if this is need.  still works without
                        /*TRYING TO MAKE THIS WORK to shorten code but it keeps running the WriteLine
                        for (int i = 0; i <= 8; i++)
                        {
                            if (pick[1] != i)
                            {
                                Console.WriteLine("That is not a valid coordinate.  Please try again.");
                            }
                            else
                            {
                                choice = true;//have a valid number and exits the loop
                            }
                        }
                        */
                        if (pick[1] != 8 && pick[1] != 1 && pick[1] != 2 && pick[1] != 3 && pick[1] != 4 && pick[1] != 5 && pick[1] != 6 && pick[1] != 7)//checks to see if number they chose is within range
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
                    if ((pick[0] == ship1[0] && pick[1] == ship1[1]) || (pick[0] == ship2[0] && pick[1] == ship2[1]))//if user hits the ship
                    {
                        grid[pick[1] - 1, pick[0] - 1] = "X";//changes the display to show a hit
                        //makes the grid
                        //end of grid code

                        Console.WriteLine("\n");
                        Console.WriteLine("HIT!");
                        hits++;//adds to the counter to keep track of ships on the grid
                    }
                    else
                    {
                        grid[pick[1] - 1, pick[0] - 1] = "M";//changes the display for a miss
                        //makes the grid
                        //end of grid code
                        Console.WriteLine("\n");
                        Console.WriteLine("MISS! Try again!");
                    }
                    //drawGrid();
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
        }//end of main 

        static drawGrid()
        {
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
            return grid;
        }//end of drawGrid
    }
}
