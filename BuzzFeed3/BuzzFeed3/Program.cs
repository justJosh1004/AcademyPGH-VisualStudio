using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ClassLibrary2;

namespace BuzzFeed3
{
    class Program
    {
        static void Main(string[] args)
        {

            bool keepPlaying = true;
            while (keepPlaying == true)
            {
                QuizClass useClass = new QuizClass();
                Console.WriteLine("Do you want to take a (Q)uiz or e(X)it?");
                string answer = Console.ReadLine().ToUpper();

                if (answer == "Q")
                {
                    //get the username
                    Console.WriteLine("Do you want to create a (N)ew user or choose an (E)xisting user?");
                    string kindOfuser = Console.ReadLine().ToUpper();

                    if (kindOfuser == "N")
                    {
                        Console.WriteLine("What is the name that you would like to use?");
                        string newUserName = Console.ReadLine();
                        useClass.makeNewUser(newUserName);
                    }
                    else if (kindOfuser == "E")
                    {
                        Console.WriteLine("Which user would you like to use?");
                        useClass.displayUsers();
                        Console.Write("What is the number of the user you want to use?");
                        int userNumberChoice = Convert.ToInt32(Console.ReadLine());
                        useClass.pickUser(userNumberChoice);
                    }
                    else
                    {
                        Console.WriteLine($"{kindOfuser} is not a valid choice.  Please type in N for a new user or E to choose an existing one.");
                    }

                }//END OF Q
                else if (answer == "X")
                {
                    Console.WriteLine("Thank you for taking our quiz.  Good bye!");
                    keepPlaying = false;
                }//END OF X
                else
                {
                    Console.WriteLine($"{answer} was not a valid response.  Please Try again.");
                }

            }//END OF MAIN LOOP
        }//END OF MAIN
    }//END OF CLASS
}
