using CSharpFunctionalExtensions;
using PetFamily.Domain.Breeds;
using PetFamily.Domain.Pets;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Sorts;

public class Species : BaseEntity<SpeciesId>
{
    public Species(SpeciesId id) : base(id) { }
    private Species(SpeciesId id, string value, List<Breed> breeds) : base(SpeciesId.NewId())
    {
        Id = id;
        Value = value;
        _breeds = breeds;
    }
    public SpeciesId Id { get; private set; }
    public string Value { get; private set; }
    public IReadOnlyList<Breed> Breeds => _breeds;
    private readonly List<Breed> _breeds;

    public static Result<Species> Create(SpeciesId id, string value, List<Breed> breeds)
    {
        var species = new Species(id, value, breeds);
        return Result.Success(species);
    }
}