using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ClassLibrary1;

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
                    int userID = 0;

                    if (kindOfuser == "N") //Making a new user
                    {
                        Console.WriteLine("What is the name that you would like to use?");
                        string newUserName = Console.ReadLine();
                        userID = useClass.makeNewUser(newUserName);
                    }
                    else if (kindOfuser == "E")  //using an exiting user  STILL need to work on associating the current user to the quiz
                    {
                        Console.WriteLine("Which user would you like to use?");
                        useClass.displayUsers();
                        Console.Write("What is the number of the user you want to use?   ");
                        userID = Convert.ToInt32(Console.ReadLine());
                    }
                    else
                    {
                        Console.WriteLine($"{kindOfuser} is not a valid choice.  Please type in N for a new user or E to choose an existing one.");
                    }

                    Console.WriteLine("What quiz would you like to take?"); //let the user pick what quiz they want
                    int userQuizChoice = useClass.pickQuiz();

                    useClass.askQuestions(userQuizChoice, userID);


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
