using System.ComponentModel.Design;
using CSharpFunctionalExtensions;
using PetFamily.Domain.Pets;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Volunteers;

public class Volunteer : BaseEntity<VolunteerId>
{
    private Volunteer(VolunteerId id, DateTime createdAt) : base(id, createdAt) { }
    private Volunteer(VolunteerId id, FullName fullName, string description, string phone, SocialNetworks socialNetworks,
        Requisites requisites, List<Pet> pets, int experience, int housedCount, int searchingHouseCount,
        int treatmentCount) : base(VolunteerId.NewVolunteerId(), DateTime.UtcNow)
    {
        Id = id;
        FullName = fullName;
        Description = description;
        Phone = phone;
        SocialNetworks = socialNetworks;
        Requisites = requisites;
        _pets = pets;
        Experience = experience;
        HousedCount = housedCount;
        SearchingHouseCount = searchingHouseCount;
        TreatmentCount = treatmentCount;
    }

    public VolunteerId Id { get; private set; }
    public FullName FullName { get; private set; }
    public string Description { get; private set; }
    public int Experience { get; private set; }
    public int HousedCount { get; private set; }
    public int SearchingHouseCount { get; private set; }
    public string Phone { get; private set; }
    public int TreatmentCount { get; private set; }
    public SocialNetworks? SocialNetworks { get; private set; }
    public Requisites? Requisites { get; private set; }
    public IReadOnlyList<Pet> Pets => _pets;
    private readonly List<Pet> _pets;
    public static Result<Volunteer> Create(VolunteerId id, FullName fullName, string description, string phone,
        SocialNetworks socialNetworks,
        Requisites requisites, List<Pet> pets, int experience, int housedCount, int searchingHouseCount,
        int treatmentCount)
    {
        var volunteer = new Volunteer(id, fullName, description, phone, socialNetworks, requisites, pets, experience,
            housedCount, searchingHouseCount, treatmentCount);
        return Result.Success(volunteer);
    }
}

public class FullName : ValueObject
{
    private FullName(string firstName, string lastName, string middleName)
    {
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
    }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string MiddleName { get; private set; }
    protected override IEnumerable<IComparable> GetEqualityComponents()
    {
        yield return FirstName;
        yield return LastName;
        yield return MiddleName;
    }
    public static Result<FullName> Create(string firstName, string lastName, string middleName)
    {
        var fullName = new FullName(firstName, lastName, middleName);
        return Result.Success(fullName);
    }
}

public record SocialNetworks
{
    public List<SocialNetwork> Network { get; }
}

public record Requisites
{
    public List<Requisite> Requisite { get; }
}

public record class SocialNetwork
{
    public SocialNetwork(string link, string title)
    {
        Link = link;
        Title = title;
    }
    public string Link { get; }
    public string Title { get; }

    public static Result<SocialNetwork> Create(string link, string title)
    {
        var socialNetwork = new SocialNetwork(link, title);
        return Result.Success(socialNetwork);
    }
}

