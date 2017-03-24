using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Address_Book
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=C:\Users\WhitneyW\Documents\Visual Studio 2015\Projects\Address Book\Address Book\Database1.mdf");
            SqlCommand command;
            SqlDataReader reader;

            connection.Open();
            
            while (true)
            {
                string userInput = "";
                Console.WriteLine("Would you like to (A)dd a person, (E)dit a person, (D)elete a person, (S)earch for a person, (L)ist people, or e(X)it?"); //Maybe combine delete with edit?
                userInput = Console.ReadLine().ToUpper();

                if (userInput == "A")
                {
                    Console.WriteLine("What is the first name?");
                    string userFirstName = Console.ReadLine();

                    Console.WriteLine("What is the last name?");
                    string userLastName = Console.ReadLine();

                    Console.WriteLine("What is the street and number they live in?");
                    string userStreet = Console.ReadLine();

                    Console.WriteLine("What city are they in?");
                    string userCity = Console.ReadLine();

                    Console.WriteLine("What state is it in? ex. PA");
                    string userState = Console.ReadLine();

                    Console.WriteLine("What is the zipcode?");
                    string userZip = Console.ReadLine();

                    Console.WriteLine("What is your phone number?");
                    string userPhone = Console.ReadLine();

                    command = new SqlCommand($"INSERT INTO AddressBook (firstName, lastName, Street, City, State, Zip, Phone) VALUES ('{userFirstName}', '{userLastName}', '{userStreet}', '{userCity}' , '{userState}', '{userZip}', '{userPhone}')", connection);
                    
                    reader = command.ExecuteReader();
                    reader.Close();
                    
                }//END OF ADD
                else if (userInput == "E")
                {
                    bool editing = true;
                    while (editing == true)
                    {
                        //showing the table so they know which ones they can edit
                        command = new SqlCommand("SELECT * FROM AddressBook", connection);
                        reader = command.ExecuteReader();
                        while (reader.Read()) //shows the table so user knows their choices
                        {
                            Console.WriteLine(reader["Id"] + "   " + reader["firstName"] + " " + reader["lastname"] + " " + reader["Street"] + " " + reader["City"] + " " + reader["State"] + " " + reader["Zip"] + " " + reader["Phone"]);
                        }
                        reader.Close();

                        Console.WriteLine("What is the ID of the person you want to edit?");
                        string editID = Console.ReadLine();

                        Console.WriteLine("Do you want to change a person's (N)ame, (S)treet, (C)ity, (S)tate, (Z)ip, or (P)hone? If you are done editing, enter X to exit.");
                        string editChoice = Console.ReadLine().ToUpper();

                        if (editChoice == "N")
                        {
                            Console.WriteLine("What is the first name?");
                            string userFirstName = Console.ReadLine();

                            Console.WriteLine("What is the last name?");
                            string userLastName = Console.ReadLine();

                            command = new SqlCommand($"UPDATE AddressBook set firstName = '{userFirstName}', lastName = '{userLastName}' WHERE Id = '{editID}'", connection);
                            command.ExecuteNonQuery();//executes the command and doesn't return anything
                        }
                        else if (editChoice == "S")
                        {
                            Console.WriteLine("What is the street and number they live in?");
                            string userStreet = Console.ReadLine();

                            command = new SqlCommand($"UPDATE AddressBook set Street = '{userStreet}' WHERE Id = '{editID}'", connection);
                            command.ExecuteNonQuery();
                        }
                        else if (editChoice == "C")
                        {
                            Console.WriteLine("What city are they in?");
                            string userCity = Console.ReadLine();

                            command = new SqlCommand($"UPDATE AddressBook set City = '{userCity}' WHERE Id = '{editID}'", connection);
                            command.ExecuteNonQuery();
                        }
                        else if (editChoice == "S")
                        {
                            Console.WriteLine("What state is it in? ex. PA");
                            string userState = Console.ReadLine();

                            command = new SqlCommand($"UPDATE AddressBook set State = '{userState}' WHERE Id = '{editID}'", connection);
                            command.ExecuteNonQuery();
                        }
                        else if (editChoice == "Z")
                        {
                            Console.WriteLine("What is the zipcode?");
                            string userZip = Console.ReadLine();

                            command = new SqlCommand($"UPDATE AddressBook set Zip = '{userZip}' WHERE Id = '{editID}'", connection);
                            command.ExecuteNonQuery();
                        }
                        else if (editChoice == "P")
                        {
                            Console.WriteLine("What is your phone number?");
                            string userPhone = Console.ReadLine();

                            command = new SqlCommand($"UPDATE AddressBook set Phone = '{userPhone}' WHERE Id = '{editID}'", connection);
                            command.ExecuteNonQuery();
                        }
                        else if (editChoice == "X")
                        {
                            editing = false;
                        }
                        else
                            Console.WriteLine($"{editChoice} was not recognized as a valid choice. Please try again.");
                    }
                }//END OF EDIT
                else if (userInput == "D")
                {
                    bool deleting = true;
                    while (deleting == true)
                    {
                        //showing the table so they know which ones they can edit
                        command = new SqlCommand("SELECT * FROM AddressBook", connection);
                        reader = command.ExecuteReader();
                        while (reader.Read()) //shows the table so user knows their choices
                        {
                            Console.WriteLine(reader["Id"] + "   " + reader["firstName"] + " " + reader["lastname"] + " " + reader["Street"] + " " + reader["City"] + " " + reader["State"] + " " + reader["Zip"] + " " + reader["Phone"]);
                        }
                        reader.Close();

                        Console.WriteLine("What is the ID of the person you want to delete?");
                        string deleteID = Console.ReadLine();

                        command = new SqlCommand($"DELETE FROM AddressBook WHERE {deleteID}", connection);
                        command.ExecuteNonQuery();

                        Console.WriteLine("Do you want to delete another person from the list? Y/N");
                        string keepDeleting = Console.ReadLine().ToUpper();

                        if (keepDeleting == "N")
                        {
                            deleting = false;
                        }
                    }
                }//END OF DELETE
                else if (userInput == "L")
                {
                    command = new SqlCommand("SELECT * FROM AddressBook", connection);
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.WriteLine(reader["firstName"] + " " + reader["lastname"] + " " + reader["Street"] + " " + reader["City"] + " " + reader["State"] + " " + reader["Zip"] + " " + reader["Phone"]);
                    }

                    reader.Close();
                }//END OF LIST
                else if (userInput == "X")
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }
                Console.ReadLine();
            }//END OF MAIN LOOP
            connection.Close();
        }//END OF MAIN
    }//END OF CLASS
}
