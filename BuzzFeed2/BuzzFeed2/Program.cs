using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BuzzFeed2
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=C:\Users\WhitneyW\Documents\Visual Studio 2015\Projects\BuzzFeed2\BuzzFeed2\Database1.mdf");
            connection.Open();

            bool keepPlaying = true;
            while (keepPlaying == true)
            {
                SqlCommand command;
                SqlDataReader reader;

                Console.WriteLine("Do you want to take a (Q)uiz or e(X)it?");
                string answer = Console.ReadLine().ToUpper();

                if (answer == "Q")
                {

                    //get a user name
                    Console.WriteLine("What is your name?");
                    string userName = Console.ReadLine();

                    command = new SqlCommand($"INSERT INTO Users (Name) VALUES ('{userName}')", connection);
                    command.ExecuteNonQuery();

                    //ask what quiz they want to take
                    Console.WriteLine("What quiz would you like to do?");

                    command = new SqlCommand("SELECT * FROM Quiz", connection);
                    reader = command.ExecuteReader();
                    
                    
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"These are the available quizzes:\n   {reader["Id"]} - {reader["Name"]}");
                        }
                    }
                    Console.Write("Type in the Quiz number:  ");
                    int quizChoice = Convert.ToInt32(Console.ReadLine());

                    reader.Close();
                    //ask a question and show choices
                    SqlCommand questionsCommand = new SqlCommand($"SELECT * FROM Questions JOIN Answers ON Questions.id = Answers.question_id WHERE Questions.quiz_id = {quizChoice}", connection);
                    reader = questionsCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        string oldQuestion ="";
                        string X = "";
                        while (reader.Read())
                        {
                            if (reader["Id"].ToString() != oldQuestion) //shows the question once
                            {
                                X = oldQuestion;
                                if ((X != reader["Id"].ToString()) && (oldQuestion != ""))
                                    {
                                        //get an answer from user
                                        Console.Write("Enter the number of the answer that you most associate with: ");
                                         int quizAnswer = Convert.ToInt32(Console.ReadLine());
                                    }
                                Console.WriteLine($"{reader["title"]}"); //title is the title of the question
                                oldQuestion = reader["Id"].ToString(); //setting old question equal to the current title
                            }
                                Console.WriteLine($"\t{reader["result_id"]} - {reader["text"]}"); //shows the possible answers for each questions
                            
                        }
                        
                    }
                    

                    //store answer

                    //tally result of answers

                    //give user the result

                    reader.Close();
                }//END OF Q
                else if (answer == "X")
                {
                    Console.WriteLine("Thank you for taking our quiz.  Good bye!");
                    keepPlaying = false;
                }
                else
                {
                    Console.WriteLine($"{answer} was not a valid response.  Please Try again.");
                }
            }//END OF MAIN LOOP
            connection.Close();
        }//END OF MAIN
    }//END OF CLASS


}
