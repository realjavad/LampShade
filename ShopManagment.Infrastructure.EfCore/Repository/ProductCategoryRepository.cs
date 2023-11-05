using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Features.Infrastructre;
using ShopManagment.Application.Contracts.ProductCategory;
using ShopManagment.Domain.ProductCtegoryAgg;
using ShopManagment.Infrastructure.EfCore.Context;

namespace ShopManagment.Infrastructure.EfCore.Repository
{
    public class ProductCategoryRepository : RepositoryBase<long,ProductCategory>, IProductCategoryRepository
    {
        private readonly ShopContext _context;
        public ProductCategoryRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public EditProductCategory GetDetails(long id)
        {
            return _context.ProductCategories.Select(x => new EditProductCategory()
            {
                Id = x.Id,
                Description = x.Description,
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,
                Name = x.Name,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Slug = x.Slug
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ProductCategoryViewModel> GetProductCategorie()
        {
            return _context.ProductCategories.Select(x=> new ProductCategoryViewModel()
            {
                Id = x.Id,Name = x.Name
            }).ToList();
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel)
        {
            var query = _context.ProductCategories.Select(x => new ProductCategoryViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                CreationDate = x.CreationDate.ToString(),
                Picture = x.Picture
            });

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            return query.OrderByDescending(x=>x.Id).ToList();
        }

        //comment down list becuse use a 'RepositoryBase'
        //public void Create(ProductCategory entity)
        //{
        //    _context.ProductCategories.Add(entity);
        //}

        //public ProductCategory Get(long id)
        //{
        //   return _context.ProductCategories.Find(id);
        //}

        //public List<ProductCategory> GetAll()
        //{
        //    return _context.ProductCategories.ToList();
        //}

        //public bool Exists(Expression<Func<ProductCategory, bool>> expression)
        //{
        //    return _context.ProductCategories.Any(expression);
        //}

        //public void Save()
        //{
        //    _context.SaveChanges();
        //}
    }
}
