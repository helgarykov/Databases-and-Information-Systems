using System.Data;
using Dapper;
using Data.IServices;
using Data.Models;

namespace Data.Services;

public class TranslatorEmploymentService : ITranslatorEmploymentService
{
    public IDbConnection Connection { get; }

    public TranslatorEmploymentService(IDbConnection connection)
    {
        Connection = connection;
    }
    
    //TODO: implement GetTranslatorComp below
    
    public IEnumerable<TranslatorEmployment> GetTranslatorCompetencesViaDapper()
    {

        {   // View from most to least experineced all Spanish and German translators.
            
            
            DateTime today = DateTime.Today;
                
            string sql = $@"SELECT 
            T.{"ARG"}FirstName, 
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

            var translatorExperienceSpanishGerman = Connection.Query<TranslatorEmployment>(sql);

            return translatorExperienceSpanishGerman;
        }
    }
}