using System.Data;
using BlazorProject.Models;
using Dapper;
using Data.ViewModels;

namespace Data.Services;

public class ClientFindTranslatorService : IClientFindTranslatorService 
{
    public IDbConnection Connection { get; }

    public ClientFindTranslatorService(IDbConnection connection)
    {
        Connection = connection;
    }
    
    /* Get English, Russian and German translators */
    public IEnumerable<TranslatorWithLanguage> GetTranslatorsViaDapper()
    {
        string[] languages = new string[] { "English", "Russian", "German" };

        var sql = "SELECT translator.Id AS TranslatorId, " +
                  "translator.FirstName || ' ' || translator.LastName AS ContactName, " +
                  "translator.Email AS Email, translator.Tlf AS Tlf, language.nameOfLang AS Language " +
                  "FROM Translator " +
                  "INNER JOIN Translator_Competence tc ON translator.Id = tc.TranslatorId " +
                  "INNER JOIN Language ON tc.LanguageId = language.id " +
                  "WHERE Language.nameOfLang = ANY(@languages) " +
                  "ORDER BY CASE WHEN language.nameOfLang = 'English' THEN 1 " +
                  "WHEN language.nameOfLang = 'German' THEN 2 " +
                  "WHEN language.nameOfLang = 'Russian' THEN 3 END;";
        
        IEnumerable<TranslatorWithLanguage> translators = Connection.Query<TranslatorWithLanguage>(sql, new {languages });

        return translators;
        
    }
}