using CSharpFunctionalExtensions;
using PetFamily.Domain.Pets;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Volunteers;

public record Requisites
{
    private Requisites() { }
    public Requisites(List<Requisite> requisite)
    {
        Requisite = requisite;
    }

    public IReadOnlyList<Requisite> Requisite { get; }
}