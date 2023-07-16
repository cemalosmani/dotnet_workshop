using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete;

public class Language
{
    [Key] 
    public int LanguageId { get; set; }
    public string LanguageName { get; set; }
    public string LanguageWriting { get; set; }
    public string LanguageReading { get; set; }
    public string LanguageSpeaking { get; set; }
    public bool LanguageStatus { get; set; }
    
    public int AdminId { get; set; }
    public Admin Admin { get; set; }
}