using CSharpFunctionalExtensions;
using PetFamily.Domain.Pets;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Breeds;

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

    public Result<Breed> Create(BreedId id, string value)
    {
        var breed = new Breed(id, value);
        return Result.Success(breed);
    }
}