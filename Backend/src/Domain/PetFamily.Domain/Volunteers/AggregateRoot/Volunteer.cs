using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Volunteers.Entities;
using PetFamily.Domain.Volunteers.IDs;
using PetFamily.Domain.Volunteers.ValueObjects;

namespace PetFamily.Domain.Volunteers.AggregateRoot;

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
        Experience experience) : base(VolunteerId.NewVolunteerId())
    {
        Id = id;
        FullName = fullName;
        Description = description;
        Phone = phone;
        SocialNetworks = socialNetworks;
        Requisites = requisites;
        Experience = experience;
    }

    public VolunteerId Id { get; private set; }
    public FullName FullName { get; private set; }
    public Description Description { get; private set; }
    public Experience Experience { get; private set; }
    public Phone Phone { get; private set; }
    public SocialNetworks? SocialNetworks { get; private set; }
    public Requisites? Requisites { get; private set; }
    public IReadOnlyList<Pet> Pets => _pets;
    private readonly List<Pet> _pets = [];
    public int HousedPetsCount() => _pets.Count(x => x.Status == Status.Housed);
    public int NeedHelpPetsCount() => _pets.Count(x => x.Status == Status.NeedsHelp);
    public int SearchingHousePetsCount() => _pets.Count(x => x.Status == Status.SearchingHouse);
    
    public static Result<Volunteer, Error> Create(
        VolunteerId id,
        FullName fullName,
        Description description,
        Phone phone,
        SocialNetworks? socialNetworks,
        Requisites? requisites,
        Experience experience)
    {
        var volunteer = new Volunteer(
            id,
            fullName,
            description,
            phone,
            socialNetworks,
            requisites,
            experience);
        
        return volunteer;
    }
}