using HomeTrack.Domain;

namespace HomeTrack.Application.Apartments.Queries.GetResidentsByApartment;

public class ResidentsByApartmentVm
{
    public IList<ResidentsByApartmentLookupDto> Residents { get; set; } = null!;
}
