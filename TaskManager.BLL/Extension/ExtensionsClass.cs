using TaskManager.BLL.Services.UserService;
using Microsoft.Extensions.DependencyInjection;

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
