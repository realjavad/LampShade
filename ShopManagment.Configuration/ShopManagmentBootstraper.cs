using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopManagment.Application.Contracts.ProductCategory;
using ShopManagment.Application.ProductCategory;
using ShopManagment.Domain.ProductCtegoryAgg;
using ShopManagment.Infrastructure.EfCore.Context;
using ShopManagment.Infrastructure.EfCore.Repository;

namespace ShopManagment.Configuration
{
    public class ShopManagmentBootstraper
    {
        public static void Configure(IServiceCollection service,string connectionString)
        {
            service.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();
            service.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
            service.AddDbContext<ShopContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
