using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using PetFamily.Application.Files.Delete;
using PetFamily.Application.Files.Download;
using PetFamily.Application.Files.Upload;
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
        services.AddScoped<UploadFileService>();
        services.AddScoped<DeleteFileService>();
        services.AddScoped<DownloadFileService>();

        services.AddValidatorsFromAssembly(typeof(Inject).Assembly);

        return services;
    }
}