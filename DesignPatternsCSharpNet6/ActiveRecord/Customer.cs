﻿using System.Data;
using System.Data.SqlClient;

namespace DesignPatternsCSharpNet6.ActiveRecord;

public class Customer
{
    private const string CONNECTION_STRING =
        "Data Source=(local);Initial Catalog=DesignPatterns;Integrated Security=True";

    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsPremiumMember { get; set; }

    // Constructor is private.
    // Static methods are used to create a new Customer or load an existing Customer
    // This is not mandatory for the Active Record pattern, but is common
    private Customer(int id, string name, bool isPremiumMember)
    {
        Id = id;
        Name = name;
        IsPremiumMember = isPremiumMember;
    }

    // Create a new Customer object
    public static Customer CreateNew()
    {
        // Id of 0 indicates this is a new Customer that is not in the database
        return new Customer(0, "", false);
    }

    // Create/load an existing Customer object from the database
    public static async Task<Customer> GetByIdAsync(int id)
    {
        await using SqlConnection connection = new SqlConnection(CONNECTION_STRING);
        connection.Open();

        await using SqlCommand command = connection.CreateCommand();
        command.CommandType = CommandType.Text;

        command.CommandText = "SELECT TOP 1 * FROM [Customer] WHERE [Id] = @Id";
        command.Parameters.AddWithValue("@Id", id);

        SqlDataReader reader = await command.ExecuteReaderAsync();

        // If the query returned a row, create the Customer object and return it.
        if(reader.HasRows)
        {
            reader.Read();

            string name = (string)reader["Name"];
            bool isPremiumMember = (bool)reader["IsPremiumMember"];

            return new Customer(id, name, isPremiumMember);
        }

        return null;
    }

    // INSERT if new, otherwise UPDATE in the database
    public async void SaveAsync()
    {
        if (Id == 0)
        {
            await using SqlConnection connection = new SqlConnection(CONNECTION_STRING);
            connection.Open();

            await using SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.Text;

            // SELECT SCOPE_IDENTITY() returns the Id value the database created
            command.CommandText =
                "INSERT INTO [Customer] ([Name], [IsPremiumMember]) VALUES (@Name, @IsPremiumMember); SELECT SCOPE_IDENTITY();";
            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@IsPremiumMember", IsPremiumMember);

            // Get the Id generated by the database and save it to the object's property
            Id = (int)await command.ExecuteScalarAsync();
        }
        else
        {
            await using SqlConnection connection = new SqlConnection(CONNECTION_STRING);
            connection.Open();

            await using SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.Text;

            command.CommandText =
                "UPDATE [Customer] SET [Name] = @Name, [IsPremiumMember] = @IsPremiumMember WHERE [Id] = @Id";
            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@IsPremiumMember", IsPremiumMember);
            command.Parameters.AddWithValue("@Id", Id);

            await command.ExecuteNonQueryAsync();
        }
    }

    public async void DeleteAsync()
    {
        await using SqlConnection connection = new SqlConnection(CONNECTION_STRING);
        connection.Open();

        await using SqlCommand command = connection.CreateCommand();
        command.CommandType = CommandType.Text;

        command.CommandText = "DELETE FROM [Customer] WHERE [Id] = @Id";
        command.Parameters.AddWithValue("@Id", Id);

        await command.ExecuteNonQueryAsync();
    }
}