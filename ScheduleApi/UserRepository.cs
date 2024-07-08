using System.Data;
using MySql.Data.MySqlClient; // Importa el namespace del conector MySQL
using Dapper;
using Microsoft.Extensions.Configuration;

public class UserRepository
{
    private readonly string _connectionString;
    IConfiguration configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();
    public UserRepository() {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public void GetUsers()
    {
        using IDbConnection dbConnection = new MySqlConnection(_connectionString);
        dbConnection.Open();
        
        string query = "SELECT * FROM user";
        var users = dbConnection.Query(query).ToList();
        
        Console.WriteLine(users);
        dbConnection.Close();
    }

    // Otros métodos para actualizar, eliminar, etc.
}
