using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete;

public class Education
{
    [Key] 
    public int EducationId { get; set; }
    public string EducationTitle { get; set; }
    public string EducationPlace { get; set; }
    public string EducationDetails { get; set; }
    public string EducationMark { get; set; }
    public string EducationDate { get; set; }
    public bool EducationStatus { get; set; }
    
    public int AdminId { get; set; }
    public Admin Admin { get; set; }
}