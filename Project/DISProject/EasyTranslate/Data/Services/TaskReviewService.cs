using System.Data;
using Dapper;
using Data.IServices;
using Data.Models;
using Npgsql;


namespace Data.Services;

public class TaskReviewService : ITaskReviewService
{  
    public IEnumerable<TaskReview> AddReviewViaDapper()
    {
        using IDbConnection connection = new NpgsqlConnection("User ID=root;Password=1234;" +
                                                              "Host=localhost;Port=5433;" +
                                                              "Database=Easy_Translate;");
        var sql = "\n INSERT INTO TaskReview (DateOfReview, Body, Stars, TaskId, ClientId) \n " +
                  "VALUES (@DateOfReview, @Body, @Stars, @TaskId, @ClientId); \n " +
                  "SELECT CAST(SCOPE_IDENTITY() as int);";

        var newTaskReview = connection.Query<TaskReview>(sql);

        return newTaskReview;
    }
}