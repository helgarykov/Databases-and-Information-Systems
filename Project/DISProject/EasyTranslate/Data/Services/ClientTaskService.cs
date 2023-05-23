using System.Data;
using BlazorProject.Models;
using Dapper;
using Data.Models;
using Npgsql;

namespace Data.Services;

public class ClientTaskService 
{
    public IDbConnection Connection;

    public ClientTaskService(IDbConnection connection)
    {
        Connection = connection;
    }

}




