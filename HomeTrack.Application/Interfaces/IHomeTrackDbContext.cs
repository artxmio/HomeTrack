using HomeTrack.Domain;
using Microsoft.EntityFrameworkCore;

namespace HomeTrack.Application.Interfaces;

public interface IHomeTrackDbContext
{
    DbSet<Resident> Residents { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
