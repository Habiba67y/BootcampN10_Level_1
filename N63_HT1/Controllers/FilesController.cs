using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using N63_HT1.Constants;
using N63_HT1.Models.Entities;
using N63_HT1.Services.Interfaces;

namespace N63_HT1.Controllers;
[ApiController]
[Authorize]
[Route("api/[controller]")]
 
public class FilesController : ControllerBase
{
    private readonly IStorageFileService _storageFileService;
    private readonly IFileService _fileService;

    public FilesController
        (
        IStorageFileService storageFileService,
        IFileService fileService
        )
    {
        _storageFileService = storageFileService;
        _fileService = fileService;
    }

    [HttpPost]
    public async ValueTask<IActionResult> Create(IFormFile file)
    {
        var userId = User.Claims.FirstOrDefault(claim => claim.Type == ClaimConstant.UserId)?.Value;

        var storageFile = new StorageFile()
        {
            UserId = Guid.Parse(userId),
            Name = file.FileName,
            Size = file.Length,
            Extension = Path.GetExtension(file.FileName)
        };

        await _storageFileService.CreateAsync(storageFile);
        var stream = await _fileService.UploadFileAsync(file, storageFile);

        return stream != null ? Ok(stream) : BadRequest();
    }

    [HttpGet]
    public IActionResult GetFiles()
    {
        var files = _storageFileService.Get(file => true);
        
        return files.Any() ? Ok(files) : NotFound();
    }
}
