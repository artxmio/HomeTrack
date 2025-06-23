namespace HomeTrack.Domain;

public class House
{
    public Guid Id { get; set; }
    public string Street { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public int NumberOfFloors { get; set; }
    public int NumberOfEntrances { get; set; }

    public ICollection<Apartment> Apartments { get; set; } = [];

    public Guid ResidentialСomplexId { get; set; }
    public ResidentialСomplex ResidentialСomplex { get; set; } = null!;
}
