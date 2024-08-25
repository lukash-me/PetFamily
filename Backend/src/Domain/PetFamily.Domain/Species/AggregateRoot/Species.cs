using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Species.Entities;
using PetFamily.Domain.Species.IDs;

namespace PetFamily.Domain.Species.AggregateRoot;
public class Species : BaseEntity<SpeciesId>
{
    public Species(SpeciesId id) : base(id) { }
    private Species(SpeciesId id, string value) : base(SpeciesId.NewId())
    {
        Id = id;
        Value = value;
    }
    public SpeciesId Id { get; private set; }
    public string Value { get; private set; }
    public IReadOnlyList<Breed>? Breeds => _breeds;
    private readonly List<Breed> _breeds = [];

    public static Result<Species, Error> Create(SpeciesId id, string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Errors.General.ValueIsRequired("species");

        if (value.Length > Constants.LOW_TITLE_LENGTH)
            return Errors.General.InvalidLength("species");
        
        return new Species(id, value);
    }
}