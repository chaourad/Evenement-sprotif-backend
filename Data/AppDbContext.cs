
using evenement.Modals;
using Microsoft.EntityFrameworkCore;

namespace evenement.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .HasMany(r => r.Role)
            .WithMany(u => u.Users);
        }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users {get; set;}
    }
}
