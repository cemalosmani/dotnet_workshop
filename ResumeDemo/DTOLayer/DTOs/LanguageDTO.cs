namespace DTOLayer.DTOs;

public class LanguageDTO
{
    public int LanguageId { get; set; }
    public string LanguageName { get; set; }
    public string LanguageWriting { get; set; }
    public string LanguageReading { get; set; }
    public string LanguageSpeaking { get; set; }
    public bool LanguageStatus { get; set; }
    
    public int AdminId { get; set; }
    public AdminDTO AdminDTO { get; set; }
}