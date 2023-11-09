using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Features.Application;
using ShopManagment.Application.Contracts.ProductPicture;
using ShopManagment.Domain.ProductPictureAgg;

namespace ShopManagment.Application.ProductPicture
{
    public class ProductPictureApplication : IProductPictureApplication
    {
        private readonly IProductPictureRepository _repository;
        public ProductPictureApplication(IProductPictureRepository repository)
        {
            _repository = repository;
        }

        public OperationResult Create(CreateProductPictureApp command)
        {
            var opration = new OperationResult();
            if (_repository.Exists(x => x.Picture == command.Picture && x.ProductId == command.ProductId))
                return opration.Failed(ApplicationMessage.DuplicatedRecord);

            var picture = new Domain.ProductPictureAgg.ProductPicture(command.ProductId, command.Picture,
                command.PictureAlt, command.PictureTitle, command.PictureLink);
            _repository.Create(picture);
            _repository.Save();
            return opration.Success(ApplicationMessage.SuccessMessage);
        }

        public OperationResult Edit(EditProductPictureApp command)
        {
            var operation = new OperationResult();
            var picture = _repository.Get(command.Id);

            if (picture == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);

            if (_repository.Exists(p =>
                    p.Picture == command.Picture && p.ProductId == command.ProductId && p.Id != command.Id))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);

            picture.Edit(command.ProductId, command.Picture,
                command.PictureAlt, command.PictureTitle, command.PictureLink);
            _repository.Save();
            return operation.Success(ApplicationMessage.SuccessMessage);
        }

        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();
            var picture = _repository.Get(id);
            if (picture == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);

            picture.Remove();
            _repository.Save();
            return operation.Success(ApplicationMessage.SuccessMessage);
        }

        public OperationResult Restore(long id)
        {
            var operation = new OperationResult();
            var picture = _repository.Get(id);
            if (picture == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);

            picture.Restore();
            _repository.Save();
            return operation.Success(ApplicationMessage.SuccessMessage);
        }

        public EditProductPictureApp Get(long id)
        {
            return _repository.GetDetails(id);
        }

        public List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel)
        {
            return _repository.Search(searchModel);
        }
    }
}
