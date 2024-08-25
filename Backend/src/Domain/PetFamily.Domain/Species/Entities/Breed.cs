using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Species.IDs;

namespace PetFamily.Domain.Species.Entities;

public class Breed : BaseEntity<BreedId>
{
    private Breed(BreedId id) : base(id) { }
    private Breed(BreedId id, string value) : base(BreedId.NewId())
    {
        Id = id;
        Value = value;
    }

    public BreedId Id { get; private set; }
    public string Value { get; private set; }

    public Result<Breed, Error> Create(BreedId id, string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Errors.General.ValueIsRequired("breed");

        if (value.Length > Constants.LOW_TITLE_LENGTH)
            return Errors.General.InvalidLength("breed");
        
        return new Breed(id, value);
    }
}