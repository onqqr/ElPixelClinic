using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using OfficeApi.Application.DTOs;
using OfficeApi.Application.Services;

namespace OfficeApi.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // найди в этой сборке все классы-валидаторы и зарегай их в DI
        services.AddValidatorsFromAssemblyContaining<CreateOfficeRequestValidator>();
        services.AddScoped<OfficeService>();
        return services;
    }
}