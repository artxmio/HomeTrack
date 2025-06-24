namespace HomeTrack.Domain;

public class ResidentialСomplex
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime CreateDate { get; set; }
    public DateTime? UpdateDate { get; set; }

    public ICollection<House> Houses { get; set; } = [];
}
