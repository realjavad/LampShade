using Features.Application;

namespace ShopManagment.Application.Contracts.Slide;

public interface ISlideApplication
{
    OperationResult Create(CreateSlideApp command);
    OperationResult Edit(EditSlideApp command);
    OperationResult Remove(long id);
    OperationResult Restore(long id);
    EditSlideApp GetBy(long id);
    List<SlideViewModelApp> GetList();
}