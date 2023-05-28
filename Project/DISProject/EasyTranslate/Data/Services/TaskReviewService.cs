using System.Data;
using Dapper;
using Data.IServices;
using Data.Models;
using Npgsql;

namespace Data.Services;

/* Class for creating a task review. */
public class TaskReviewService : ITaskReviewService
{  
    public IDbConnection Connection { get; }

    public TaskReviewService(IDbConnection connection)
    {
        Connection = connection;
    }
    
    /* Add a task review and return the Id of the new review. */
    public int AddReviewViaDapper()
    {
        var parameters = new 
        {
            DateOfReview = DateTime.Parse("2023-05-31"),
            Body = "Fremragnede tolkning. Tolken har mødt op til tiden og" +
                   "har udført et godt stykke arbejde. Topprofessionelt.",
            Stars = 5,
            TaskId = 24,
            ClientId = 27,
            TranslatorId = 8,
            LanguageId = 4
        };
        var sql = "INSERT INTO Task_Review (DateOfReview, Body," +
                  " Stars, TaskId, ClientId, TranslatorId, LanguageId) " +
                  "VALUES (@DateOfReview, @Body, @Stars, @TaskId, @ClientId," +
                  " @TranslatorId, @LanguageId) " +
                  "RETURNING Id;";

        int newId = Connection.QuerySingle<int>(sql, parameters);

        return newId;
    }
}

