using HomeTrack.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeTrack.Persistense.EntityTypeConfigurations;

public class ResidentTypeConfiguration : IEntityTypeConfiguration<Resident>
{
    public void Configure(EntityTypeBuilder<Resident> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.Id).IsUnique();
        builder.Property(x => x.Name).HasMaxLength(250);
        builder.Property(x => x.Surname).HasMaxLength(250);
    }
}
