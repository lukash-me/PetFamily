using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Species.IDs;

namespace PetFamily.Domain.Volunteers.ValueObjects;

public record AnimalInfo
{
    private AnimalInfo(SpeciesId speciesId, Guid breedId)
    {
        SpeciesId = speciesId;
        BreedId = breedId;
    }
    public SpeciesId SpeciesId { get; }
    public Guid BreedId { get; }
    
    public static Result<AnimalInfo, Error> Create(SpeciesId speciesId, Guid breedId)
    {
        if (speciesId == SpeciesId.EmptyId() || Regex.IsMatch(speciesId.Value.ToString(), Constants.GUID_REGEX) == false)
            return Errors.General.ValueIsInvalid("species id");
        
        if (breedId == Guid.Empty || Regex.IsMatch(breedId.ToString(), Constants.GUID_REGEX) == false)
            return Errors.General.ValueIsInvalid("breed id");
        
        return new AnimalInfo(speciesId, breedId);
    }
}