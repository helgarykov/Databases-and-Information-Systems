// See https://aka.ms/new-console-template for more information

using System.Data;
using Data.Models;
using Data.Services;
using Npgsql;

Console.WriteLine("Hello, World!");

string connectionString = "User ID=postgres;Password=1234;" +
                       "Host=localhost;Port=5433;" +
                       "Database=easy_translate;";

IDbConnection connection = new NpgsqlConnection(connectionString);

/* Initiate LanguageService */
var clientService = new LanguageService(connection);

// var result = clientService.GetLanguageViaDapper();
//
// Console.WriteLine(result.First().Id);
// Console.WriteLine(result.First().NameOfLang);

var results = clientService.GetAllLanguagesViaDapper();
foreach (var lang in results)
{
    Console.WriteLine($"{lang.Id}: {lang.NameOfLang}");
}

/* Initiate TranslatorService with search for all German, English, and
 Russian translators */

var clientServiceTranslators = new ClientFindTranslatorService(connection);
var results1 = clientServiceTranslators.GetTranslatorsViaDapper();

foreach (var translator in results1)
{
    Console.WriteLine($"{translator.ContactName}, Email: {translator.Email}, Tlf: {translator.Tlf}, " +
                      $"Language: {translator.Language}");
}



