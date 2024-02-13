using ChainOfResponsibility.CRSServcie.Interfaces;
using ChainOfResponsibility.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChainOfResponsibility.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class FileUploadController : ControllerBase
{
    private IFileService fileService;
    public FileUploadController(IFileService fileService)
    {
        this.fileService = fileService;
    }
    
    [HttpPost("UploadFile")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UploadFile([FromForm] FileModel file)
    {
        var result = await this.fileService.UploadFileLogic(file);
        return Ok(result);
    }

    [HttpGet("DownloadFile")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(File), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DownloadFile(string FileName)
    {
        var result = await this.fileService.DownloadFileLogic(FileName);
        if(result == null) return NotFound("File not found");

        return File(result, "application/octet-stream", FileName);
    }
}
