using ChainOfResponsibility.Models;

namespace ChainOfResponsibility.CRSServcie.Validators;
public abstract class Handler
{
    public static List<string> errors = new List<string>();
    protected Handler _handler;

    public void setNextHandler(Handler handler)
    {
        _handler = handler;
    }

    public abstract void ValidateFile(FileModel file);
}
