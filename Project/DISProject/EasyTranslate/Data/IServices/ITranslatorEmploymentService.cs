using Data.Models;

namespace Data.IServices;

public interface ITranslatorEmploymentService
{
    public IEnumerable<TranslatorEmployment> GetTranslatorCompetencesViaDapper();
}