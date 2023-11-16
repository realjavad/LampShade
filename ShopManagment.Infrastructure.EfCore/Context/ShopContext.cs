using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopManagment.Domain.Product;
using ShopManagment.Domain.ProductCtegoryAgg;
using ShopManagment.Domain.ProductPictureAgg;
using ShopManagment.Domain.SlideAgg;
using ShopManagment.Infrastructure.EfCore.Mapping;

namespace ShopManagment.Infrastructure.EfCore.Context
{
    public class ShopContext : DbContext
    {
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPicture> ProductPictures { get; set; }
        public DbSet<Slide> Slides { get; set; }
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(ProductCategoryMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
