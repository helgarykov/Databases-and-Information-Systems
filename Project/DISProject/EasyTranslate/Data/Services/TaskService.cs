using System.Data;
using BlazorProject.Models;
using Dapper;
using Data.IServices;
using Data.Models;
using Npgsql;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace Data.Services
{
    public class TaskService : ITaskService
    {
        public IEnumerable<Task> AddTaskViaDapper()
        {
            using (IDbConnection connection = new NpgsqlConnection("User ID=root;Password=1234;" +
                                                                   "Host=localhost;Port=5433;" +
                                                                   "Database=Easy_Translate;"))
            {
                var sql = "\n INSERT INTO Task (TaskType, DateOfTask, StartTime, EndTime, " +
                          "Urgent, Difficult, CityAddress, Street, HouseNr, TranslatorCompetenceID, " +
                          "ClientId) \n " +
                          "VALUES (@TaskType, @DateOfTask, @StartTime, @EndTime, @Urgent, @Difficult," +
                          " @CityAddress, @Street, @HouseNr, @TranslatorCompetenceID, @ClientId); \n " +
                          "SELECT CAST(SCOPE_IDENTITY() as int);";

                var newTask = connection.Query<Task>(sql);

                return newTask;
            }
        }
    }
}