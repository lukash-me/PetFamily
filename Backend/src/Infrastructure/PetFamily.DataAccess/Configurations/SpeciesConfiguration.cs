using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Sorts;

namespace PetFamily.DataAccess.Configurations;

public class SpeciesConfiguration : IEntityTypeConfiguration<Species>
{
    public void Configure(EntityTypeBuilder<Species> builder)
    {
        builder.HasKey(s => s.Id);
        
        builder.Property(s => s.Id)
            .HasConversion(
                id => id.Value,
                value => SpeciesId.Create(value));
        
        builder.Property(s => s.Value)
            .IsRequired()
            .HasMaxLength(Constants.LOW_TITLE_LENGTH);
        
        builder.HasMany(s => s.Breeds)
            .WithOne();
    }
}