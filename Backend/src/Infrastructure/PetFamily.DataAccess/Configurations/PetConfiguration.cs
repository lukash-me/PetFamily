using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.VisualBasic;
using PetFamily.Domain.Species.IDs;
using PetFamily.Domain.Volunteers.Entities;
using PetFamily.Domain.Volunteers.IDs;
using PetFamily.Domain.Volunteers.ValueObjects;
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
        
        builder.ComplexProperty(p => p.Name, nb =>
        {
            nb.Property(a => a.Value)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(Constants.LOW_TITLE_LENGTH);
        });
        
        builder.ComplexProperty(p => p.AnimalInfo, aib =>
        {
            aib.Property(a => a.SpeciesId)
                .HasColumnName("species_id")
                .HasConversion(
                    id => id.Value,
                    value => SpeciesId.Create(value));
            aib.Property(a => a.BreedId)
                .HasColumnName("breed_id")
                .IsRequired();
        });

        builder.ComplexProperty(p => p.Description, db =>
        {
            db.Property(d => d.Value)
                .HasColumnName("description")
                .IsRequired()
                .HasMaxLength(Constants.MEDIUM_DESCRIPTION_LENGTH);
        });
        
        builder.ComplexProperty(p => p.Color, cb =>
        {
            cb.Property(c => c.Value)
                .HasColumnName("color")
                .IsRequired()
                .HasMaxLength(Constants.LOW_TITLE_LENGTH);
        });
        
        builder.ComplexProperty(p => p.HealthInfo, hb =>
        {
            hb.Property(h => h.Value)
                .HasColumnName("health_info")
                .IsRequired()
                .HasMaxLength(Constants.HIGH_DESCRIPTION_LENGTH);
        });
        
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

        builder.ComplexProperty(p => p.Weight, wb =>
        {
            wb.Property(w => w.Value)
                .HasColumnName("weight")
                .IsRequired();
        });
        
        builder.ComplexProperty(p => p.Height, hb =>
        {
            hb.Property(h => h.Value)
                .HasColumnName("height")
                .IsRequired();
        });

        builder.ComplexProperty(p => p.Phone, nameBuilder =>
        {
            nameBuilder.Property(p => p.Value)
                .HasColumnName("phone")
                .HasMaxLength(Constants.PHONE_NUMBER_LENGTH);
        });
        
        builder.Property(p => p.IsCastrated)
            .IsRequired();
        
        builder.ComplexProperty(p => p.BirthDate, bb =>
        {
            bb.Property(b => b.Value)
                .HasColumnName("birth_date")
                .IsRequired();
        });
        
        builder.Property(p => p.IsVaccinated)
            .IsRequired();
        
        builder.ComplexProperty(p => p.Status, sb =>
        {
            sb.Property(s => s.Value)
                .HasColumnName("status")
                .IsRequired();
        });

        builder.OwnsOne(p => p.Requisites, rb =>
        {
            rb.ToJson("requisites");
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
            phb.ToJson("pet_photos");
            phb.OwnsMany(p => p.PetPhoto, pb =>
            {
                pb.Property(p => p.Path)
                    .IsRequired()
                    .HasMaxLength(Constants.HIGH_DESCRIPTION_LENGTH);
                pb.Property(p => p.IsMain)
                    .IsRequired();
            });
        });
    }
}