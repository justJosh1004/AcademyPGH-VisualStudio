using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Session3Database1
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=C:\Users\WhitneyW\Documents\Visual Studio 2015\Projects\Session3Database1\Session3Database1\Database1.mdf;Integrated Security=True");
            connection.Open();

            SqlCommand command = new SqlCommand("select * from address", connection);
            SqlDataReader reader = command.ExecuteReader();
            
            while (reader.Read())
            {
                Console.WriteLine(reader["Name"]);
            }
            reader.Close();
            connection.Close();

            Console.ReadLine();
        }
    }
}
