using HomeTrack.Application.Interfaces;
using HomeTrack.Domain;
using HomeTrack.Persistense.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace HomeTrack.Persistense;

public class HomeTrackDbContext(DbContextOptions<HomeTrackDbContext> options) : DbContext(options), IHomeTrackDbContext
{
    public DbSet<Resident> Residents { get; set; }
    public DbSet<Apartment> Apartments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ResidentTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ApartmentTypeConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}
