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
        public IDbConnection Connection { get; }

        public TaskService(IDbConnection connection)
        {
            Connection = connection;
        }
        public IEnumerable<Task> AddTaskViaDapper()
        {
            var sql = "\n INSERT INTO Task (TaskType, DateOfTask, StartTime, EndTime, " +
                      "Urgent, Difficult, CityAddress, Street, HouseNr, TranslatorCompetenceID, " +
                      "ClientId) \n " +
                      "VALUES (@TaskType, @DateOfTask, @StartTime, @EndTime, @Urgent, @Difficult," +
                      " @CityAddress, @Street, @HouseNr, @TranslatorCompetenceID, @ClientId); \n " +
                      "SELECT CAST(SCOPE_IDENTITY() as int);";

                var newTask = Connection.Query<Task>(sql);

                return newTask;
        }
    }
}