using DotNetCryptography.Dtos;
using DotNetCryptography.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCryptography.Controllers.Encryption;

[ApiController]
[Route("api/files")]
public class FilesController : ControllerBase
{
    private readonly IFileService _fileService;

    public FilesController(IFileService fileService)
    {
        _fileService = fileService;
    }

    [HttpGet("/decrypted/{id}", Name = nameof(GetDecryptedFile))]
    public async Task<IActionResult> GetDecryptedFile([FromRoute] int id)
    {
        var decryptedFile = await _fileService.GetDecryptedFile(id);
        return Ok(decryptedFile);
    }

    [HttpGet("encrypted/{id}")]
    public async Task<IActionResult> GetEncryptedFile([FromRoute] int id)
    {
        var decryptedFile = await _fileService.GetEncryptedFile(id);
        return Ok(decryptedFile);
    }

    [HttpPost]
    public async Task<IActionResult> CreateEncryptedFile([FromBody] CreateFile newFile)
    {
        var id = _fileService.CreateEncryptedFile(newFile);

        return CreatedAtRoute(nameof(GetDecryptedFile), new { id }, new { id });
    }
}
