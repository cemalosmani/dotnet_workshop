namespace DTOLayer.DTOs;

public class ContactDTO
{
    public int ContactId { get; set; }
    public string ContactType { get; set; }
    public string ContactLink { get; set; }
    public bool ContactStatus { get; set; }

    public int AdminId { get; set; }
    public AdminDTO AdminDTO { get; set; }
}