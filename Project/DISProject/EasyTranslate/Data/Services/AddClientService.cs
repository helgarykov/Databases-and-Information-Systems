using System.Data;
using Dapper;
using Data.IServices;
using Data.Models;
using Npgsql;

namespace Data.Services;

public class AddClientService : IAddClientService
{  
    public IEnumerable<Client> AddClientViaDapper()
    {
        IDbConnection connection = new NpgsqlConnection("User ID=root;Password=1234;" +
                                                        "Host=localhost;Port=5433;" +
                                                        "Database=Easy_Translate;");
      
        
        var sql = "\n INSERT INTO Client (ContactName, Login, Password, Tlf, " +
                  "CityAddress, Street, HouseNr, FeeMultiplier) \n " +
                  "VALUES (@ContactName, @Login, @Password, @Tlf, " +
                  "@CityAddress, @Street, @HouseNr, @FeeMultiplier); \n " +
                  "SELECT CAST(SCOPE_IDENTITY() as int);";


        var newClient = connection.Query<Client>(sql);
        return newClient;
    }
}