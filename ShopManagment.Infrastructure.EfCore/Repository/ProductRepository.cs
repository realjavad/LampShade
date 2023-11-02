using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Features.Infrastructre;
using Microsoft.EntityFrameworkCore;
using ShopManagment.Application.Contracts.Product;
using ShopManagment.Domain.Product;
using ShopManagment.Domain.ProductAgg;
using ShopManagment.Infrastructure.EfCore.Context;

namespace ShopManagment.Infrastructure.EfCore.Repository
{
    public class ProductRepository : RepositoryBase<long,Product>, IProductRepository
    {
        private readonly ShopContext _context;
        public ProductRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public EditProduct GetDetails(long id)
        {
            return _context.Products.Select(x => new EditProduct()
            {
                Id = x.Id,
                Name = x.Name,
                Picture = x.Picture,
                ShortDescription = x.ShortDescription,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Code = x.Code,
                Keywords = x.Keywords,
                Description = x.Description,
                MetaDescription = x.MetaDescription,
                UnitPrice = x.UnitPrice,
                Slug = x.Slug,
                CategoryId = x.CategoryId,
            }).FirstOrDefault(x=>x.Id == id);
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            var query = _context.Products.Include(x => x.Category).Select(x => new ProductViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Picture = x.Picture,
                UnitPrice = x.UnitPrice,
                Category = x.Category.Name,
                Code = x.Code
            });

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            if (!string.IsNullOrWhiteSpace(searchModel.Code))
                query = query.Where(x => x.Code.Contains(searchModel.Code));

            if (!string.IsNullOrWhiteSpace(searchModel.Category))
                query = query.Where(x => x.Category.Contains(searchModel.Category));
            
            return query.OrderByDescending(x=> x.Id).ToList();
        }
    }
}
