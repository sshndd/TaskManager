using Microsoft.Extensions.DependencyInjection;
using TaskManager.BLL.Services.UserServices;

namespace TaskManager.BLL.Extension
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
