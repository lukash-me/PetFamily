using CSharpFunctionalExtensions;
using PetFamily.Application.Providers;
using PetFamily.Domain.Shared;

namespace PetFamily.Application.Files.Download;

public class DownloadFileService
{
    private readonly IFileProvider _fileProvider;

    public DownloadFileService(IFileProvider fileProvider)
    {
        _fileProvider = fileProvider;
    }

    public async Task<Result<string, Error>> Handle(
        DownloadFileRequest request, 
        CancellationToken cancellationToken = default)
    {
        return await _fileProvider.GetFileUrl(request, cancellationToken);
    }
}