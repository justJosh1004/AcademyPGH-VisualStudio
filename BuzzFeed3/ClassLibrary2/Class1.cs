using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ClassLibrary2
{
    public class QuizClass
    {
        SqlCommand command;
        SqlDataReader reader;
        
        public void makeNewUser(string newUserName)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=C:\Users\WhitneyW\Documents\Visual Studio 2015\Projects\BuzzFeed3\ClassLibrary2\Database2.mdf");
            connection.Open();

            command = new SqlCommand($"INSERT INTO users (Name) VALUES ('{newUserName}'", connection);

            connection.Close();
        }
        
        public void displayUsers()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=C:\Users\WhitneyW\Documents\Visual Studio 2015\Projects\BuzzFeed3\ClassLibrary2\Database2.mdf");
            connection.Open();

            command = new SqlCommand("SELECT * FROM Users");
            reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine($"{"id"} - {"Name"}");
                }
            }

            reader.Close();
            connection.Close();
        }

        public void pickUser(int userNumber)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=C:\Users\WhitneyW\Documents\Visual Studio 2015\Projects\BuzzFeed3\ClassLibrary2\Database2.mdf");
            connection.Open();

            command = new SqlCommand("SELECT * FROM Users");

            Console.WriteLine($"SELECT Name FROM Users WHERE id = {userNumber}");
        }
    }
}
