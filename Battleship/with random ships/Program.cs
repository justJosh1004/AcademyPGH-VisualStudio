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
                        grid[i, j] = "~";
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
                Random ship = new Random(); //generates a random number
                bool ship_check = false; //checks to make sure ships aren't in the same place

                int[] ship1 = { ship.Next(1, 8), ship.Next(1, 8) }; //generate a number between 1 and 8 
                int[] ship2 = new int[2];
                int[] ship3 = new int[2];
                int[] ship4 = new int[2];
                
                while (ship_check == false) //checks to see ship isn't the same as previous ships
                {
                    ship2[0] = ship.Next(1, 8); //generate a random number between 1 and 8
                    ship2[1] = ship.Next(1, 8);
                    if (ship2[0] != ship1[0] && ship2[1] != ship1[1])
                    {
                        ship_check = true;
                    }
                }
                ship_check = false;

                while (ship_check == false)//checks to see ship isn't the same as previous ships
                {
                    ship3[0] = ship.Next(1, 8);
                    ship3[1] = ship.Next(1, 8);
                    if (ship3[0] != ship1[0] && ship3[1] != ship1[1] && ship3[0] != ship2[0] && ship3[1] != ship2[1])
                    {
                        ship_check = true;
                    }
                }
                ship_check = false;

                while (ship_check == false)//checks to see ship isn't the same as previous ships
                {
                    ship4[0] = ship.Next(1, 8);
                    ship4[1] = ship.Next(1, 8);
                    if (ship4[0] != ship1[0] && ship4[1] != ship1[1] && ship4[0] != ship2[0] && ship4[1] != ship2[1] && ship4[0] != ship3[0] && ship4[1] != ship3[1])
                    {
                        ship_check = true;
                    }
                }

                bool game_on = true;
                int hits = 0; //keeps track of how many ships are left on the grid

                while (game_on == true) //game will play again unless the user says no at the end of the game
                {
                    if (hits < 3)
                    {
                        Console.WriteLine("There are " + (4 - hits) + " ships left");
                    }
                    else if (hits == 3)
                    {
                        Console.WriteLine("Only 1 ship left!");
                    }
                    //pick a square
                    string[] user_pick = new string[2];//takes in the users guess
                    int[] pick = new int[2];//stores their guess as an integer

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
                    if ((pick[0] == ship1[0] && pick[1] == ship1[1]) || (pick[0] == ship2[0] && pick[1] == ship2[1]) || (pick[0] == ship3[0] && pick[1] == ship3[1])
                        || (pick[0] == ship4[0] && pick[1] == ship4[1]))//if user hits the ship
                    {
                        grid[pick[1] - 1, pick[0] - 1] = "X";//changes the display to show a hit

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
                        grid[pick[1] - 1, pick[0] - 1] = "M";//changes the display for a miss

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

                        Random miss_number = new Random();
                        int miss_comment = miss_number.Next(0, 10);
                        string[] comment = new string[11];
                        comment[0] = "I must tell you friendly in your ear, sell when you can, you are not for all markets.";
                        comment[1] = "Thou wit’s as thick as a Tewkesbury mustard.";
                        comment[2] = "Thou art as fat as butter.";
                        comment[3] = "Thou art unfit for any place but hell.";
                        comment[4] = "Thou clay-brained guts, thou knotty-pated fool, thou whoreson obscene greasy tallow-catch!";
                        comment[5] = "Thou damned and luxurious mountain goat.";
                        comment[6] = "Thou sodden-witted lord! Thou hast no more brain than I have in mine elbows.";
                        comment[7] = "Thou brain is as dry as the remainder biscuit after voyage.";
                        comment[8] = "Villain, I have done thy mother";
                        comment[9] = "If thou wilt needs marry, marry a fool; for wise men know well enough what monsters you make of them";
                        comment[10] = "Methink’st thou art a general offence and every man should beat thee.";

                        Console.WriteLine("\n");
                        Console.WriteLine("MISS! Try again!");
                        Console.WriteLine(comment[miss_comment] + "\n");
                    }

                    //ends loops if all ships are sunk
                    if (hits == 4)
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
