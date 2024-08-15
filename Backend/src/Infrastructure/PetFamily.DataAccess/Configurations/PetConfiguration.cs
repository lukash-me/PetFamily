using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.VisualBasic;
using PetFamily.Domain.Breeds;
using PetFamily.Domain.Pets;
using PetFamily.Domain.Sorts;
using Constants = PetFamily.Domain.Shared.Constants;

namespace PetFamily.DataAccess.Configurations;

public class PetConfiguration : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Id)
            .HasConversion(
                id => id.Value,
                value => PetId.Create(value));

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(Constants.LOW_TITLE_LENGTH);
        
        builder.ComplexProperty(p => p.AnimalInfo, aib =>
        {
            aib.Property(a => a.SpeciesId)
                .HasConversion(
                    id => id.Value,
                    value => SpeciesId.Create(value));
            aib.Property(a => a.BreedId)
                .HasConversion(
                    id => id.Value,
                    value => BreedId.Create(value));
        });

        builder.Property(p => p.Description)
            .IsRequired()
            .HasMaxLength(Constants.MEDIUM_DESCRIPTION_LENGTH);
        
        builder.Property(p => p.Color)
            .IsRequired()
            .HasMaxLength(Constants.LOW_TITLE_LENGTH);
        
        builder.Property(p => p.HealthInfo)
            .IsRequired()
            .HasMaxLength(Constants.MEDIUM_DESCRIPTION_LENGTH);
        
        builder.ComplexProperty(p => p.Address, addressBuilder =>
        {
            addressBuilder.Property(a => a.Country)
                .HasColumnName("country")
                .HasMaxLength(Constants.LOW_TITLE_LENGTH);
            addressBuilder.Property(a => a.City)
                .HasColumnName("city")
                .HasMaxLength(Constants.LOW_TITLE_LENGTH);
            addressBuilder.Property(a => a.Street)
                .HasColumnName("street")
                .HasMaxLength(Constants.LOW_TITLE_LENGTH);
            addressBuilder.Property(a => a.Flat)
                .HasColumnName("flat")
                .HasMaxLength(Constants.LOW_TITLE_LENGTH);
            addressBuilder.Property(a => a.House)
                .HasColumnName("house")
                .HasMaxLength(Constants.LOW_TITLE_LENGTH);
        });

        builder.Property(p => p.Weight)
            .IsRequired();

        builder.Property(p => p.Height)
            .IsRequired();

        builder.ComplexProperty(p => p.Phone, nameBuilder =>
        {
            nameBuilder.Property(p => p.Value)
                .HasColumnName("phone")
                .HasMaxLength(Constants.LOW_TITLE_LENGTH);
        });

        builder.Property(p => p.IsCastrated)
            .IsRequired();
        
        builder.Property(p => p.BirthDate)
            .IsRequired();
        
        builder.Property(p => p.IsVaccinated)
            .IsRequired();

        builder.Property(p => p.Status)
            .IsRequired()
            .HasConversion(
                s => s.ToString(),
                s => (Status)Enum.Parse(typeof(Status), s));

        builder.OwnsOne(p => p.Requisites, rb =>
        {
            rb.ToJson();
            rb.OwnsMany(r => r.Requisite, reqb =>
            {
                reqb.Property(r => r.Title)
                    .IsRequired()
                    .HasMaxLength(Constants.MEDIUM_TITLE_LENGTH);
                reqb.Property(r => r.Description)
                    .IsRequired()
                    .HasMaxLength(Constants.MEDIUM_DESCRIPTION_LENGTH);
            });
        });

        builder.OwnsOne(p => p.PetPhotos, phb =>
        {
            phb.ToJson();
            phb.OwnsMany(p => p.Photo, pb =>
            {
                pb.Property(p => p.Path)
                    .IsRequired()
                    .HasMaxLength(Constants.MEDIUM_TITLE_LENGTH);
                pb.Property(p => p.IsMain)
                    .IsRequired();
            });
        });
    }
}