using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Features.Domain;
using ShopManagment.Application.Contracts.Slide;

namespace ShopManagment.Domain.SlideAgg
{
    public interface ISlideRepository : IRepository<long, Slide>
    {
        EditSlideApp GetBy(long id);
        List<SlideViewModelApp> GetList();
    }
}