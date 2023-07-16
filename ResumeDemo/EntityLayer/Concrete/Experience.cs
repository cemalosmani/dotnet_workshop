using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete;

public class Experience
{
    [Key]
    public int ExperienceId { get; set; }
    public string ExperienceTitle { get; set; }
    public string ExperiencePlace { get; set; }
    public string ExperienceDetails { get; set; }
    public string ExperienceDate { get; set; }
    public bool ExperienceStatus { get; set; }
    
    public int AdminId { get; set; }
    public Admin Admin { get; set; }
}