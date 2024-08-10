using CSharpFunctionalExtensions;
using PetFamily.Domain.Pets;

namespace PetFamily.Domain.Volunteers;

public class Volunteer
{
    private Volunteer(FullName fullName, string description, string phone, List<SocialNetwork> socialNetworks,
        List<Requisites> requisites, List<Pet> pets, int experience, int housedCount, int searchingHouseCount,
        int treatmentCount)
    {
        FullName = fullName;
        Description = description;
        Phone = phone;
        _socialNetworks = socialNetworks;
        _requisites = requisites;
        _pets = pets;
        Experience = experience;
        HousedCount = housedCount;
        SearchingHouseCount = searchingHouseCount;
        TreatmentCount = treatmentCount;
    }

    public Guid Id { get; private set; }
    public FullName FullName { get; private set; }
    public string Description { get; private set; }
    public int Experience { get; private set; }
    public int HousedCount { get; private set; }
    public int SearchingHouseCount { get; private set; }
    public string Phone { get; private set; }
    public int TreatmentCount { get; private set; }
    public IReadOnlyList<SocialNetwork> SocialNetworks => _socialNetworks;
    private readonly List<SocialNetwork> _socialNetworks;
    public IReadOnlyList<Requisites> Requisites => _requisites;
    private readonly List<Requisites> _requisites;
    public IReadOnlyList<Pet> Pets => _pets;
    private readonly List<Pet> _pets;

    public static Result<Volunteer> Create(FullName fullName, string description, string phone,
        List<SocialNetwork> socialNetworks,
        List<Requisites> requisites, List<Pet> pets, int experience, int housedCount, int searchingHouseCount,
        int treatmentCount)

    {
        var volunteer = new Volunteer(fullName, description, phone, socialNetworks, requisites, pets, experience,
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

public class SocialNetwork
{
    public SocialNetwork(string link, string title)
    {
        Link = link;
        Title = title;
    }
    public string Link { get; private set; }
    public string Title { get; private set; }

    public static Result<SocialNetwork> Create(string link, string title)
    {
        var socialNetwork = new SocialNetwork(link, title);
        return Result.Success(socialNetwork);
    }
}

