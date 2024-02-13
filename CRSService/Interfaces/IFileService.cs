using ChainOfResponsibility.Models;

namespace ChainOfResponsibility.CRSServcie.Interfaces;
public interface IFileService
{
    public Task<string> UploadFileLogic(FileModel file);
    public Task<byte[]> DownloadFileLogic(string FileName);
}
