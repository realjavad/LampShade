using LampShade.Query.Contract.Slide;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class SlideViewComponents : ViewComponent
    {
        private readonly ISlideQuery _slidequery;
        public SlideViewComponents(ISlideQuery slidequery)
        {
            _slidequery = slidequery;
        }
        public IViewComponentResult Invoke()
        {
            var slide = _slidequery.GetSlides();
            return View(slide);
        }
    }
}
