using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete;

public class Admin
{
    [Key]
    public int AdminId { get; set; }
    public string AdminFullName { get; set; }
    public string AdminImage { get; set; }
    public string AdminAbout { get; set; }
    public string AdminMail { get; set; }
    public string AdminPassword { get; set; }
    public bool AdminStatus { get; set; }
    
    public ICollection<Education> Educations { get; set; }
    public ICollection<Experience> Experiences { get; set; }
    public ICollection<Language> Languages { get; set; }
    public ICollection<Skill> Skills { get; set; }
    public ICollection<Contact> Contacts { get; set; }
    public ICollection<Project> Projects { get; set; }
}