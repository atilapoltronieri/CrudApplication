using AutoMapper;
using CrudApplication.Core.Entities.Business;
using CrudApplication.Core.Entities.Persistence;
using CrudApplication.Core.Interfaces.IRepository;
using CrudApplication.Core.Interfaces.IServices;
using CrudApplication.Core.Interfaces.Mapper;
using CrudApplication.Core.Mapper;
using CrudApplication.Core.Services;
using CrudApplication.Infrastructure.Repositories;

namespace CrudApplication.API.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection RegisterService(this IServiceCollection services)
        {
            #region Services
            services.AddScoped<IProductService, ProductService>();

            #endregion

            #region Repositories
            services.AddTransient<IProductRepository, ProductRepository>();

            #endregion

            #region Mapper
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductDto>();
                cfg.CreateMap<ProductDto, Product>();
            });

            IMapper mapper = configuration.CreateMapper();

            services.AddSingleton<IBaseMapper<Product, ProductDto>>(new BaseMapper<Product, ProductDto>(mapper));
            services.AddSingleton<IBaseMapper<ProductDto, Product>>(new BaseMapper<ProductDto, Product>(mapper));

            #endregion

            return services;
        }
    }
}
