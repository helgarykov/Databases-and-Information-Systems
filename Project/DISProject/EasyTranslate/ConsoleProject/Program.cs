// See https://aka.ms/new-console-template for more information

using System.Data;
using Data.Services;
using Npgsql;

const string connectionString = "User ID=postgres;Password=1234;" +
                                "Host=localhost;Port=5433;" +
                                "Database=easy_translate;";

IDbConnection connection = new NpgsqlConnection(connectionString);

/* Initiate LanguageService */
var clientService = new LanguageService(connection);

/* Get the English language and its ID. */
var result = clientService.GetLanguageViaDapper();
Console.WriteLine("Search for a specific language (English) and print its Id. \n");
var enumerable = result.ToList();
Console.WriteLine(enumerable.First().Id);
Console.WriteLine(enumerable.First().NameOfLang);


var results = clientService.GetAllLanguagesViaDapper();
Console.WriteLine("\n The list of all languages: \n");
foreach (var lang in results)
{
    Console.WriteLine($"{lang.Id}: {lang.NameOfLang}");
}


/* Initiate TranslatorService with search for all German, English, and
 Russian translators */

var clientServiceTranslators = new ClientFindTranslatorService(connection);
var results1 = clientServiceTranslators.GetTranslatorsViaDapper();

Console.WriteLine("\n The list of all English, German and Russian translators: \n");
foreach (var translator in results1)
{
    Console.WriteLine($"{translator.ContactName}, Email: {translator.Email}, Tlf: {translator.Tlf}, " +
                      $"Language: {translator.Language}");
}

/* Initialize TranslatorCompetenceService and list all English, German and Russian translators in
 the ascending order according to their average rating. */

var clientServiceRatedTranslators = new TranslatorCompetenceService(connection);
var result2 = clientServiceRatedTranslators.GetTranslatorsWithRatings();

Console.WriteLine("\n The list of all English, German and Russian translators" +
                  "and their average ratings: \n");
foreach (var translator in result2)
{
    Console.WriteLine($"{translator.ContactName}, Language: {translator.Language}, " +
                      $"Average Rating: {translator.AverageRating}");
}




