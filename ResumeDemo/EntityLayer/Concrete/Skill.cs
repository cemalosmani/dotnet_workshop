using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete;

public class Skill
{
    [Key]
    public int SkillId { get; set; }
    public string SkillName { get; set; }
    public bool SkillStatus { get; set; }
    
    public int AdminId { get; set; }
    public Admin Admin { get; set; }
}