using System.Data;
using Data.Services;
using Npgsql;

const string connectionString = "User ID=postgres;Password=1234;" +
                                "Host=localhost;Port=5433;" +
                                "Database=easy_translate;";

IDbConnection connection = new NpgsqlConnection(connectionString);

/* Service 1. Get a specific language and its ID. */
var clientService = new LanguageService(connection);
var result = clientService.GetLanguageViaDapper();
Console.WriteLine("\n Search for a specific language (in casu English) and print its Id. \n");
var enumerable = result.ToList();
Console.WriteLine(enumerable.First().Id);
Console.WriteLine(enumerable.First().NameOfLang);

/* Service 2 . Get all language and their IDs. */
var results = clientService.GetAllLanguagesViaDapper();
Console.WriteLine("\n The list of all languages: \n");
foreach (var lang in results)
{
    Console.WriteLine($"{lang.Id}: {lang.NameOfLang}");
}

/* Service 3. View all German, English, and Russian translators */
var clientServiceTranslators = new ClientFindTranslatorService(connection);
var results1 = clientServiceTranslators.GetTranslatorsViaDapper();
Console.WriteLine("\n The list of all English, German and Russian translators: \n");
foreach (var translator in results1)
{
    Console.WriteLine($"Id: {translator.TranslatorId}, {translator.ContactName}, Email: {translator.Email}, Tlf: {translator.Tlf}, " +
                      $"Language: {translator.Language}");
}

/* Service 4. View all English, German and Russian translators according to their average rating
  in the ascending order. */
var clientServiceRatedTranslators = new TranslatorCompetenceService(connection);
var result2 = clientServiceRatedTranslators.GetTranslatorsWithRatings();

Console.WriteLine("\n The list of all English, German and Russian translators" +
                  "and their average ratings: \n");
foreach (var translator in result2)
{
    Console.WriteLine($"{translator.ContactName}, Language: {translator.Language}, " +
                      $"Average Rating: {translator.AverageRating}");
}

/* Service 5. Add a task. */
var myTaskServiceInstance = new TaskService(connection);
var newTaskId = myTaskServiceInstance.AddTaskViaDapper();
Console.WriteLine("\n Add a task and return its Id.\n");
Console.WriteLine("New Task ID: " + newTaskId);
myTaskServiceInstance.PrintTask(newTaskId);

/* Service 6. Add a task review. */
var myTaskReviewServiceInstance = new TaskReviewService(connection);
var newReviewId = myTaskReviewServiceInstance.AddReviewViaDapper();
Console.WriteLine("\n Add a task review and return the Id of the new review.\n");
Console.WriteLine("New Review ID: " + newReviewId);

/* Service 7. View all previous tasks (client). */ 




