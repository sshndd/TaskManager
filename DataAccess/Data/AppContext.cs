using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TaskManager.api.Models;
using TaskManager.Common.Models;

namespace DataAccess.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ProjectAdmin> ProjectAdmins { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Desk> Desks { get; set; }
        public DbSet<Objective> Objectives { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
            if (Users.Any(u => u.Status == UserStatus.Admin) == false)
            {
                var admin = new User() {FirstName = "Roman", LastName = "Serkov", Email = "Admin@admin.com", Password = "qwerty123", Status = UserStatus.Admin};
                Users.Add(admin);
                SaveChanges();
            }
        }
    }
}
