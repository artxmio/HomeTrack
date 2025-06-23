using HomeTrack.Domain;
using Microsoft.EntityFrameworkCore;

namespace HomeTrack.Application.Interfaces;

public interface IHomeTrackDbContext
{
    DbSet<Resident> Residents { get; set; }
    DbSet<Apartment> Apartments { get; set; }
    DbSet<House> Houses { get; set; }
    DbSet<ResidentialСomplex> ResidentialComplexes { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
