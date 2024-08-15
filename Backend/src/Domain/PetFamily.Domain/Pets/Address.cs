using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Pets;

public record Address
{
    private Address(string country, string city, string street, string house, string flat)
    {
        Country = country;
        City = city;
        Street = street;
        House = house;
        Flat = flat;
    }
    public string Country { get; }
    public string City { get; }
    public string Street { get; }
    public string House { get; }
    public string Flat { get; }

    public static Result<Address> Create(string country, string city, string street, string house, string flat)
    {
        var address = new Address(country, city, street, house, flat);
        return Result.Success(address);
    }
}