using CSharpFunctionalExtensions;
using PetFamily.Domain.Breeds;
using PetFamily.Domain.Pets;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Sorts;

public class Species : BaseEntity<SpeciesId>
{
    public Species(SpeciesId id) : base(id) { }
    private Species(SpeciesId id, string value, List<Breed> breeds, List<Pet> pets) : base(SpeciesId.NewId())
    {
        Id = id;
        Value = value;
        _breeds = breeds;
        _pets = pets;
    }
    public SpeciesId Id { get; private set; }
    public string Value { get; private set; }
    public IReadOnlyList<Breed> Breeds => _breeds;
    private readonly List<Breed> _breeds;
    
    public IReadOnlyList<Pet> Pets => _pets;
    private readonly List<Pet> _pets;

    public static Result<Species> Create(SpeciesId id, string value, List<Breed> breeds, List<Pet> pets)
    {
        var species = new Species(id, value, breeds, pets);
        return Result.Success(species);
    }
}