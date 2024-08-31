using CSharpFunctionalExtensions;
using PetFamily.Application.FileProvider;
using PetFamily.Application.Files.Delete;
using PetFamily.Application.Files.Download;
using PetFamily.Domain.Shared;

namespace PetFamily.Application.Providers;

public interface IFileProvider
{
    public Task<Result<string, Error>> UploadFile(FileData fileData, CancellationToken cancellationToken = default);
    public Task<Result<string, Error>> DeleteFile(DeleteFileRequest fileData, CancellationToken cancellationToken = default);
    public Task<Result<string, Error>> GetFileUrl(DownloadFileRequest fileData, CancellationToken cancellationToken = default);
}