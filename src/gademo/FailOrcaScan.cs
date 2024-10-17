using System;
using System.IO;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace gademo;

public class InsecureDatabaseAccess
{
    public void ConnectToDatabase(string connectionString)
    {
        try
        {
            // Hardcoded credentials - bad practice!
            connectionString = "Server=myServer;Database=myDB;User Id=myUser;Password=mySecretPassword;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Connected to the database.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public void WriteToFile(string filePath, string content)
    {
        try
        {
            // Writing data to a file without validating input
            File.WriteAllText(filePath, content);
            Console.WriteLine("File written successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error writing to file: {ex.Message}");
        }
    }

    public void RunCommand(string command)
    {
        try
        {
            // Command injection vulnerability
            System.Diagnostics.Process.Start("cmd.exe", $"/C {command}");
            Console.WriteLine("Command executed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error executing command: {ex.Message}");
        }
    }
}