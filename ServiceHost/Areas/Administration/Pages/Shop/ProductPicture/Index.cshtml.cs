using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagment.Application.Contracts.Product;
using ShopManagment.Application.Contracts.ProductPicture;
using ShopManagment.Application.Product;

namespace ServiceHost.Areas.Administration.Pages.Shop.ProductPicture
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        private readonly IProductPictureApplication _pictureApplication;
        private readonly IProductApplication _productApplication;
        public ProductPictureSearchModel SearchModel;
        public SelectList Products { get; set; }
        public List<ProductPictureViewModel> PictureViewModels { get; set; }

        public IndexModel(IProductPictureApplication pictureApplication, IProductApplication productApplication)
        {
            _pictureApplication = pictureApplication;
            _productApplication = productApplication;
        }

        public void OnGet(ProductPictureSearchModel searchModel)
        {
            PictureViewModels = _pictureApplication.Search(searchModel);
            Products = new SelectList(_productApplication.GetProducts(), "Id", "Name");
        }

        public IActionResult OnGetCreate()
        {
            var command = new CreateProductPictureApp()
            {
                ProductViewModels = _productApplication.GetProducts()
            };
            return Partial("Create", command);
        }

        public JsonResult OnPostCreate(CreateProductPictureApp createProduct)
        {
            var result = _pictureApplication.Create(createProduct);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var productpicture = _pictureApplication.Get(id);
            productpicture.ProductViewModels = _productApplication.GetProducts();
            return Partial("Edit", productpicture);
        }

        public JsonResult OnPostEdit(EditProductPictureApp command)
        {
            var result = _pictureApplication.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetRemove(long id)
        {
            var command = _pictureApplication.Remove(id);
            if (command.IsSuccess)
                return RedirectToPage("./Index");

            Message = command.Message;
            return RedirectToPage("./Index");
        }


        public IActionResult OnGetRestore(long id)
        {
            var command = _pictureApplication.Restore(id);
            if (command.IsSuccess)
                return RedirectToPage("./Index");

            Message = command.Message;
            return RedirectToPage("./Index");
        }
    }
}