﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagment.Domain.ProductPictureAgg;

namespace ShopManagment.Infrastructure.EfCore.Mapping
{
    public class ProductPictureMapping : IEntityTypeConfiguration<ProductPicture>
    {
        public void Configure(EntityTypeBuilder<ProductPicture> builder)
        {
            builder.ToTable("ProductPictures");
            builder.HasKey(x=>x.Id);
            builder.Property(x => x.Picture).HasMaxLength(1000).IsRequired();
            builder.Property(x => x.PictureAlt).HasMaxLength(500).IsRequired();
            builder.Property(x => x.PictureTitle).HasMaxLength(500).IsRequired();
            builder.Property(x=>x.PictureLink).HasMaxLength(1000).IsRequired();
            builder.HasOne(x => x.Product).WithMany(x => x.ProductPictures).HasForeignKey(x => x.ProductId);
        }
    }
}
