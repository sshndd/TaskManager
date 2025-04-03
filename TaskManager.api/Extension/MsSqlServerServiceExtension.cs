using Microsoft.EntityFrameworkCore;
using TaskManager.api.Models.Data;

namespace TaskManager.api.Extension
{
    public static class MsSqlServerServiceExtension
    {
        public static void AddMsSqlServerDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
        }
    }
}
