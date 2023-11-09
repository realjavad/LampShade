using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Features.Application;

namespace ShopManagment.Application.Contracts.ProductPicture
{
    public interface IProductPictureApplication
    {
        OperationResult Create(CreateProductPictureApp command);
        OperationResult Edit(EditProductPictureApp command);
        OperationResult Remove(long id);
        OperationResult Restore(long id);
        EditProductPictureApp Get(long id);
        List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel);
    }
}
