using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LampShade.Query.Contract.ProductCategory;
using ShopManagment.Infrastructure.EfCore.Context;

namespace LampShade.Query.Query
{
    public class ProductCategoryQuery : IProductCategoryQuery
    {
        private readonly ShopContext _context;
        public ProductCategoryQuery(ShopContext context)
        {
            _context = context;
        }
        public List<ProductCategoryQueryModel> GetList()
        {
            return _context.ProductCategories.Select(x=> new ProductCategoryQueryModel()
            {
                Id = x.Id,
                Name = x.Name,
                Picture = x.Picture,
                PictureTitle = x.PictureTitle,
                PictureAlt = x.PictureAlt,
                Slug = x.Slug
            }).ToList();
        }
    }
}
