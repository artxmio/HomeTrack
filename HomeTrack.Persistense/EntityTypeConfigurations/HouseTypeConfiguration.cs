using HomeTrack.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeTrack.Persistense.EntityTypeConfigurations;

public class HouseTypeConfiguration : IEntityTypeConfiguration<House>
{
    public void Configure(EntityTypeBuilder<House> builder)
    {
        builder.HasKey(h => h.Id);
        builder.HasIndex(h => h.Id);
        builder
            .Property(h => h.Street)
            .HasMaxLength(255);
        builder
            .Property(h => h.Number)
            .HasMaxLength(255);
        builder
            .Property(h => h.City)
            .HasMaxLength(255);
        builder
            .HasMany(h => h.Apartments)
            .WithOne(a => a.House)
            .HasForeignKey(a => a.HouseId);
        builder.HasOne(h => h.ResidentialСomplex)
            .WithMany(rc => rc.Houses)
            .HasForeignKey(h => h.ResidentialСomplexId);
    }
}
