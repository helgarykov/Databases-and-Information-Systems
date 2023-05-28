// See https://aka.ms/new-console-template for more information

using System.Data;
using Data.Services;
using Npgsql;

Console.WriteLine("Hello, World!");

string connectionString = "User ID=postgres;Password=1234;" +
                       "Host=localhost;Port=5433;" +
                       "Database=easy_translate;";

IDbConnection connection = new NpgsqlConnection(connectionString);

var clientService = new LanguageService(connection);

var result = clientService.GetLanguageViaDapper();

Console.WriteLine(result.First().Id);
Console.WriteLine(result.First().NameOfLang);

