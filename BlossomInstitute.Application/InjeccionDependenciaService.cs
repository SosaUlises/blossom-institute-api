using BlossomInstitute.Application.DataBase.Login.Command;
using BlossomInstitute.Application.DataBase.Password.ForgotPassword;
using BlossomInstitute.Application.DataBase.Password.ResetPassword;
using BlossomInstitute.Application.Validator.Login;
using BlossomInstitute.Application.Validator.Password;
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

            // Password
            services.AddTransient<IForgotPasswordCommand, ForgotPasswordCommand>();
            services.AddTransient<IResetPasswordCommand, ResetPasswordCommand>();

            // Validators
            services.AddScoped<IValidator<LoginModel>, LoginValidator>();
            services.AddScoped<IValidator<ForgotPasswordModel>, ForgotPasswordValidator>();
            services.AddScoped<IValidator<ResetPasswordModel>, ResetPasswordValidator>();


            return services;
        }
    }
}
