using CSharpFunctionalExtensions;
using PetFamily.Application.FileProvider;
using PetFamily.Application.Providers;
using PetFamily.Domain.Shared;

namespace PetFamily.Application.Files.Upload;

public class UploadFileService
{
    private readonly IFileProvider _fileProvider;

    public UploadFileService(IFileProvider fileProvider)
    {
        _fileProvider = fileProvider;
    }
    
    public async Task<Result<string, Error>> Handle(UploadFileRequest request, CancellationToken cancellationToken)
    {
        return await _fileProvider.UploadFile(request.Dto, cancellationToken);
    }
}