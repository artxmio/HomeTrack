using HomeTrack.Application.Interfaces;
using HomeTrack.Domain;
using HomeTrack.Persistense.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace HomeTrack.Persistense;

public class HomeTrackDbContext : DbContext, IHomeTrackDbContext
{
    public DbSet<Resident> Residents { get; set; }

    public HomeTrackDbContext(DbContextOptions<HomeTrackDbContext> options):
        base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ResidentTypeConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}
