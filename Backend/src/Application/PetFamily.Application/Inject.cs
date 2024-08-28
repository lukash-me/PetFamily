using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using PetFamily.Application.Volunteers.Create;
using PetFamily.Application.Volunteers.Delete;
using PetFamily.Application.Volunteers.UpdateMainInfo;
using PetFamily.Application.Volunteers.UpdateRequisites;
using PetFamily.Application.Volunteers.UpdateSocialNetworks;

namespace PetFamily.Application;

public static class Inject
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<CreateVolunteerService>();
        services.AddScoped<UpdateMainInfoService>();
        services.AddScoped<UpdateSocialNetworksService>();
        services.AddScoped<UpdateRequisitesService>();
        services.AddScoped<DeleteVolunteerService>();

        services.AddValidatorsFromAssembly(typeof(Inject).Assembly);

        return services;
    }
}