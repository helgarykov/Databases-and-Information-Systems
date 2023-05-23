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
    public IEnumerable<Language> GetLanguageViaDapper()
    {
        using (IDbConnection connection = new NpgsqlConnection("User ID=root;Password=1234;" +
                                                               "Host=localhost;Port=5433;" +
                                                               "Database=Easy_Translate;"))
        {
           /* var language = connection.Query<Language>("SELECT l.* FROM Language l" +
                                                      "INNER JOIN NameOfLang"); */
           return null;
        }

    } 
}

