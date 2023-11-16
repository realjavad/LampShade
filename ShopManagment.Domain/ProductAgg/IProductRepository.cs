using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Features.Domain;
using ShopManagment.Application.Contracts.Product;

namespace ShopManagment.Domain.ProductAgg
{
    public interface IProductRepository : IRepository<long,Product.Product>
    {
        EditProduct GetDetails(long id);
        List<ProductViewModel> GetProducts();
        List<ProductViewModel> Search(ProductSearchModel searchModel);
    }
}
