using Bogus;
using CrudApplication.Core.Entities.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CrudApplication.Infrastructure.Data
{
    public class ApplicationDbContextConfigurations
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUser>().ToTable("Users");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");

            // Add any additional entity configurations here
        }

        public static void SeedData(ModelBuilder modelBuilder)
        {
            // Generate fake product data.
            var productIds = Enumerable.Range(1, 100).ToList();
            var fakerSeedProducts = new Faker<Product>()
                .RuleFor(c => c.Id, f =>
                {
                    var index = f.Random.Int(0, productIds.Count - 1);
                    var id = productIds[index];
                    productIds.RemoveAt(index);
                    return id;
                })
                .RuleFor(p => p.Code, f => f.Random.AlphaNumeric(6))
                .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                .RuleFor(p => p.Description, f => f.Commerce.ProductDescription())
                .RuleFor(p => p.IsActive, f => f.Random.Bool());

            var fakeProducts = fakerSeedProducts.Generate(100);
            modelBuilder.Entity<Product>().HasData(fakeProducts);
        }
    }
}
