namespace HomeTrack.Domain;

public class Apartment
{
    public Guid Id { get; set; }
    public string Number { get; set; } = string.Empty;
    public int Entrance { get; set; }
    public int Floor { get; set; }
    public int Area { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime? UpdateDate { get; set; }

    public ICollection<Resident> Residents { get; set; } = [];

    public Guid? HouseId { get; set; }
    public House House { get; set; } = null!;
}