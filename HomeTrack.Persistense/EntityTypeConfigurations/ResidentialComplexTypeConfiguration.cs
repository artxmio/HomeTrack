using HomeTrack.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeTrack.Persistense.EntityTypeConfigurations;

public class ResidentialComplexTypeConfiguration : IEntityTypeConfiguration<ResidentialСomplex>
{
    public void Configure(EntityTypeBuilder<ResidentialСomplex> builder)
    {
        builder.HasKey(rc => rc.Id);
        builder.HasIndex(rc => rc.Id);
        builder
            .Property(rc => rc.Name)
            .HasMaxLength(255);
    }
}
