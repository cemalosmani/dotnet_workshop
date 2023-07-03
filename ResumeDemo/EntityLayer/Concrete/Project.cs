

namespace EntityLayer.Concrete;

public class Project
{
    public int ProjectId { get; set; }
    public string ProjectName { get; set; }
    public string ProjectDetails { get; set; }
    public string ProjectDate { get; set; }
    public bool ProjectStatus { get; set; }
    public int AdminId { get; set; }
    public Admin Admin { get; set; }
}