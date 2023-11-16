using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagment.Application.Contracts.Slide;

namespace ServiceHost.Areas.Administration.Pages.Shop.Slide
{
    public class IndexModel : PageModel
    {
        public string Message;
        private readonly ISlideApplication _slideApplication;
        public List<SlideViewModelApp> Slides { get; set; }

        public IndexModel(ISlideApplication slideApplication)
        {
            _slideApplication = slideApplication;
        }
        public void OnGet()
        {
            Slides = _slideApplication.GetList();
        }

        public IActionResult OnGetCreate()
        {
            return Partial("create", new CreateSlideApp());
        }

        public JsonResult OnPostCreate(CreateSlideApp command)
        {
            var result = _slideApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetRemove(long id)
        {
           var result = _slideApplication.Remove(id);
            if (result.IsSuccess)
                return RedirectToPage("./Index");

            Message = result.Message;
            return RedirectToPage("Index");

        }

        public IActionResult OnGetRestore(long id)
        {
           var result =  _slideApplication.Restore(id);
           return RedirectToPage("./Index");
        }

        public IActionResult OnGetEdit(long id)
        {
            var slide = _slideApplication.GetBy(id);
            return Partial("Edit", slide);
        }

        public JsonResult OnPostEdit(EditSlideApp command)
        {
            var result = _slideApplication.Edit(command);
            return new JsonResult(result);
        }
    }
}
