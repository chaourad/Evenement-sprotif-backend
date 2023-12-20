
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
            modelBuilder.Entity<Evenement>()
            .HasMany(p => p.Participants);
            modelBuilder.Entity<Evenement>()
            .HasOne(p => p.Organisateur);
            modelBuilder.Entity<Evenement>()
            .HasOne(t => t.TypeEvns);
            modelBuilder.Entity<Message>()
            .HasOne(u => u.User);
           
        }
        public DbSet<Role> Roles { get; set; }
       public DbSet<User> Users {get; set;}
        public DbSet<Evenement> Events {get;set;}
        public DbSet<Organisateur> Organisateurs {get; set;}
        public DbSet<Participant> Participants {get; set;}
        public DbSet<TypeEvn> Types { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
