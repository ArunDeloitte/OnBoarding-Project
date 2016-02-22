using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Mono.Data.Sqlite;
using System.Data;
using MonoDroid;
using System.Transactions;
using System.IO;




namespace LoginApp.Droid
{
    class MySqLite
    {
        public static SqliteConnection connection;
        public  List<string> DoSomeDataAccess()
        {
            
            List<string> output= new List<string>();
            output.Add(string.Empty);
            // determine the path for the database file
            string dbPath = Path.Combine(
                System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                "adodemo.db3");

            bool exists = File.Exists(dbPath);

            if (!exists)
            {
                Console.WriteLine("Creating database");
                // Need to create the database before seeding it with some data
                Mono.Data.Sqlite.SqliteConnection.CreateFile(dbPath);
                connection = new SqliteConnection("Data Source=" + dbPath);

                var commands = new[] {
            "CREATE TABLE [UserCredential] (_id ntext, Username ntext, Password ntext);",
            "INSERT INTO [UserCredential] ([_id], [Username],[Password]) VALUES ('1', 'aniruth.sabapathy@gmail.com','Pa22w0rd')",
            "INSERT INTO [UserCredential] ([_id], [Username],[Password]) VALUES ('2', 'mahendranjeeva@gmail.com','Pa22w0rd')",
            "INSERT INTO [UserCredential] ([_id], [Username],[Password]) VALUES ('3', 'manideepan.m@gmail.com','Pa22w0rd')"
        };
                // Open the database connection and create table with data
                connection.Open();
                foreach (var command in commands)
                {
                    using (var c = connection.CreateCommand())
                    {
                        c.CommandText = command;
                        var rowcount = c.ExecuteNonQuery();
                        Console.WriteLine("\tExecuted " + command);
                    }
                }
            }
            else
            {
                Console.WriteLine("Database already exists");
                // Open connection to existing database file
                connection = new SqliteConnection("Data Source=" + dbPath);
                connection.Open();
            }

            // query the database to prove data was inserted!
            using (var contents = connection.CreateCommand())
            {
                contents.CommandText = "SELECT [_id], [Username],[Password] from [UserCredential]";
                var r = contents.ExecuteReader();
                Console.WriteLine("Reading data");
                while (r.Read())
                {
                   
                    output.Add( String.Format("Key={0}; Username={1}; Password={2}",
                                      r["_id"].ToString(),
                                      r["Username"].ToString(),
                                      r["Password"].ToString()));
                   
                }

            }
            connection.Close();

            return output;
        }
    }
}