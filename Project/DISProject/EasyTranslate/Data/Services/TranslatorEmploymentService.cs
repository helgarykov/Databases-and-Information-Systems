using System.Data;
using Dapper;
using Data.IServices;
using Data.Models;
using Npgsql;
using Task = System.Threading.Tasks.Task;

namespace Data.Services;

public class TranslatorEmploymentService : ITranslatorEmploymentService
{
    public IEnumerable<TranslatorEmployment> GetTranslatorCompetencesViaDapper()
    {
        using (IDbConnection connection = new NpgsqlConnection("User ID=root;Password=1234;" +
                                                               "Host=localhost;Port=5433;" +
                                                               "Database=Easy_Translate;"))
            
        {   // View from most to least experineced all Spanish and German translators.
            string sql = @"SELECT 
            T.FirstName, 
            T.LastName, 
            SUM(EXTRACT(YEAR FROM TE.DismissalDate) - EXTRACT(YEAR FROM TE.EmploymentDate)) AS ExperienceYears
            FROM 
                Translator AS T
            JOIN 
                Translator_Employment AS TE ON T.Id = TE.TranslatorId
            JOIN 
                Translator_Competence AS TC ON T.Id = TC.TranslatorId
            JOIN 
                Language AS L ON TC.LanguageId = L.Id
            WHERE 
            L.NameOfLang IN ('Spanish', 'German') AND TE.DismissalDate IS NOT NULL
            GROUP BY 
            T.Id
                ORDER BY 
            ExperienceYears DESC;
            ";

            var translatorExperienceSpanishGerman = connection.Query<TranslatorEmployment>(sql);

            return translatorExperienceSpanishGerman;
        }
    }
}