using System.Data;
using BlazorProject.Models;
using Dapper;
using Data.IServices;
using Data.Models;
using Npgsql;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace Data.Services;

public class LanguageService : ILanguageService
{
    public IDbConnection Connection { get; }

    public LanguageService(IDbConnection connection)
    {
        Connection = connection;
    }
    
    /* Get English */
    public IEnumerable<Language> GetLanguageViaDapper()
    {
        var lang = "English";
            
            var language = Connection.Query<Language>($"""
                SELECT language.id as Id, language.nameOfLang as nameoflang
                FROM Language
                WHERE NameOfLang = @lang
            """, new { lang = lang});
           return language;
    }

    /* Get all available languages. */
    public IEnumerable<Language> GetAllLanguagesViaDapper()
    {
        var languages = Connection.Query<Language>(sql: $"""
                SELECT language.id as Id, language.nameOfLang as nameoflang
                FROM language 
            """);
            return languages;
    }
}

