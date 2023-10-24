using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagment.Application.Contracts.ProductCategory
{
    public interface IProductCategoryApplication
    {
        void Create(CreateProductCategory command);
        void Edit(EditProductCategory command);
        Domain.ProductCtegoryAgg.ProductCategory GetDetails(long id);
        List<ProductCategoryViewModel> Search(ProductCategorySearchModel command);
    }
}
