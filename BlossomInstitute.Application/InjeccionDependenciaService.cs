using BlossomInstitute.Application.DataBase.Login.Command;
using Microsoft.Extensions.DependencyInjection;

namespace BlossomInstitute.Application
{
    public static class InjeccionDependenciaService
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Login
            services.AddTransient<ILoginCommand, LoginCommand>();

            return services;
        }
    }
}
