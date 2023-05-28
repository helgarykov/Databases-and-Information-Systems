using Data.ViewModels;

namespace BlazorProject.Models;

public interface IClientFindTranslatorService
{
    public IEnumerable<TranslatorWithLanguage> GetTranslatorsViaDapper();

}



