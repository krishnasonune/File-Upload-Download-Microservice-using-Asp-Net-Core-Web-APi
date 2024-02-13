using ChainOfResponsibility.CRSServcie.Interfaces;
using ChainOfResponsibility.CRSServcie.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace ChainOfResponsibility.CRSServcie.Services;
public static class MyCRSServcie
{
    public static void ExtendCRSServcies(this IServiceCollection service)
    {
        service.AddScoped<IFileService, FileService>();
    }
}
