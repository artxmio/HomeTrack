namespace HomeTrack.Domain;

public class Apartment
{
    public Guid Id { get; set; }
    public string Number { get; set; } = string.Empty;
    public int Floor { get; set; }
    public int Area { get; set; }

    public ICollection<Resident> Residents { get; set; } = [];
}
