namespace DTOLayer.DTOs;

public class ExperienceDTO
{
    public int ExperienceId { get; set; }
    public string ExperienceTitle { get; set; }
    public string ExperiencePlace { get; set; }
    public string ExperienceDetails { get; set; }
    public string ExperienceDate { get; set; }
    public bool ExperienceStatus { get; set; }
    
    public int AdminId { get; set; }
    public AdminDTO AdminDTO { get; set; }
}