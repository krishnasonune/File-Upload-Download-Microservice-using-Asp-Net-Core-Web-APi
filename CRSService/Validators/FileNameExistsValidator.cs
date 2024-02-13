using ChainOfResponsibility.Models;

namespace ChainOfResponsibility.CRSServcie.Validators;
public class FileNameExistsValidator : Handler
{
    public override void ValidateFile(FileModel file)
    {
        if (File.Exists(Path.Combine(Directory.GetCurrentDirectory(), file.File.FileName)))
        {
            errors.Add("File with the same name already exists on the server");
        }
    }
}
