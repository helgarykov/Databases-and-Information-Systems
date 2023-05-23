using System.Data;
using BlazorProject.Models;
using Dapper;
using Data.Models;
using Npgsql;

namespace Data.Services;

public class ClientFindTranslatorService : IClientFindTranslatorService 
{
    public IEnumerable<Translator> GetTranslatorsViaDapper()
    {
        IDbConnection connection = new NpgsqlConnection("User ID=root;Password=1234;" +
                                                        "Host=localhost;Port=5433;" +
                                                        "Database=Easy_Translate;");
        
        var sql = "SELECT t.* FROM Translator t " +
                  "INNER JOIN TranslatorLanguage tl ON t.Id = tl.TranslatorId " +
                  "WHERE tl.Language = 'English';";

        var translators = connection.Query<Translator>(sql);
        return translators;
        
    }
}