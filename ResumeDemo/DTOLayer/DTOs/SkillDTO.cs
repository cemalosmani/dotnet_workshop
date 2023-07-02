namespace DTOLayer.DTOs;

public class SkillDTO
{
    public int SkillId { get; set; }
    public string SkillName { get; set; }
    public bool SkillStatus { get; set; }
    
    public int AdminId { get; set; }
    public AdminDTO AdminDTO { get; set; }
}