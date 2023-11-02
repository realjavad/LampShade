using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using Features.Application;
using ShopManagment.Application.Contracts.Product;
using ShopManagment.Domain.ProductAgg;

namespace ShopManagment.Application.Product
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository _repository;

        public ProductApplication(IProductRepository repository)
        {
            _repository = repository;
        }
        public OperationResult Create(CreateProduct command)
        {
            var operation = new OperationResult();

            if (_repository.Exists(x=>x.Name == command.Name))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            var product = new Domain.Product.Product(command.Name, command.Code, command.UnitPrice,
                command.ShortDescription, command.Picture, command.PictureAlt, command.PictureTitle, slug,
                command.Keywords, command.MetaDescription,command.Description,command.CategoryId);
            _repository.Create(product);
            _repository.Save();
            return operation.Success();
        }

        public OperationResult Edit(EditProduct command)
        {
            var operation = new OperationResult();
            var product = _repository.Get(command.Id);
            if (product == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);

            if (_repository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);
            var slug = command.Slug.Slugify();
            product.Edit(command.Name, command.Code, command.UnitPrice,
                command.ShortDescription, command.Picture, command.PictureAlt, command.PictureTitle, slug,
                command.Keywords, command.MetaDescription, command.Description, command.CategoryId);
            _repository.Save();
           return operation.Success();
        }

        public OperationResult InStock(long id)
        {
            var operation = new OperationResult();
            var product = _repository.Get(id);
            if (product == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);

           product.InStock();
           _repository.Save();
           return operation.Success();
        }

        public OperationResult NotInStock(long id)
        {
            var operation = new OperationResult();
            var product = _repository.Get(id);
            if (product == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);

            product.NotInStock();
            _repository.Save();
            return operation.Success();
        }

        public EditProduct GetDetails(long id)
        {
            return _repository.GetDetails(id);
        }

        public List<ProductViewModel> Search(ProductSearchModel command)
        {
            return _repository.Search(command);
        }
    }
}
