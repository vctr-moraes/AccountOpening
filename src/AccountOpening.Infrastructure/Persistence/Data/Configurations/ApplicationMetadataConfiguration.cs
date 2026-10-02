using AccountOpening.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
    
namespace AccountOpening.Infrastructure.Persistence.Data.Configurations;

internal class ApplicationMetadataConfiguration : IEntityTypeConfiguration<ApplicationMetadata>
{
    public void Configure(EntityTypeBuilder<ApplicationMetadata> builder)
    {
        builder.ToTable("ApplicationMetadatas");
        
        builder.HasKey(am => am.Id);
        
        builder
            .Property(am => am.TransactionalPassword)
            .HasColumnType("smallint")
            .HasMaxLength(6)
            .IsRequired();
        
        builder
            .Property(am => am.DeviceName)
            .HasMaxLength(50)
            .IsRequired(false);
        
        builder
            .Property(am => am.CreatedAt)
            .HasColumnType("date");
    }
}