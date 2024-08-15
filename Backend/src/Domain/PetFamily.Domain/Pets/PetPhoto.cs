using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Pets;

public class PetPhoto
{
    private PetPhoto(string path, bool isMain)
    {
        Path = path;
        IsMain = isMain;
    }
    public string Path { get; }
    public bool IsMain { get; }

    public static Result<PetPhoto> Create(string path, bool isMain)
    {
        var petPhoto = new PetPhoto(path,isMain);
        return Result.Success(petPhoto);
    }
}