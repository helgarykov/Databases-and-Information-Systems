using System.Data;
using Dapper;
using Data.IServices;
using Data.Models;
using Npgsql;


namespace Data.Services;

public class TaskReviewService : ITaskReviewService
{  
    public IDbConnection Connection { get; }

    public TaskReviewService(IDbConnection connection)
    {
        Connection = connection;
    }
    public IEnumerable<TaskReview> AddReviewViaDapper()
    {
        
       
        var sql = "\n INSERT INTO TaskReview (DateOfReview, Body, Stars, TaskId, ClientId) \n " +
                  "VALUES (@DateOfReview, @Body, @Stars, @TaskId, @ClientId); \n " +
                  "SELECT CAST(SCOPE_IDENTITY() as int);";

        var newTaskReview = Connection.Query<TaskReview>(sql);

        return newTaskReview;
    }
}