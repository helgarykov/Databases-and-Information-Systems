using System.Data;
using Dapper;
using Data.IServices;
using Data.Models;
using Data.ViewModels;
using Npgsql;
using Task = System.Threading.Tasks.Task;

namespace Data.Services;

public class TranslatorCompetenceService : ITranslatorCompetenceService 
{
    public IDbConnection Connection { get; }

    public TranslatorCompetenceService(IDbConnection connection)
    {
        Connection = connection;
    }
    
    /*public IEnumerable<TranslatorCompetence> GetTranslatorCompetenceViaDapper()
    {
        
        
         /* var sql = "SELECT c.* FROM Translator t " +
                  "INNER JOIN TranslatorLanguage tl ON t.Id = tl.TranslatorId " +
                  "WHERE tl.Language = 'English';"; 

        var translatorComp = connection.Query<TranslatorCompetence>(sql);
        return translatorComp; #1#

         return null;
    }*/
    /*public IEnumerable<RatedTranslator> GetTranslatorsWithRatings()
    {
        IEnumerable<RatedTranslator> allTranslators = Connection.Query<RatedTranslator>("""
            SELECT translator.contactname as ContactName, language.name as LanguageName, avg(review.rating) as AverageRating,  
            FROM translator 
                inner join translatorcompetence on translator.id = translatorcompetence.translatorid
                inner join language on translatorcompetence.languageid = language.id
                inner join task on translatorcompetence.id = task.translatorcompetenceid
                inner join review on review.taskid = task.id
            
        """);
        return null;
    } */
    public IEnumerable<RatedTranslator> GetTranslatorsWithRatings()
    {
        
        var sql = "SELECT translator.FirstName || ' ' || translator.LastName as ContactName, " +
                  "language.nameOfLang as Language, avg(review.rating) as AverageRating " +
                  "FROM Translator " +
                  "INNER JOIN Translator_Competence tc ON translator.Id = tc.TranslatorId " +
                  "INNER JOIN Language ON tc.LanguageId = language.id " +
                  "WHERE Language.nameOfLang = ANY(@languages) " +
                  "ORDER BY CASE WHEN language.nameOfLang = 'English' THEN 1 " +
                  "WHEN language.nameOfLang = 'German' THEN 2 " +
                  "WHEN language.nameOfLang = 'Russian' THEN 3 END;";


        IEnumerable<RatedTranslator> allRatedTranslators = Connection.Query<RatedTranslator>(sql,);
            
        return allRatedTranslators;
    } 
}

var sql = "SELECT translator.FirstName || ' ' || translator.LastName AS ContactName, " +
          "translator.Email AS Email, translator.Tlf AS Tlf, language.nameOfLang AS Language " +
          "FROM Translator " +
          "INNER JOIN Translator_Competence tc ON translator.Id = tc.TranslatorId " +
          "INNER JOIN Language ON tc.LanguageId = language.id " +
          "WHERE Language.nameOfLang = ANY(@languages) " +
          "ORDER BY CASE WHEN language.nameOfLang = 'English' THEN 1 " +
          "WHEN language.nameOfLang = 'German' THEN 2 " +
          "WHEN language.nameOfLang = 'Russian' THEN 3 END;";

