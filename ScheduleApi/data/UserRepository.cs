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

    public dynamic GetUsers()
    {
        using IDbConnection dbConnection = new MySqlConnection(_connectionString);
        dbConnection.Open();
        
        string query = "SELECT * FROM user";
        var users = dbConnection.Query(query).ToList();
        
        Console.WriteLine(users);

        users.ForEach(user => {
            Console.WriteLine($"Id: {user.id}");
            Console.WriteLine($"Name: {user.username}");
            Console.WriteLine($"Email: {user.email}");
            Console.WriteLine($"password: {user.password}");
        });
        dbConnection.Close();
        return users;
    }

    // Otros métodos para actualizar, eliminar, etc.
}
