using ShopManagment.Infrastructure.EfCore.Context;

namespace LampShade.Query.Contract.Slide;

public class SlideQuery : ISlideQuery
{
    private readonly ShopContext _context;
    public SlideQuery(ShopContext context)
    {
        _context = context;
    }
    public List<SlideQueryModel> GetSlides()
    {
        return _context.Slides.Select(x=> new SlideQueryModel()
        {
            Title = x.Title,
            BtnText = x.BtnText,
            Heading = x.Heading,
            Picture = x.Picture,
            PictureAlt = x.PictureAlt,
            PictureTitle = x.PictureTitle,
            Text = x.Text,
            Link = x.Link
        }).ToList();
    }
}