using Microsoft.EntityFrameworkCore;
using TaskManagementAPI2.Models;

namespace TaskManagementAPI2.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users => Set<User>();
    }
}
