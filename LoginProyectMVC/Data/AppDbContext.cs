using LoginProyectMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace LoginProyectMVC.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<Role> Roles { get; set; }

    }
}

