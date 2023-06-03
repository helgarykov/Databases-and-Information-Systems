namespace Data.ViewModels;

public class RatedTranslator : TranslatorWithLanguage
{
    public string ContactName { get; }
    public string Language { get; set; }
    public double AverageRating { get; set; }
}