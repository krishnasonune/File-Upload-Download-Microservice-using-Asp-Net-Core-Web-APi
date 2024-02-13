using ChainOfResponsibility.Models;

namespace ChainOfResponsibility.CRSServcie.Validators;
public class FileSizeValidator : Handler
{
    private long fileLimit = 2 * 1024 * 1024;
    public override void ValidateFile(FileModel file)
    {
        if (file.File.Length > fileLimit)
        {
            errors.Add($"File size is over the limit, file should be less than {(fileLimit/1024)/1024}mb");
        }
        else
        {
            _handler.ValidateFile(file);
        }
    }
}
