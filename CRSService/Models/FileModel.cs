using Microsoft.AspNetCore.Http;
namespace ChainOfResponsibility.Models;
public record FileModel
{
    public IFormFile File { get; set; }
}
