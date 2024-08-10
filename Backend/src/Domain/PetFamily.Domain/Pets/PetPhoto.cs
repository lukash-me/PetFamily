using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Pets;

public class PetPhoto
{
    private PetPhoto(string path, bool isMain)
    {
        Path = path;
        IsMain = isMain;
    }
    public Guid Id { get; private set; }
    public string Path { get; private set; }
    public bool IsMain { get; private set; }

    public Result<PetPhoto> Create(string path, bool isMain)
    {
        var petPhoto = new PetPhoto(path,isMain);
        return Result.Success(petPhoto);
    }
}