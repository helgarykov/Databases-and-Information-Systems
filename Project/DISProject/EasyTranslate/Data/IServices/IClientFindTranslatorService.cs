using System.Data;
using Dapper;
using Data.Models;
using Data.ViewModels;
using Npgsql;

namespace BlazorProject.Models;

public interface IClientFindTranslatorService
{
    public IEnumerable<TranslatorWithLanguage> GetTranslatorsViaDapper();

}



