namespace HomeTrack.Domain;

public class ResidentialСomplex
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public ICollection<House> Houses { get; set; } = [];
}
