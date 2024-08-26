using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Volunteers.ValueObjects;

public record Requisites
{
    private Requisites() { }
    public Requisites(IEnumerable<Requisite> requisite)
    {
        Requisite = requisite.ToList();
    }
    public IReadOnlyList<Requisite> Requisite { get; }
}