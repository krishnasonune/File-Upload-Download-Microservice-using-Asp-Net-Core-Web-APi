using ChainOfResponsibility.Models;

namespace ChainOfResponsibility.CRSServcie.Validators;
public class FileDirectoryExistsValidator : Handler
{
    public override void ValidateFile(FileModel file)
    {
        var DirectoryToUploadFiles = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
        if (!Directory.Exists(DirectoryToUploadFiles))
        {
            errors.Add($"{DirectoryToUploadFiles}, Directory does not exists on the server");
        }
    }
}
