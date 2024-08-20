using CSharpFunctionalExtensions;
using PetFamily.Domain.Breeds;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Sorts;
using PetFamily.Domain.Volunteers;

namespace PetFamily.Domain.Pets;

public class Pet : BaseEntity<PetId>
{
    private Pet(PetId id) : base(id){ }

    private Pet(PetId id, string name, string species, string description, string breed, string color, string healthInfo,
        Address address, Phone phone, Status status, Requisites? requisites, double weight, double height, bool isCastrated,
        DateOnly birthDate, bool isVaccinated, DateTime createdAt, PetPhotos petPhotos) : base(PetId.NewPetId())
    {
        Id = id;
        Name = name;
        AnimalInfo = animalInfo;
        Description = description;
        Color = color;
        HealthInfo = healthInfo;
        Address = address;
        Phone = phone;
        Status = status;
        Requisites = requisites;
        Weight = weight;
        Height = height;
        IsCastrated = isCastrated;
        BirthDate = birthDate;
        IsVaccinated = isVaccinated;
        PetPhotos = petPhotos;
    }
    public PetId Id { get; private set; }
    public string Name { get; private set; }
    public AnimalInfo AnimalInfo { get; private set; }
    public string Description { get; private set; }
    public string Color { get; private set; }
    public string HealthInfo { get; private set; }
    public Address Address { get; private set; }
    public double Weight { get; private set; }
    public double Height { get; private set; }
    public Phone Phone { get; private set; }
    public bool IsCastrated { get; private set; }
    public DateOnly BirthDate { get; private set; }
    public bool IsVaccinated { get; private set; }
    public Status Status { get; private set; }
    public Requisites? Requisites { get; private set; }
    public PetPhotos? PetPhotos { get; private set; }
    
    public static Result<Pet> Create(PetId id, string name, string species, string description, string breed,
        string color, string healthInfo, Address address, Phone phone, Status status, Requisites? requisites, double weight,

        double height, bool isCastrated, DateOnly birthDate, bool isVaccinated, DateTime createdAt, PetPhotos petPhotos)
    {
        var pet = new Pet(id, name, animalInfo, description, color, healthInfo, address, phone, status, requisites, weight,
            height, isCastrated, birthDate, isVaccinated, createdAt, petPhotos);

        return Result.Success(pet);
    }
}

public enum Status
{
    NeedsHelp,
    SearchingHouse,
    Housed
}