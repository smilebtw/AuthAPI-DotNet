using Microsoft.EntityFrameworkCore;
using AuthAPI.Models;

namespace AuthAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> usuarios { get; set; }
        public DbSet<Group> grupos { get; set; }

    }
}
