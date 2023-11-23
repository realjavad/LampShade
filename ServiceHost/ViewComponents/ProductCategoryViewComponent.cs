using LampShade.Query.Contract.ProductCategory;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class ProductCategoryViewComponent : ViewComponent
    {
        private readonly IProductCategoryQuery _productcategory;
        public ProductCategoryViewComponent(IProductCategoryQuery productcategory)
        {
            _productcategory = productcategory;
        }
        public IViewComponentResult Invoke()
        {
            var ProductCategory = _productcategory.GetList();
            return View(ProductCategory);
        }
    }
}
