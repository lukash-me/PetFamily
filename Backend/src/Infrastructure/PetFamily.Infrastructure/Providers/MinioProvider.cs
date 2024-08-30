using System.Reactive.Linq;
using CSharpFunctionalExtensions;
using Microsoft.Extensions.Logging;
using Minio;
using Minio.DataModel.Args;
using Minio.Exceptions;
using PetFamily.Application.FileProvider;
using PetFamily.Application.Files.Delete;
using PetFamily.Application.Files.Download;
using PetFamily.Application.Providers;
using PetFamily.Domain.Shared;

namespace PetFamily.Infrastructure.Providers;

public class MinioProvider : IFileProvider
{
    private readonly IMinioClient _minioClient;
    private readonly ILogger<MinioProvider> _logger;

    public MinioProvider(IMinioClient minioClient, ILogger<MinioProvider> logger)
    {
        _minioClient = minioClient;
        _logger = logger;
    }
    
    public async Task<Result<string, Error>> UploadFile(FileData fileData, CancellationToken cancellationToken = default)
    {
        try
        {
            var bucketExistArgs = new BucketExistsArgs()
                .WithBucket(fileData.BucketName);

            var bucketExist = await _minioClient.BucketExistsAsync(bucketExistArgs, cancellationToken);
            if (bucketExist == false)
            {
                var makeBucketArgs = new MakeBucketArgs()
                    .WithBucket(fileData.BucketName);

                await _minioClient.MakeBucketAsync(makeBucketArgs, cancellationToken);
            }

            var putObjectArgs = new PutObjectArgs()
                .WithBucket(fileData.BucketName)
                .WithStreamData(fileData.Stream)
                .WithObjectSize(fileData.Stream.Length)
                .WithObject(fileData.Path);

            var result = await _minioClient.PutObjectAsync(putObjectArgs, cancellationToken);

            return result.ObjectName;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, Errors.Minio.UploadFailure().Message);
            return Errors.Minio.UploadFailure(fileData.Path);
        }
    }

    public async Task<Result<string, Error>> DeleteFile(DeleteFileRequest fileData, CancellationToken cancellationToken)
    {
        try
        {
            var bucketExistArgs = new BucketExistsArgs()
                .WithBucket(fileData.BucketName);

            var bucketExist = await _minioClient.BucketExistsAsync(bucketExistArgs, cancellationToken);
            if (bucketExist == false)
                return Errors.Minio.BucketNotFound(fileData.BucketName);
            
            var fileExistResult = await FileExist(fileData.BucketName,  fileData.Path, cancellationToken);
            if (fileExistResult.IsFailure)
                return fileExistResult.Error;
            
            RemoveObjectArgs rmArgs = new RemoveObjectArgs()
                .WithBucket(fileData.BucketName)
                .WithObject(fileData.Path);

            await _minioClient.RemoveObjectAsync(rmArgs, cancellationToken);
            _logger.LogInformation("File deleted with id {fileId}", fileData.Path);

            return fileData.Path;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, Errors.Minio.DeleteFailure().Message);
            return Errors.Minio.DeleteFailure(fileData.Path);
        }
    }

    public async Task<Result<string, Error>> GetFileUrl(
        DownloadFileRequest fileData, 
        CancellationToken cancellationToken = default)
    {
        try
        {
            var bucketExistArgs = new BucketExistsArgs()
                .WithBucket(fileData.BucketName);

            var bucketExist = await _minioClient.BucketExistsAsync(bucketExistArgs, cancellationToken);
            if (bucketExist == false)
            {
                return Errors.Minio.BucketNotFound(fileData.BucketName);
            }

            var fileExistResult = await FileExist(fileData.BucketName, fileData.Path, cancellationToken);
            if (fileExistResult.IsFailure)
                return fileExistResult.Error;
            
            PresignedGetObjectArgs args = new PresignedGetObjectArgs()
                .WithBucket(fileData.BucketName)
                .WithObject(fileData.Path)
                .WithExpiry(60 * 60 * 24);
            String url = await _minioClient.PresignedGetObjectAsync(args);
            
            return url;
        }
        catch(Exception ex)
        {
            _logger.LogError(ex, Errors.Minio.DownloadFailure().Message);
            return Errors.Minio.DownloadFailure(fileData.Path);
        }
    }

    private async Task<Result<string, Error>> FileExist(
        string bucketName,
        string path,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var args = new ListObjectsArgs()
                .WithBucket(bucketName);

            var objects = _minioClient.ListObjectsAsync(args);
            if (await objects.FirstOrDefaultAsync(c => c.Key == path) is null)
                return Errors.Minio.FileNotFound(path);

            return path;
        }
        catch (MinioException ex)
        {
            _logger.LogError(ex, Errors.Minio.FileCheckFailure().Message);
            return Errors.Minio.FileCheckFailure(path);
        }
    }
}