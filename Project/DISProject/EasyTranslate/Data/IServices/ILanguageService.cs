using Data.Models;

namespace Data.IServices;

public interface ILanguageService
{
    public IEnumerable<Language> GetLanguageViaDapper();
}