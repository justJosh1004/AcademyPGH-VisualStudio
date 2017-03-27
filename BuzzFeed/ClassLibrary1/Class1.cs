using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ClassLibrary1
{
    public class QuizClass
    {
        SqlCommand command;
        SqlDataReader reader;
        
        public void makeNewUser(string newUserName)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=C:\Users\WhitneyW\Documents\Visual Studio 2015\Projects\BuzzFeed\ClassLibrary1\Database1.mdf");
            connection.Open();

            command = new SqlCommand($"INSERT INTO users (Name) VALUES ('{newUserName}')", connection);
            command.ExecuteNonQuery();

            connection.Close();
        }//END OF makeNewUser
        
        public void displayUsers()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=C:\Users\WhitneyW\Documents\Visual Studio 2015\Projects\BuzzFeed\ClassLibrary1\Database1.mdf");
            connection.Open();

            command = new SqlCommand("SELECT * FROM Users", connection);
            reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine($"   {reader["id"]} - {reader["Name"]}");
                }
            }

            reader.Close();
            connection.Close();
        }//END OF displayUsers

        public void pickUser(int userNumber)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=C:\Users\WhitneyW\Documents\Visual Studio 2015\Projects\BuzzFeed\ClassLibrary1\Database1.mdf");
            connection.Open();

            command = new SqlCommand($"SELECT Name FROM Users WHERE id = {userNumber}");
            
        }//END OF pickUser

        public int pickQuiz()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=C:\Users\WhitneyW\Documents\Visual Studio 2015\Projects\BuzzFeed\ClassLibrary1\Database1.mdf");
            connection.Open();

            command = new SqlCommand("SELECT * FROM Quiz", connection);
            reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine($"These are the available quizzes:\n   {reader["id"]} - {reader["Name"]}");
                }
            }

            Console.Write("Type in the Quiz number: ");
            int quizChoice = Convert.ToInt32(Console.ReadLine());
            
            reader.Close();
            connection.Close();

            return quizChoice;
        }//END OF pickQuiz

        public void askQuestions(int quizChoice)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=C:\Users\WhitneyW\Documents\Visual Studio 2015\Projects\BuzzFeed\ClassLibrary1\Database1.mdf");
            connection.Open();

            command = new SqlCommand($"SELECT * FROM Questions WHERE quiz_id = {quizChoice}", connection);
            reader = command.ExecuteReader();

            List<int> results = new List<int>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int questionID = Convert.ToInt32(reader["SortOrder"]);
                    Console.WriteLine($"{reader["Title"]}");
                    
                    displayAnswers(questionID);

                    Console.WriteLine("Which answer do you most associate with?");
                    Console.Write("Put in the number of your answer:   ");
                    int userAnswer = Convert.ToInt32(Console.ReadLine());
                    
                    results.Add(userAnswer);
                    //storeAnswers(userAnswer);
                }
                
            }

            //Tallies up the result and picks the highest occurring one
            int finalResult = results.GroupBy(x => x)
                                        .OrderByDescending(x => x.Count())
                                        .First().Key;
            Console.WriteLine(finalResult);

            showResults(finalResult);

            reader.Close();
            connection.Close();

        }//END OF askQuestions

        public void displayAnswers(int questionID)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=C:\Users\WhitneyW\Documents\Visual Studio 2015\Projects\BuzzFeed\ClassLibrary1\Database1.mdf");
            connection.Open();

            command = new SqlCommand($"SELECT * FROM Answers WHERE question_id = {questionID}", connection);
            SqlDataReader answerReader = command.ExecuteReader();

            if (answerReader.HasRows)
            {
                while (answerReader.Read())
                {
                    Console.WriteLine($"   {answerReader["result_id"]} - {answerReader["Text"]}");
                }
            }

            answerReader.Close();
            connection.Close();
        }//END OF displayAnswers
        

        public void storeAnswers(int userAnswer)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=C:\Users\WhitneyW\Documents\Visual Studio 2015\Projects\BuzzFeed\ClassLibrary1\Database1.mdf");
            connection.Open();

            //command = new SqlCommand($"SELECT * FROM Answers JOIN Result ON Answers.result_id = Results.id", connection);
            command = new SqlCommand($"INSERT INTO ");
            reader = command.ExecuteReader();


        }//END OF storeAnswers

        public void showResults(int finalResult)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=C:\Users\WhitneyW\Documents\Visual Studio 2015\Projects\BuzzFeed\ClassLibrary1\Database1.mdf");
            connection.Open();

            command = new SqlCommand($"SELECT * FROM Results", connection);
            reader = command.ExecuteReader();

            Console.WriteLine($"{reader["Title"]}\n   {reader["Text"]}");

            reader.Close();
            connection.Close();


        }//END OF showResults
    }
}
