using Microsoft.Extensions.DependencyInjection;
using Service;

namespace Extensions;

public static class ApplicationCollectionExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<IService, CreteUserService>();
        collection.AddScoped<IService, DepositService>();
        collection.AddScoped<IService, GetAccessService>();
        collection.AddScoped<IService, GetBalanceService>();
        collection.AddScoped<IService, GetOperationsService>();
        collection.AddScoped<IService, LoginService>();
        collection.AddScoped<IService, WithdrawService>();
        return collection;
    }
}