using System.Data;
using Dapper;
using Data.IServices;
using Data.ViewModels;

namespace Data.Services
{
    public class TaskService : ITaskService
    {
        private IDbConnection Connection { get; }

        public TaskService(IDbConnection connection)
        {
            Connection = connection;
        }

        public int AddTaskViaDapper()
        {
            var parameters = new
            {
                ClientId = 18,
                TaskType = "Phone Translation",
                DateOfTask = DateTime.Parse("2023-01-31"),
                StartTime = DateTime.Parse("10:00"),
                EndTime = DateTime.Parse("14:00"),
                Urgent = 0,
                Difficult = 0,
                CityAddress = "Randers",
                Street = "Grovevej",
                HouseNr = 505,
                TranslatorId = 1,
                LanguageId = 1
            };

            var sql = "INSERT INTO Task ( ClientId, TaskType, DateOfTask, StartTime, EndTime, " +
                      "Urgent, Difficult, CityAddress, Street, HouseNr, TranslatorId, LanguageId) " +
                      "VALUES (@ClientId, @TaskType, @DateOfTask, @StartTime, @EndTime, " +
                      "@Urgent, @Difficult, @CityAddress, @Street, @HouseNr, @TranslatorId," +
                      "@LanguageId) " +
                      "RETURNING Id;";

            int newTask = Connection.QuerySingle<int>(sql, parameters);

            return newTask;
        }

        public void PrintTask(int taskId)
        {
            var sql = "SELECT * FROM Task WHERE Id = @TaskId;";
            var parameters = new { TaskId = taskId };

            IEnumerable<TaskRequest> tasks = Connection.Query<TaskRequest>(sql, parameters);

            foreach (var task in tasks)
            {
                Console.WriteLine("Task Details:");
                Console.WriteLine($"ClientId: {task.ClientId}");
                Console.WriteLine($"TaskType: {task.TaskType}");
                Console.WriteLine($"DateOfTask: {task.DateOfTask}");
                Console.WriteLine($"StartTime: {task.StartTime}");
                Console.WriteLine($"EndTime: {task.EndTime}");
                Console.WriteLine($"Urgent: {task.Urgent}");
                Console.WriteLine($"Difficult: {task.Difficult}");
                Console.WriteLine($"CityAddress: {task.CityAddress}");
                Console.WriteLine($"Street: {task.Street}");
                Console.WriteLine($"HouseNr: {task.HouseNr}");
                Console.WriteLine($"TranslatorName: {task.TranslatorId}");
                Console.WriteLine($"Language: {task.LanguageId}");
                Console.WriteLine();
            }
        }

    }
}