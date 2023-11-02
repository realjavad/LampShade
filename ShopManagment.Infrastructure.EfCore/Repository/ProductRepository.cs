using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Features.Infrastructre;
using Microsoft.EntityFrameworkCore;
using ShopManagment.Application.Contracts.Product;
using ShopManagment.Domain.Product;
using ShopManagment.Domain.ProductAgg;
using ShopManagment.Infrastructure.EfCore.Context;

namespace ShopManagment.Infrastructure.EfCore.Repository
{
    public class ProductRepository : RepositoryBase<long,Product>, IProductRepository
    {
        private readonly ShopContext _context;
        public ProductRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public EditProduct GetDetails(long id)
        {
            throw new NotImplementedException();
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            throw new NotImplementedException();
        }
    }
}
