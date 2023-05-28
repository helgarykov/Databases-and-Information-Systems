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
    public IEnumerable<RatedTranslator> GetTranslatorsWithRatings()
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
    } 
}

