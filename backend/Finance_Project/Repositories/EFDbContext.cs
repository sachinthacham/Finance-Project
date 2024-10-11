using Finance_Project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Finance_Project.Repositories
{
    public class EFDbContext:IdentityDbContext<AppUser>
    {
        public EFDbContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        { 

        }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public DbSet<Portfolio> Portfolios { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Onmodel creating(many to many)
            builder.Entity<Portfolio>(x => x.HasKey(p => new {p.AppUserId,p.StockId}));


            //connect forign key to table(many to many)
            builder.Entity<Portfolio>()
                .HasOne(u => u.AppUser)
                .WithMany(u => u.Portfoilos)
                .HasForeignKey(p => p.AppUserId);
            
            builder.Entity<Portfolio>()
               .HasOne(u => u.Stock)
               .WithMany(u => u.Portfolios)
               .HasForeignKey(p => p.StockId);

            //different roles (for authorization)
            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole{
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                     Name = "User",
                    NormalizedName = "USER"
                },

            };

            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
