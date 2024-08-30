using CSharpFunctionalExtensions;
using PetFamily.Application.Providers;
using PetFamily.Domain.Shared;

namespace PetFamily.Application.Files.Delete;

public class DeleteFileService
{
    private readonly IFileProvider _fileProvider;

    public DeleteFileService(IFileProvider fileProvider)
    {
        _fileProvider = fileProvider;
    }
    
    public async Task<Result<string, Error>> Handle(DeleteFileRequest request, CancellationToken cancellationToken)
    {
        return await _fileProvider.DeleteFile(request, cancellationToken);
    }
}