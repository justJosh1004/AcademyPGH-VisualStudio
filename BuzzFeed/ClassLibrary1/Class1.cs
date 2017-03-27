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

        public int makeNewUser(string newUserName)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=C:\Users\WhitneyW\Documents\Visual Studio 2015\Projects\BuzzFeed\ClassLibrary1\Database1.mdf");
            connection.Open();

            command = new SqlCommand($"INSERT INTO users (Name) VALUES ('{newUserName}'); SELECT @@Identity AS id", connection);
            command.ExecuteNonQuery();

            int user_id = Convert.ToInt32(reader["id"]);
            connection.Close();

            return user_id;
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
        
        public int pickUser(int userNumber)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=C:\Users\WhitneyW\Documents\Visual Studio 2015\Projects\BuzzFeed\ClassLibrary1\Database1.mdf");
            connection.Open();

            command = new SqlCommand($"SELECT * FROM Users", connection);
            reader = command.ExecuteReader();

            Console.WriteLine("HERE");
            Console.WriteLine(reader["id"]);

            int user_id = Convert.ToInt32(reader["id"]);

            reader.Close();

            return user_id;
            
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

        public void askQuestions(int quizChoice, int userID)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=C:\Users\WhitneyW\Documents\Visual Studio 2015\Projects\BuzzFeed\ClassLibrary1\Database1.mdf");
            connection.Open();

            command = new SqlCommand($"SELECT * FROM Questions WHERE quiz_id = {quizChoice}", connection);
            reader = command.ExecuteReader();

            //List<int> results = new List<int>();

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
                    
                    //results.Add(userAnswer);
                    storeAnswers(userAnswer, userID);
                }
            }

            //Tallies up the result and picks the highest occurring one
            //int finalResult = results.GroupBy(x => x)
            //                            .OrderByDescending(x => x.Count())
            //                            .First().Key;
            //Console.WriteLine(finalResult);

            showResults(userID);

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
        

        public void storeAnswers(int userAnswer, int userID)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=C:\Users\WhitneyW\Documents\Visual Studio 2015\Projects\BuzzFeed\ClassLibrary1\Database1.mdf");
            connection.Open();

            //command = new SqlCommand($"SELECT * FROM Answers JOIN Result ON Answers.result_id = Results.id", connection);
            command = new SqlCommand($"INSERT INTO UserAnswers (user_id, answer_id) VALUES ({userID}, {userAnswer})", connection);
            SqlDataReader storeAnswers = command.ExecuteReader();
            storeAnswers.Close();
            //reader.Close();
        }//END OF storeAnswers

        public void showResults(int userID)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=C:\Users\WhitneyW\Documents\Visual Studio 2015\Projects\BuzzFeed\ClassLibrary1\Database1.mdf");
            connection.Open();

            command = new SqlCommand($"SELECT TOP 1 results.id, Count(*) AS Total FROM UserAnswers JOIN answers ON answers.id = useranswers.answer_id JOIN results ON results.id = answers.result_id WHERE user_id = {userID} GROUP BY results.id ORDER BY Total DESC", connection);
            reader = command.ExecuteReader();
            reader.Read();
            string result_id = reader["id"].ToString();
            reader.Close();

            command = new SqlCommand($"SELECT * FROM Results WHERE id={result_id}", connection);
            reader = command.ExecuteReader();
            reader.Read();
            Console.WriteLine("The results are in!");
            Console.WriteLine(reader["Title"]);
            Console.WriteLine(reader["Text"]);
            reader.Close();

            /*
            command = new SqlCommand($"SELECT * FROM Results WHERE id = {finalResult}", connection);
            reader = command.ExecuteReader();

            Console.WriteLine($"{reader["Title"]}\n   {reader["Text"]}");

            reader.Close();
            connection.Close();
            */

        }//END OF showResults
    }
}
