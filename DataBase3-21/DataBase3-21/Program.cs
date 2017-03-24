using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataBase3_21
{
    class Program
    {
        static void Main(string[] args)
        {
            
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=C:\Users\WhitneyW\Documents\Visual Studio 2015\Projects\DataBase3-21\DataBase3-21\Database1.mdf;Integrated Security=True");

            SqlCommand command;
            SqlDataReader mah_var;
            connection.Open();

            string answer = "";
            Console.WriteLine("Would you like to (S)ave a person or list?");
            answer = Console.ReadLine().ToUpper();

            if (answer == "S")
            {
                Console.WriteLine("Enter your name: ");
                string user_name = Console.ReadLine();
                Console.WriteLine("Enter your address:");
                string user_address = Console.ReadLine();
                // do some stuff
                command = new SqlCommand($"INSERT INTO addressbook (name, address, city, state, zip) VALUES ('{user_name}', '{user_address}', 'Pittsburgh', 'PA', '15226');", connection);
                mah_var = command.ExecuteReader();
            }
            else
            {
                command = new SqlCommand("SELECT * FROM addressbook", connection);
                mah_var = command.ExecuteReader();
                if (mah_var.HasRows)
                {
                    while (mah_var.Read())
                    {
                        Console.WriteLine(mah_var["Name"] + ": " + mah_var["Address"]);
                    }
                }
                mah_var.Close();
                // do some other stuff
            }
           
            connection.Close();
            Console.ReadLine();
        }
    }
}
