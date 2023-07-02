namespace DTOLayer.DTOs;

public class AdminDTO
{
    public int AdminId { get; set; }
    public string AdminFullName { get; set; }
    public string AdminImage { get; set; }
    public string AdminAbout { get; set; }
    public string AdminMail { get; set; }
    public string AdminPassword { get; set; }
    public bool AdminStatus { get; set; }
    
    public ICollection<EducationDTO> Educations { get; set; }
    public ICollection<ExperienceDTO> Experiences { get; set; }
    public ICollection<LanguageDTO> Languages { get; set; }
    public ICollection<SkillDTO> Skills { get; set; }
    public ICollection<ContactDTO> Contacts { get; set; }
}