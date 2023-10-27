using Features.Domain;
using ShopManagment.Application.Contracts.ProductCategory;

namespace ShopManagment.Domain.ProductCtegoryAgg;

public interface IProductCategoryRepository : IRepository<long, ProductCategory>
{
    EditProductCategory GetDetails(long id);
    List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel);

    //comment down list becuse use a 'IRepository'
    //void Create(ProductCategory entity);
    //ProductCategory Get(long id);
    //List<ProductCategory> GetAll();
    //bool Exists(Expression<Func<ProductCategory, bool>> expression);
    //void Save();
}