using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Breeds;
using PetFamily.Domain.Shared;

namespace PetFamily.DataAccess.Configurations;

public class BreedConfiguration : IEntityTypeConfiguration<Breed>
{
    public void Configure(EntityTypeBuilder<Breed> builder)
    {
        builder.HasKey(b => b.Id);
        
        builder.Property(b => b.Id)
            .HasConversion(
                id => id.Value,
                value => BreedId.Create(value));
        
        builder.Property(s => s.Value)
            .IsRequired()
            .HasMaxLength(Constants.LOW_TITLE_LENGTH);
    }
}