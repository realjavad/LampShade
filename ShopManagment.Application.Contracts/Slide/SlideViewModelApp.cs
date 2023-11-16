namespace ShopManagment.Application.Contracts.Slide;

public class SlideViewModelApp
{
    public long Id { get; set; }
    public string Picture { get; set; }
    public string Heading { get; set; }
    public string Title { get; set; }
    public string CreationDate { get; set; }
    public bool IsRemove { get; set; }
}