using LampShade.Query.Contract.Slide;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class SlideViewComponent : ViewComponent
    {
        private readonly ISlideQuery _slidequery;
        public SlideViewComponent(ISlideQuery slidequery)
        {
            _slidequery = slidequery;
        }
        public IViewComponentResult Invoke()
        {
            var Slide = _slidequery.GetSlides();
            return View(Slide);
        }
    }
}
