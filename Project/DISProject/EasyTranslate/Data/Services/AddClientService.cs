using System.Data;
using Dapper;
using Data.IServices;
using Data.Models;

namespace Data.Services;

public class AddClientService : IAddClientService
{
    public IDbConnection Connection { get; }
    
    public AddClientService(IDbConnection connection)
    {
        Connection = connection;
    }
    
    //TODO: implement AddNewClient
    public IEnumerable<Client> AddClientViaDapper()
    {

        var sql = "\n INSERT INTO Client (ContactName, Login, Password, Tlf, " +
                  "CityAddress, Street, HouseNr, FeeMultiplier) \n " +
                  "VALUES (@ContactName, @Login, @Password, @Tlf, " +
                  "@CityAddress, @Street, @HouseNr, @FeeMultiplier); \n " +
                  "SELECT CAST(SCOPE_IDENTITY() as int);";


        var newClient = Connection.Query<Client>(sql);
        return newClient;
    }
}