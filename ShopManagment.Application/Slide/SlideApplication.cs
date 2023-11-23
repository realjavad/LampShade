using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Features.Application;
using ShopManagment.Application.Contracts.Slide;
using ShopManagment.Domain.SlideAgg;

namespace ShopManagment.Application.Slide
{
    public class SlideApplication : ISlideApplication
    {
        private readonly ISlideRepository _repository;

        public SlideApplication(ISlideRepository repository)
        {
            _repository = repository;
        }

        public OperationResult Create(CreateSlideApp command)
        {
            var opration = new OperationResult();
            var slide = new Domain.SlideAgg.Slide(command.Picture, command.PictureTitle, command.PictureAlt,
                command.Heading, command.Title, command.Text, command.BtnText,command.Link);
            _repository.Create(slide);
            _repository.Save();
            return opration.Success();
        }

        public OperationResult Edit(EditSlideApp command)
        {
            var opration = new OperationResult();
            var result = _repository.Get(command.Id);
            if (result == null)
            {
                return opration.Failed(ApplicationMessage.RecordNotFound);
            }
            result.Edit(command.Picture, command.PictureTitle, command.PictureAlt,
                command.Heading, command.Title, command.Text, command.BtnText, command.Link);
            _repository.Save();
            return opration.Success();
        }

        public OperationResult Remove(long id)
        {
            var opration = new OperationResult();
            var result = _repository.Get(id);
            if (result == null)
                opration.Failed(ApplicationMessage.RecordNotFound);

            result.Remove();
            _repository.Save();
            return opration.Success();
        }

        public OperationResult Restore(long id)
        {
            var opration = new OperationResult();
            var result = _repository.Get(id);
            if (result == null)
                opration.Failed(ApplicationMessage.RecordNotFound);

                result.Restore();
            _repository.Save();
            return opration.Success();
        }

        public EditSlideApp GetBy(long id)
        {
            return _repository.GetBy(id);
        }

        public List<SlideViewModelApp> GetList()
        {
            return _repository.GetList();
        }
    }
}
