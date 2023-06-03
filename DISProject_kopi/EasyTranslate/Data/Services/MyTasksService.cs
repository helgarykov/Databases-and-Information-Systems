using System.Data;
using Dapper;
using Data.IServices;

namespace Data.Services;

public class MyTasksService : IMyTasksService
{  
    private IDbConnection Connection { get; set; }
    
    public MyTasksService(IDbConnection connection)
    {
        Connection = connection;
    }

    public IEnumerable<Task> GetClientTasksViaDapper(int clientId)
    {
        var tasks = Connection.Query<Task>(sql: $@"
            SELECT *
            FROM Task
            WHERE ClientId = {clientId}
        ");
        return tasks;
    }
    
}

