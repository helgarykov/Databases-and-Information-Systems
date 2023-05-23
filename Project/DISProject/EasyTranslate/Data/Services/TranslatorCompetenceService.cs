using System.Data;
using Dapper;
using Data.IServices;
using Data.Models;
using Npgsql;
using Task = System.Threading.Tasks.Task;

namespace Data.Services;

public class TranslatorCompetenceService : ITranslatorCompetenceService 
{
    public IEnumerable<TranslatorCompetence> GetTranslatorCompetenceViaDapper()
    {
        IDbConnection connection = new NpgsqlConnection("User ID=root;Password=1234;" +
                                                        "Host=localhost;Port=5433;" +
                                                        "Database=Easy_Translate;");
        
         /* var sql = "SELECT c.* FROM Translator t " +
                  "INNER JOIN TranslatorLanguage tl ON t.Id = tl.TranslatorId " +
                  "WHERE tl.Language = 'English';"; 

        var translatorComp = connection.Query<TranslatorCompetence>(sql);
        return translatorComp; */

         return null;
    }
}