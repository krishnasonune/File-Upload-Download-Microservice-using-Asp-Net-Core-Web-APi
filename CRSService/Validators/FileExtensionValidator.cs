using ChainOfResponsibility.Models;

namespace ChainOfResponsibility.CRSServcie.Validators;
public class FileExtensionValidator : Handler
{
    public string[] validExtension = {".jpg", ".png"};
    public override void ValidateFile(FileModel file)
    {
        if (!validExtension.Contains(Path.GetExtension(file.File.FileName)))
        {
            errors.Add($"Invalid file format, valid file formats are {string.Join(", ",validExtension)}");
        }
        else
        {
            _handler.ValidateFile(file);
        }
    }
}
