namespace PetFamily.Domain.Volunteers.ValueObjects;

public record PetPhotos
{
    private PetPhotos() { }
    private PetPhotos(IEnumerable<PetPhoto> petPhotos)
    {
        PetPhoto = petPhotos.ToList();
    }
    public IReadOnlyList<PetPhoto> PetPhoto { get; }
}