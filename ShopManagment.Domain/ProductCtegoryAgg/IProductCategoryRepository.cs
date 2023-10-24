using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagment.Domain.ProductCtegoryAgg
{
    public interface IProductCategoryRepository
    {
        Void Create(ProductCategory entity);
        ProductCategory Get(long id);
        List<ProductCategory> GetAll();
    }
}
