using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopManagment.Application.Contracts.Product;
using ShopManagment.Application.Contracts.ProductCategory;
using ShopManagment.Application.Contracts.ProductPicture;
using ShopManagment.Application.Product;
using ShopManagment.Application.ProductCategory;
using ShopManagment.Application.ProductPicture;
using ShopManagment.Domain.ProductAgg;
using ShopManagment.Domain.ProductCtegoryAgg;
using ShopManagment.Domain.ProductPictureAgg;
using ShopManagment.Infrastructure.EfCore.Context;
using ShopManagment.Infrastructure.EfCore.Repository;

namespace ShopManagment.Configuration
{
    public class ShopManagmentBootstraper
    {
        public static void Configure(IServiceCollection service,string connectionString)
        {
            // ***  ***  ***  ***  ***  ***  ***  ***  ***  ***  ***  ***  ***  ***
            service.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();
            service.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
            // ***  ***  ***  ***  ***  ***  ***  ***  ***  ***  ***  ***  ***  ***
            service.AddTransient<IProductApplication, ProductApplication>();
            service.AddTransient<IProductRepository, ProductRepository>();
            // ***  ***  ***  ***  ***  ***  ***  ***  ***  ***  ***  ***  ***  ***
            service.AddTransient<IProductPictureApplication, ProductPictureApplication>();
            service.AddTransient<IProductPictureRepository, ProductPictureRepository>();
            // ***  ***  ***  ***  ***  ***  ***  ***  ***  ***  ***  ***  ***  ***
            service.AddDbContext<ShopContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
