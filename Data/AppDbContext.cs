using Agency.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Agency.Data
{
    public class AppDbContext:IdentityDbContext<M001User>
    {
        public AppDbContext(DbContextOptions options):base(options)
        {}
        public DbSet<Services> Services { get; set; }
        public DbSet<Banner> Banners { get; set; } 
        public DbSet<About> About { get; set; }
        public DbSet<Portfolio> Portfolio { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Social> Socials { get; set; }
        public DbSet<SocialNetwork> SocialNetworks { get; set; }
        public DbSet<Team>Teams{get; set; }
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<M001User>().ToTable("Users");
            builder.Entity<IdentityRole>().ToTable("Roles");
        }
    }
}
