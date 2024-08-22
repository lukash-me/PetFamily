using System.ComponentModel.Design;
using CSharpFunctionalExtensions;
using PetFamily.Domain.Pets;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Volunteers;

public class Volunteer : BaseEntity<VolunteerId>
{
    private Volunteer(VolunteerId id) : base(id) { }
    private Volunteer(
        VolunteerId id,
        FullName fullName,
        Description description,
        Phone phone,
        SocialNetworks? socialNetworks,
        Requisites? requisites,
        Experience experience,
        HousedCount housedCount,
        SearchingHouseCount searchingHouseCount,
        TreatmentCount treatmentCount) : base(VolunteerId.NewVolunteerId())
    {
        Id = id;
        FullName = fullName;
        Description = description;
        Phone = phone;
        SocialNetworks = socialNetworks;
        Requisites = requisites;
        Experience = experience;
        HousedCount = housedCount;
        SearchingHouseCount = searchingHouseCount;
        TreatmentCount = treatmentCount;
    }

    public VolunteerId Id { get; private set; }
    public FullName FullName { get; private set; }
    public Description Description { get; private set; }
    public Experience Experience { get; private set; }
    public HousedCount HousedCount { get; private set; }
    public SearchingHouseCount SearchingHouseCount { get; private set; }
    public Phone Phone { get; private set; }
    public TreatmentCount TreatmentCount { get; private set; }
    public SocialNetworks? SocialNetworks { get; private set; }
    public Requisites? Requisites { get; private set; }
    public IReadOnlyList<Pet> Pets => _pets;
    private readonly List<Pet> _pets = [];
    public static Result<Volunteer, Error> Create(
        VolunteerId id,
        FullName fullName,
        Description description,
        Phone phone,
        SocialNetworks? socialNetworks,
        Requisites? requisites,
        Experience experience,
        HousedCount housedCount,
        SearchingHouseCount searchingHouseCount,
        TreatmentCount treatmentCount)
    {
        var volunteer = new Volunteer(id, fullName, description, phone, socialNetworks, requisites, experience,
            housedCount, searchingHouseCount, treatmentCount);
        
        return volunteer;
    }
}