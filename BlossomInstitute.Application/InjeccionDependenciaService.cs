using BlossomInstitute.Application.DataBase.Login.Command;
using BlossomInstitute.Application.Validator.Login;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BlossomInstitute.Application
{
    public static class InjeccionDependenciaService
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Login
            services.AddTransient<ILoginCommand, LoginCommand>();

            // Validators
            services.AddScoped<IValidator<LoginModel>, LoginValidator>();



            return services;
        }
    }
}
