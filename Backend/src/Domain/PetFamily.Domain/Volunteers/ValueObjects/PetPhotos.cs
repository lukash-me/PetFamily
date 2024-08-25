namespace PetFamily.Domain.Volunteers.ValueObjects;

public record PetPhotos
{
    public PetPhotos() { }
    public PetPhotos(IEnumerable<PetPhoto> petPhotos)
    {
        PetPhoto = petPhotos.ToList();
    }
    public IReadOnlyList<PetPhoto> PetPhoto { get; }
}