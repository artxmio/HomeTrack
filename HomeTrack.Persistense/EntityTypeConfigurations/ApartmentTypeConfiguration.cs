using HomeTrack.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeTrack.Persistense.EntityTypeConfigurations;

public class ApartmentTypeConfiguration : IEntityTypeConfiguration<Apartment>
{
    public void Configure(EntityTypeBuilder<Apartment> builder)
    {
        builder.HasKey(a => a.Id);
        builder.HasIndex(a => a.Id);
        builder.Property(a => a.Number)
            .HasMaxLength(4);
        builder
            .HasMany(a => a.Residents)
            .WithOne(a => a.Apartment)
            .HasForeignKey(a => a.ApartmentId);
        builder
            .HasOne(a => a.House)
            .WithMany(h => h.Apartments)
            .HasForeignKey(a => a.HouseId);
    }
}
