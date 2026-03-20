using Dealership.Model.Validators.Admin;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace Dealership.Extensions;

public static class FluentValidationExtensions
{
    public static  IServiceCollection AddFluentValidationConfig(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblyContaining<AdminRegisterValidator>();

        return services;
    }
}