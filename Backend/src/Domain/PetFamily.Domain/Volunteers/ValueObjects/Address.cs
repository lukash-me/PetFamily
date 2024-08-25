using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Volunteers.ValueObjects;

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

    public static Result<Address, Error> Create(string country, string city, string street, string house, string flat)
    {
        if (string.IsNullOrWhiteSpace(country))
            return Errors.General.ValueIsRequired("country");

        if (country.Length > Constants.LOW_TITLE_LENGTH)
            return Errors.General.InvalidLength("country");
        
        if (string.IsNullOrWhiteSpace(city))
            return Errors.General.ValueIsRequired("city");

        if (city.Length > Constants.LOW_TITLE_LENGTH)
            return Errors.General.InvalidLength("city");
        
        if (string.IsNullOrWhiteSpace(street))
            return Errors.General.ValueIsRequired("street");

        if (street.Length > Constants.LOW_TITLE_LENGTH)
            return Errors.General.InvalidLength("street");
        
        if (string.IsNullOrWhiteSpace(house))
            return Errors.General.ValueIsRequired("house");

        if (house.Length > Constants.LOW_TITLE_LENGTH)
            return Errors.General.InvalidLength("house");
        
        if (string.IsNullOrWhiteSpace(flat))
            return Errors.General.ValueIsRequired("flat");

        if (flat.Length > Constants.LOW_TITLE_LENGTH)
            return Errors.General.InvalidLength("flat");
        
        return new Address(country, city, street, house, flat);
    }
}