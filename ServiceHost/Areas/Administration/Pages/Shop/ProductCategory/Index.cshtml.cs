using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagment.Application.Contracts.ProductCategory;

namespace ServiceHost.Areas.Administration.Pages.Shop.ProductCategory
{
    public class IndexModel : PageModel
    {
        private readonly IProductCategoryApplication _productcategoryapplication;
        public List<ProductCategoryViewModel> ProductCategories { get; set; }
        public ProductCategorySearchModel SearchModel;
        public IndexModel(IProductCategoryApplication productcategoryapplication)
        {
            _productcategoryapplication = productcategoryapplication;
        }
        public void OnGet(ProductCategorySearchModel searchModel)
        {
           ProductCategories = _productcategoryapplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateProductCategory());
        }

        public JsonResult OnPostCreate(CreateProductCategory command)
        {
            var result = _productcategoryapplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var productCategory = _productcategoryapplication.GetDetails(id);
            return Partial("Edit", productCategory);
        }

        public JsonResult OnPostEdit(EditProductCategory command)
        {
            var result = _productcategoryapplication.Edit(command);
            return new JsonResult(result);
        }
    }
}
