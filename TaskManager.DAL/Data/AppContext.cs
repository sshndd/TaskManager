using Microsoft.EntityFrameworkCore;
using TaskManager.Common.Models;
using TaskManager.DAL.Models;

namespace TaskManager.DAL.Data
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
                var admin = new User("Roman", "Serkov", "admin@admin.com", "qwerty123", UserStatus.Admin);
                Users.Add(admin);
                SaveChanges();
            }
        }
    }
}
