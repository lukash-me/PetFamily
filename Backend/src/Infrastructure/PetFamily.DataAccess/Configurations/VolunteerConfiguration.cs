using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Volunteers;

namespace PetFamily.DataAccess.Configurations;

public class VolunteerConfiguration : IEntityTypeConfiguration<Volunteer>
{
    public void Configure(EntityTypeBuilder<Volunteer> builder)
    {
        builder.HasKey(v => v.Id);
        
        builder.Property(v => v.Id)
            .HasConversion(
                id => id.Value,
                value => VolunteerId.Create(value));

        builder.ComplexProperty(v => v.FullName, nameBuilder =>
        {
            nameBuilder.Property(n => n.FirstName)
                .HasColumnName("firstname")
                .HasMaxLength(Constants.LOW_TITLE_LENGTH);
            nameBuilder.Property(n => n.LastName)
                .HasColumnName("lastname")
                .HasMaxLength(Constants.LOW_TITLE_LENGTH);
            nameBuilder.Property(n => n.MiddleName)
                .HasColumnName("middlename")
                .HasMaxLength(Constants.LOW_TITLE_LENGTH)
                .IsRequired(false);
        });
        
        builder.ComplexProperty(v => v.Description, db =>
        {
            db.Property(d => d.Value)
                .HasColumnName("description")
                .HasMaxLength(Constants.MEDIUM_DESCRIPTION_LENGTH);
        });

        builder.ComplexProperty(v => v.Experience, eb =>
        {
            eb.Property(e => e.Value)
                .HasColumnName("experience");
        });
        
        builder.ComplexProperty(v => v.HousedCount, hb =>
        {
            hb.Property(h => h.Value)
                .HasColumnName("housed_count");
        });
        
        builder.ComplexProperty(v => v.SearchingHouseCount, sb =>
        {
            sb.Property(s => s.Value)
                .HasColumnName("searching_house_count");
        });
        
        builder.ComplexProperty(v => v.Phone, nameBuilder =>
        {
            nameBuilder.Property(p => p.Value)
                .HasColumnName("phone")
                .HasMaxLength(Constants.LOW_TITLE_LENGTH);
        });
        
        builder.ComplexProperty(v => v.TreatmentCount, tb =>
        {
            tb.Property(t => t.Value)
                .HasColumnName("treatment_count");
        });
        
        builder.OwnsOne(v => v.SocialNetworks, snb =>
        {
            snb.ToJson();
            snb.OwnsMany(s => s.Network, nb =>
            {
                nb.Property(n => n.Title)
                    .IsRequired()
                    .HasMaxLength(Constants.LOW_TITLE_LENGTH);
                nb.Property(n => n.Link)
                    .IsRequired()
                    .HasMaxLength(Constants.HIGH_DESCRIPTION_LENGTH);
            });
        });
        
        builder.OwnsOne(v => v.Requisites, rb =>
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

        builder.HasMany(v => v.Pets)
            .WithOne();
    }
}