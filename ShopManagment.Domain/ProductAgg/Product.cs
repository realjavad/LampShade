﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Features.Domain;
using ShopManagment.Domain.ProductCtegoryAgg;
using ShopManagment.Domain.ProductPictureAgg;

namespace ShopManagment.Domain.Product
{
    public class Product : EntityBase<long>
    {
        public string Name { get; private set; }
        public string Code { get; private set; }
        public double UnitPrice { get; private set; }
        public bool IsINStock { get; private set; }
        public string ShortDescription { get; private set; }
        public string Description { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string Slug { get; private set; }
        public string Keywords { get; private set; }
        public string MetaDescription { get; private set; }
        public long CategoryId { get; private set; }
        public ProductCategory Category  { get; private set; }
        public List<ProductPicture> ProductPictures { get; private set; }

        protected Product()
        {
            ProductPictures = new List<ProductPicture>();
        }

        public Product(string name, string code, double unitPrice, string shortDescription, string description, string picture, string pictureAlt, string pictureTitle, string slug, string keywords, string metaDescription, long categoryId)
        {
            Name = name;
            Code = code;
            UnitPrice = unitPrice;
            ShortDescription = shortDescription;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metaDescription;
            CategoryId = categoryId;
            IsINStock = true;
        }

        public void Edit(string name, string code, double unitPrice, string shortDescription, string description, string picture, string pictureAlt, string pictureTitle, string slug, string keywords, string metaDescription, long categoryId)
        {
            Name = name;
            Code = code;
            UnitPrice = unitPrice;
            ShortDescription = shortDescription;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metaDescription;
            CategoryId = categoryId;
        }

        public void InStock()
        {
            this.IsINStock = true;
        }

        public void NotInStock()
        {
            this.IsINStock = false;
        }
    }
}
