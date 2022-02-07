using Microsoft.EntityFrameworkCore;
using ReEntry.WebAPI.Models;

namespace ReEntry.WebAPI
{
    public class InsuranceDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;

        public DbSet<Product> Products { get; set; }

        public DbSet<Offer> Offers { get; set; } = null!;

        public InsuranceDbContext(DbContextOptions<InsuranceDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(p =>
            {
                p.HasKey(product => product.Id);
                var partsNav = p.Metadata.FindNavigation(nameof(Product.Covers));
                partsNav.SetPropertyAccessMode(PropertyAccessMode.Field); // ?
            });


            modelBuilder.Entity<User>().HasData(
                    new User { Id = new Guid("24bbc257-1e2a-4a0e-818c-bd413452cac1"), Name = "Tom", Age = 37 }
                    //new User { Id = new Guid(), Name = "Bob", Age = 41 },
                    //new User { Id = new Guid(), Name = "Sam", Age = 24 }
            );
        }
    }
}
