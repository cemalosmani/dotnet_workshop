using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete;

public class Context : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("server=localhost;database=ResumeDB;" +
                                    "Encrypt=false;TrustServerCertificate=True;" +
                                    "User Id=sa;Password=mZ0*Q&r2$8uF");
    }
    public DbSet<Admin> Admins { get; set; }
    public DbSet<Education> Educations { get; set; }
    public DbSet<Experience> Experiences { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Project> Projects { get; set; }
}