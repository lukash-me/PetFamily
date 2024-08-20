using CSharpFunctionalExtensions;
using PetFamily.Domain.Breeds;
using PetFamily.Domain.Sorts;

namespace PetFamily.Domain.Pets;

public record AnimalInfo
{
    private AnimalInfo(SpeciesId speciesId, BreedId breedId)
    {
        SpeciesId = speciesId;
        BreedId = breedId;
    }
    public SpeciesId SpeciesId { get; }
    public BreedId BreedId { get; }
    
    public static Result<AnimalInfo> Create(SpeciesId speciesId, BreedId breedId)
    {
        var animalInfo = new AnimalInfo(speciesId, breedId);
        return Result.Success(animalInfo);
    }
}