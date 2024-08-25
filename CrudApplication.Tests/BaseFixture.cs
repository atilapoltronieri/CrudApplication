using CrudApplication.Core.Entities.Persistence;
using CrudApplication.Infrastructure.Data;
using CrudApplication.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudApplication.Tests
{
    public class BaseFixture : IDisposable
    {
        public Mock<ApplicationDbContext> dbContextMock;
        public ProductRepository productRepository;
        public Product newProduct;

        public BaseFixture() : base()
        {
            dbContextMock = new Mock<ApplicationDbContext>(new DbContextOptions<ApplicationDbContext>());
            productRepository = new ProductRepository(dbContextMock.Object);

            newProduct = new Product
            {
                Code = "P001",
                Name = "Sample Product",
                IsActive = true
            };

            var productDbSetMock = new Mock<DbSet<Product>>();

            dbContextMock.Setup(db => db.Set<Product>())
                          .Returns(productDbSetMock.Object);

            productDbSetMock.Setup(dbSet => dbSet.AddAsync(newProduct, default))
                            .ReturnsAsync((EntityEntry<Product>)null);

        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
