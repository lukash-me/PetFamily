using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Volunteers.ValueObjects;

public class PetPhoto
{
    private PetPhoto(string path, bool isMain)
    {
        Path = path;
        IsMain = isMain;
    }
    public string Path { get; }
    public bool IsMain { get; }

    public static Result<PetPhoto, Error> Create(string path, bool isMain)
    {
        if (string.IsNullOrWhiteSpace(path))
            return Errors.General.ValueIsRequired("path");
        
        if (path.Length > Constants.HIGH_DESCRIPTION_LENGTH)
            return Errors.General.InvalidLength("path");
        
        return new PetPhoto(path,isMain);
    }
}