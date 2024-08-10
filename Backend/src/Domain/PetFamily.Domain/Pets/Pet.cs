using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Pets;

public class Pet
{
    private readonly List<Requisites> _requisites;
    private Pet(string name, string species, string description, string breed, string color, string healthInfo,
        string address, string phone, Status status, List<Requisites> requisites, double weight, double height, bool isCastrated,
        DateOnly birthDate, bool isVaccinated, DateTime createdAt)
    {
        Name = name;
        Species = species;
        Description = description;
        Breed = breed;
        Color = color;
        HealthInfo = healthInfo;
        Address = address;
        Phone = phone;
        Status = status;
        _requisites = requisites;
        Weight = weight;
        Height = height;
        IsCastrated = isCastrated;
        BirthDate = birthDate;
        IsVaccinated = isVaccinated;
        CreatedAt = createdAt;
    }
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Species { get; private set; }
    public string Description { get; private set; }
    public string Breed { get; private set; }
    public string Color { get; private set; }
    public string HealthInfo { get; private set; }
    public string Address { get; private set; }
    public double Weight { get; private set; }
    public double Height { get; private set; }
    public string Phone { get; private set; }
    public bool IsCastrated { get; private set; }
    public DateOnly BirthDate { get; private set; }
    public bool IsVaccinated { get; private set; }
    public Status Status { get; private set; }
    public IReadOnlyList<Requisites> Requisites => _requisites;
    public DateTime CreatedAt { get; private set; }

    public static Result<Pet> Create(string name, string species, string description, string breed,
        string color, string healthInfo, string address, string phone, Status status, List<Requisites> requisites, double weight,
        double height, bool isCastrated, DateOnly birthDate, bool isVaccinated, DateTime createdAt)
    {
        var pet = new Pet(name, species, description, breed, color, healthInfo, address, phone, status, requisites, weight,
            height, isCastrated, birthDate, isVaccinated, createdAt);

        return Result.Success(pet);
    }
}
public enum Status
{
    NeedsHelp,
    SearchingHouse,
    Housed
}
public class Requisites
{
    private Requisites(string title, string description)
    {
        Title = title;
        Description = description;
    }
    public string Title { get; private set; }
    public string Description { get; private set; }

    public static Result<Requisites> Create(string title, string description)
    {
        var requisites = new Requisites(title, description);
        return Result.Success(requisites);
    }
}