using Application.Services.ImageService;
using Application.Services.PaymentService;
using Infrastructure.Adapters.ImageService;
using Infrastructure.Adapters.Payment;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<ImageServiceBase, CloudinaryImageServiceAdapter>();
        services.AddScoped<PaymentServiceBase, IyziCoPaymentAdapter>();
        return services;
    }
}
