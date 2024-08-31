using Microsoft.AspNetCore.Mvc;
using PetFamily.API.Extensions;
using PetFamily.Application.FileProvider;
using PetFamily.Application.Files.Delete;
using PetFamily.Application.Files.Download;
using PetFamily.Application.Files.Upload;

namespace PetFamily.API.Controllers;

[ApiController]
[Route("[controller]")]
public class FileController : ControllerBase
{
    [HttpGet("{path:guid}")]
    public async Task<ActionResult> DownloadFile(
        [FromRoute] Guid path,
        [FromServices] DownloadFileService service,
        CancellationToken cancellationToken = default)
    {
        var request = new DownloadFileRequest("files", path.ToString());

        var result = await service.Handle(request, cancellationToken);
        if (result.IsFailure)
            return result.Error.ToResponse();

        return Ok(result.Value);
    }
    
    [HttpPost]
    public async Task<ActionResult> UploadFile(
        IFormFile file, 
        [FromServices] UploadFileService service,
        CancellationToken cancellationToken = default)
    {
        await using var stream = file.OpenReadStream();

        var path = Guid.NewGuid().ToString();

        var dto = new FileData(stream, "files", path);
        
        var request = new UploadFileRequest(dto);

        var result = await service.Handle(request, cancellationToken);
        if (result.IsFailure)
            return result.Error.ToResponse();

        return Ok(result.Value);
    }
    
    [HttpDelete("{path:guid}")]
    public async Task<ActionResult> DeleteFile(
        [FromRoute] Guid path,
        [FromServices] DeleteFileService service,
        CancellationToken cancellationToken = default)
    {
        var request = new DeleteFileRequest("files", path.ToString());

        var result = await service.Handle(request, cancellationToken);
        if (result.IsFailure)
            return result.Error.ToResponse();

        return Ok(result.Value);
    }
}