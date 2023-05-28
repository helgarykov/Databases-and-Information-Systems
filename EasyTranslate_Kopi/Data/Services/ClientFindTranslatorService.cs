using System.Data;
using BlazorProject.Models;
using Dapper;
using Data.Models;
using Npgsql;

namespace Data.Services;

public class ClientFindTranslatorService : IClientFindTranslatorService 
{
    public IDbConnection Connection { get; }

    public ClientFindTranslatorService(IDbConnection connection)
    {
        Connection = connection;
    }
    public IEnumerable<Translator> GetTranslatorsViaDapper()
    {

        var sql = "SELECT t.* FROM Translator t " +
                  "INNER JOIN TranslatorLanguage tl ON t.Id = tl.TranslatorId " +
                  "WHERE tl.Language = 'English';";

        var translators = Connection.Query<Translator>(sql);
        return translators;
        
    }
}