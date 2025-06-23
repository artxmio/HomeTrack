namespace HomeTrack.Domain;

public class Resident
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime? UpdateDate { get; set; }

    public Guid? ApartmentId { get; set; }
    public Apartment Apartment { get; set; } = null!;
}
