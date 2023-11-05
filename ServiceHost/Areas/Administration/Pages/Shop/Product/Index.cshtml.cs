using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagment.Application.Contracts.Product;
using ShopManagment.Application.Contracts.ProductCategory;
using ShopManagment.Application.ProductCategory;

namespace ServiceHost.Areas.Administration.Pages.Shop.Product
{
    public class IndexModel : PageModel
    {
        private readonly IProductApplication _productApplication;
        private readonly IProductCategoryApplication _productCategoryApplication;
        public SelectList ProductCategories { get; set; }
        public List<ProductViewModel> Products { get; set; }
        public ProductSearchModel SearchModel { get; set; }
        [TempData]
        public string Message { get; set; }
        public IndexModel(IProductApplication productApplication, IProductCategoryApplication productCategoryApplication)
        {
            _productApplication = productApplication;
            _productCategoryApplication = productCategoryApplication;
            //searchModel = new ProductSearchModel();
        }

        public void OnGet(ProductSearchModel searchModel)
        {
            Products = _productApplication.Search(searchModel);
            ProductCategories = new SelectList(_productCategoryApplication.GetProducts(), "Id", "Name");
        }

        public IActionResult OnGetCreate()
        {
            var command = new CreateProduct();
            command.Categories = _productCategoryApplication.GetProducts();
            return Partial("./Create", command);
        }

        public IActionResult OnGetEdit(long id)
        {
            var productCategory = _productApplication.GetDetails(id);
            productCategory.Categories = _productCategoryApplication.GetProducts();
            return Partial("Edit", productCategory);
        }

        public JsonResult OnPostCreate(CreateProduct command)
        {
            var result = _productApplication.Create(command);
            return new JsonResult(result);
        }

        public JsonResult OnPostEdit(EditProduct command)
        {
            var result = _productApplication.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetInStock(long id)
        {
           var result = _productApplication.InStock(id);
           if (result.IsSuccess)
               return RedirectToPage("./Index");

           Message = result.Message;
           return RedirectToPage("./Index");
        }

        public IActionResult OnGetNotInStock(long id)
        {
           var result = _productApplication.NotInStock(id);
           if (result.IsSuccess)
               return RedirectToPage("./Index");

           Message = result.Message;
            return RedirectToPage("./Index");
        }
    }
}
