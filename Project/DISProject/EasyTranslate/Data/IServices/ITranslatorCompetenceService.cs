using Data.Models;

namespace Data.IServices;

public interface ITranslatorCompetenceService
{
    public IEnumerable<TranslatorCompetence> GetTranslatorCompetenceViaDapper();
}