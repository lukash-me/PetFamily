using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Volunteers.IDs;
using PetFamily.Domain.Volunteers.ValueObjects;

namespace PetFamily.Domain.Volunteers.Entities;

public class Pet : BaseEntity<PetId>
{
    private Pet(PetId id) : base(id){ }

    private Pet(
        PetId id,
        Name name,
        AnimalInfo animalInfo,
        Description description,
        Color color,
        HealthInfo healthInfo,
        Address address,
        Phone phone,
        Status status,
        Requisites? requisites,
        Weight weight,
        Height height,
        bool isCastrated,
        BirthDate birthDate,
        bool isVaccinated,
        PetPhotos petPhotos) : base(PetId.NewId())
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
    public Name Name { get; private set; }
    public AnimalInfo AnimalInfo { get; private set; }
    public Description Description { get; private set; }
    public Color Color { get; private set; }
    public HealthInfo HealthInfo { get; private set; }
    public Address Address { get; private set; }
    public Weight Weight { get; private set; }
    public Height Height { get; private set; }
    public Phone Phone { get; private set; }
    public bool IsCastrated { get; private set; }
    public BirthDate BirthDate { get; private set; }
    public bool IsVaccinated { get; private set; }
    public Status Status { get; private set; }
    public Requisites? Requisites { get; private set; }
    public PetPhotos? PetPhotos { get; private set; }
    
    public static Result<Pet> Create(
        PetId id,
        Name name,
        AnimalInfo animalInfo,
        Description description,
        Color color,
        HealthInfo healthInfo,
        Address address,
        Phone phone,
        Status status,
        Requisites? requisites,
        Weight weight,
        Height height,
        bool isCastrated,
        BirthDate birthDate,
        bool isVaccinated,
        PetPhotos petPhotos)
    {
        var pet = new Pet(
            id,
            name,
            animalInfo,
            description,
            color,
            healthInfo,
            address,
            phone,
            status,
            requisites,
            weight,
            height,
            isCastrated,
            birthDate,
            isVaccinated,
            petPhotos);

        return Result.Success(pet);
    }
}