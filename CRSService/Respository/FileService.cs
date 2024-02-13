using ChainOfResponsibility.CRSServcie.Interfaces;
using ChainOfResponsibility.CRSServcie.Validators;
using ChainOfResponsibility.Models;

namespace ChainOfResponsibility.CRSServcie.Repository;
public class FileService : IFileService
{
    public async Task<byte[]> DownloadFileLogic(string FileName)
    {
        var directory = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
        var path = Path.Combine(directory, FileName);

        if (!File.Exists(path)) return null;
        
        return await File.ReadAllBytesAsync(path);
    }

    public async Task<string> UploadFileLogic(FileModel file)
    {
        //Creating CRS objects
        var extensionValidatorHandler = new FileExtensionValidator();
        var fileSizeValidatorHandler = new FileSizeValidator();
        var fileDirectoryExistsValidator = new FileDirectoryExistsValidator();
        var fileNameExistsValidator = new FileNameExistsValidator();

        //Creating Chains Of Validation
        extensionValidatorHandler.setNextHandler(fileSizeValidatorHandler);
        fileSizeValidatorHandler.setNextHandler(fileDirectoryExistsValidator);
        fileDirectoryExistsValidator.setNextHandler(fileNameExistsValidator);
        fileNameExistsValidator.setNextHandler(default);

        //Start Validation Of File
        extensionValidatorHandler.ValidateFile(file);

        //Error Object Contains List Of Errors For Each Validation 
        if (Handler.errors.Count > 0)
        {
            var error = Handler.errors.FirstOrDefault();
            Handler.errors.Clear();
            return error;
        }

        //File Upload Process Begins For Valid File
        var extension = Path.GetExtension(file.File.FileName);
        var fileName = Guid.NewGuid().ToString() + extension;
        var location = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
        using var fs = new FileStream(Path.Combine(location, fileName), FileMode.Create);
        await file.File.CopyToAsync(fs);
        await fs.DisposeAsync();
        fs.Close();
        return fileName;
    }
}
