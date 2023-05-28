using System.Data;
using Dapper;
using Data.Models;
using Npgsql;

namespace BlazorProject.Models;

public interface IClientFindTranslatorService 
{
    public IEnumerable<Translator> GetTranslatorsViaDapper();

}



