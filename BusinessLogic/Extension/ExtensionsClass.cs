using BusinessLogic.Services.UserServices;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogic.Extension
{
    public static class ExtensionsClass
    {
        public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}
